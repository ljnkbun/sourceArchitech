using Azure;
using MathNet.Numerics;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto;
using Shopfloor.Core.Helpers;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using static MassTransit.ValidationResultExtensions;

namespace Shopfloor.IED.Application.Query.SewingRoutings
{
    public class GetSewingLayoutExcelQuery : IRequest<FileContentResult>
    {
        public int Id { get; set; }
    }

    public class GetSewingLayoutExcelQueryHandler : IRequestHandler<GetSewingLayoutExcelQuery, FileContentResult>
    {
        private readonly ISewingRoutingRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRequestClientService _requestClientService;

        public GetSewingLayoutExcelQueryHandler(ISewingRoutingRepository repository, IWebHostEnvironment webHostEnvironment, IRequestClientService requestClientService)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _requestClientService = requestClientService;
        }

        public async Task<FileContentResult> Handle(GetSewingLayoutExcelQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
                throw new ArgumentNullException(nameof(request.Id));

            var routing = await _repository.GetSewingRoutingForExcelByIdAsync(request.Id);
            if (routing == null)
                throw new Exception("Not found data");

            var dataExport = await FillDataAsync(routing);
            var fileName = "SewingTemplate.xlsx";
            var excelContent = ExportExcelHelper.WriteExcelXSSF(GetTemplateFilePath(fileName), dataExport);
            return new FileContentResult(excelContent.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fileName,
                EnableRangeProcessing = true,
            };
        }

        private async Task<ExcelDataModel> FillDataAsync(SewingRouting routing)
        {
            var data = new Dictionary<int, Dictionary<string, object>>();
            var isCreateNewRows = new Dictionary<int, bool>();

            FillDataForHeader(routing, ref data, ref isCreateNewRows);
            var subCategrories = await GetSubCategoriesInMasterService();
            var machines = new List<string>();
            FillDataForRoutingBOLTable(routing, subCategrories, ref data, ref isCreateNewRows, ref machines);
            FillDataForMachineTable(machines, ref data, ref isCreateNewRows);

            return new ExcelDataModel
            {
                Data = data,
                IsCreateNewRows = isCreateNewRows,
                SheetIndex = 0,
                ReFormat = true
            };
        }

        private void FillDataForHeader(SewingRouting routing, ref Dictionary<int, Dictionary<string, object>> data, ref Dictionary<int, bool>  isCreateNewRows)
        {
            data.Add(
                3,
                new Dictionary<string, object>
                {
                    { "D", routing.SewingIED.Buyer }
                }
            );
            data.Add(
                4,
                new Dictionary<string, object>
                {
                    { "D", routing.SewingIED.ArticleCode }
                }
            );
            data.Add(
                6,
                new Dictionary<string, object>
                {
                    { "D", routing.SewingIED.RequestArticleOutput.RequestDivisionProcess.RequestDivision.Request.ExpectedQty }
                }
            );

            isCreateNewRows.Add(
                3,
                false
            );
            isCreateNewRows.Add(
                4,
                false
            );
            isCreateNewRows.Add(
                6,
                false
            );
        }

        private void FillDataForRoutingBOLTable(SewingRouting routing, List<GetSubCategoryByIdResponse> subCategrories, ref Dictionary<int, Dictionary<string, object>> data, ref Dictionary<int, bool> isCreateNewRows, ref List<string> machines)
        {
            var totalLineIndex = 27;
            var totalSMV = routing.SewingRoutingBOLs.Sum(b => b.SMV);
            data.Add(
                    totalLineIndex,
                    new Dictionary<string, object>
                    {
                        { "I", totalSMV }
                    }
                );
            isCreateNewRows.Add(
                totalLineIndex,
                false
            );

            int rowIndexForTable = totalLineIndex + 1;
            foreach (var bol in routing.SewingRoutingBOLs)
            {
                var machineCodeList = GetMachineCodeList(bol, subCategrories);
                machines.AddRange(machineCodeList.Split(", "));

                data.Add(
                rowIndexForTable,
                new Dictionary<string, object>
                    {
                        { "B", bol.LineNumber },
                        { "C", bol.Name },
                        { "G", machineCodeList},
                        { "I", bol.SMV }
                    }
                );

                isCreateNewRows.Add(
                    rowIndexForTable,
                    true
                );
                rowIndexForTable++;
            }
            machines = machines.Distinct().ToList();
        }
        private string GetTemplateFilePath(string fileName)
        {
            var folderName = "TemplateWFX";
            var templateFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, folderName, fileName);
            if (!File.Exists(templateFilePath))
                throw new FileNotFoundException(fileName + " not found.");

            return templateFilePath;
        }

        private async Task<List<GetSubCategoryByIdResponse>> GetSubCategoriesInMasterService()
        {
            var response = await _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest());
            if (response == null || response.Message == null)
            {
                throw new Exception("Cannot get SubCategories from master.");
            }
            return response.Message.Data;
        }

        private string GetMachineCodeList(SewingRoutingBOL bol, List<GetSubCategoryByIdResponse> subCategrories)
        {
            var machineCodeList = string.Empty;

            if (bol.Type == SewingRoutingType.OP)
                machineCodeList = GetMachineCodeList(bol.SewingOperationLib, subCategrories);
            else if (bol.Type == SewingRoutingType.FT)
            {
                foreach (var item in bol.SewingFeatureLib?.SewingFeatureLibBOLs ?? Enumerable.Empty<SewingFeatureLibBOL>())
                {
                    if (!machineCodeList.IsNullOrEmpty())
                    {
                        machineCodeList += ", ";
                    }
                    machineCodeList += GetMachineCodeList(item.SewingOperationLib, subCategrories);
                }
            }
            return machineCodeList;
        }
        private string GetMachineCodeList(SewingOperationLib operation, List<GetSubCategoryByIdResponse> subCategrories)
        {
            string machineCodeList = string.Empty;

            var machineTasks = operation?.SewingOperationLibBOLs?.Where(t => t.Type == OperationBOLType.MN);
            foreach (var task in machineTasks ?? Enumerable.Empty<SewingOperationLibBOL>())
            {
                var machineId = task.SewingTaskLib?.SewingMachineEfficiencyProfile?.MachineId;
                if (machineId != null)
                {
                    if (!machineCodeList.IsNullOrEmpty())
                    {
                        machineCodeList += ", ";
                    }
                    machineCodeList += subCategrories.FirstOrDefault(s => s.Id == machineId)?.Code;
                }
            }
            return machineCodeList;
        }
        private void FillDataForMachineTable(List<string> machines, ref Dictionary<int, Dictionary<string, object>> data, ref Dictionary<int, bool> isCreateNewRows)
        {
            var rowIndex = 4;
            var numberOfMachineMax = 20;
            foreach (var machine in machines)
            {
                if (rowIndex > numberOfMachineMax)
                    break;

                if(data.ContainsKey(rowIndex))
                    data[rowIndex].Add("N", machine);
                else
                {
                    data.Add(
                        rowIndex,
                        new Dictionary<string, object>
                        {
                            { "N", machine }
                        }
                    );
                }

                if (!isCreateNewRows.ContainsKey(rowIndex))
                {
                    isCreateNewRows.Add(
                        rowIndex,
                        false
                    );
                }
                rowIndex++;
            }
        }
    }
}