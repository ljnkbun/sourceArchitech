using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.CropSeasons
{
    public class CropSeasonParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
