using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Infrastructure.TypeConfigurations;

namespace Shopfloor.IED.Infrastructure.Contexts
{
    public partial class IEDContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public IEDContext(DbContextOptions<IEDContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.Now;
                        entry.Entity.CreatedUserId = _authenticatedUser.UserId;

                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.ModifiedUserId = _authenticatedUser.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.ModifiedUserId = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<AutoIncrement> AutoIncrements { get; set; }
        public virtual DbSet<ProcessTask> ProcessTasks { get; set; }

        public virtual DbSet<LabourSkill> LabourSkills { get; set; }

        public virtual DbSet<RecipeUnit> RecipeUnits { get; set; }

        public virtual DbSet<Concentrate> Concentrates { get; set; }

        public virtual DbSet<Shade> Shades { get; set; }

        public virtual DbSet<Zone> Zones { get; set; }

        public virtual DbSet<Formula> Formulas { get; set; }

        public virtual DbSet<FormulaField> FormulaFields { get; set; }

        public virtual DbSet<SewingTaskLib> SewingTaskLibs { get; set; }

        public virtual DbSet<SewingMacroLib> SewingMacroLibs { get; set; }

        public virtual DbSet<SewingMacroLibBOL> SewingMacroLibBOLs { get; set; }

        public virtual DbSet<SewingOperationLib> SewingOperationLibs { get; set; }

        public virtual DbSet<SewingFeatureLib> SewingFeatureLibs { get; set; }

        public virtual DbSet<SewingFeatureLibBOL> SewingFeatureLibBOLs { get; set; }

        public virtual DbSet<SewingOperationLibBOL> SewingOperationLibBOLs { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<RequestDivision> RequestDivisions { get; set; }

        public virtual DbSet<ProcessTemplate> ProcessTemplates { get; set; }

        public virtual DbSet<ProcessTemplateItem> ProcessTemplateItems { get; set; }
        public virtual DbSet<DyeingTBRequest> DyeingTBRequests { get; set; }
        public virtual DbSet<DyeingTBMaterial> DyeingTBMaterials { get; set; }
        public virtual DbSet<DyeingTBRecipe> DyeingTBRecipes { get; set; }
        public virtual DbSet<DyeingTBRequestFile> DyeingTBRequestFiles { get; set; }
        public virtual DbSet<DyeingTBRChemical> DyeingTBRChemicals { get; set; }
        public virtual DbSet<DyeingTBRTask> DyeingTBRTasks { get; set; }
        public virtual DbSet<DyeingTBRChemicalValue> DyeingTBRChemicalValues { get; set; }
        public virtual DbSet<RequestDivisionFile> RequestDivisionFiles { get; set; }
        public virtual DbSet<DyeingTBMaterialColor> DyeingTBMaterialColors { get; set; }
        public virtual DbSet<FolderTree> FolderTrees { get; set; }
        public virtual DbSet<RequestDivisionProcess> RequestDivisionProcesses { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<DCTemplate> DCTemplates { get; set; }
        public virtual DbSet<DCTemplateTask> DCTemplateTasks { get; set; }
        public virtual DbSet<DCTemplateDetail> DCTemplateDetails { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeChemical> RecipeChemicals { get; set; }
        public virtual DbSet<RecipeTask> RecipeTasks { get; set; }
        public virtual DbSet<RequestArticleOutput> RequestArticleOutputs { get; set; }
        public virtual DbSet<RequestArticleInput> RequestArticleInputs { get; set; }
        public virtual DbSet<WeavingIED> WeavingIEDs { get; set; }
        public virtual DbSet<WeavingRouting> WeavingRoutings { get; set; }
        public virtual DbSet<WeavingRusticFabricSpec> WeavingRusticFabricSpecs { get; set; }
        public virtual DbSet<WeavingDetailStructure> WeavingDetailStructures { get; set; }
        public virtual DbSet<WeavingYarn> WeavingYarns { get; set; }
        public virtual DbSet<WeavingRappo> WeavingRappos { get; set; }
        public virtual DbSet<WeavingRappoMark> WeavingRappoMarks { get; set; }
        public virtual DbSet<WeavingBackgroundStyle> WeavingBackgroundStyles { get; set; }
        public virtual DbSet<WeavingBorderStyle> WeavingBorderStyles { get; set; }
        public virtual DbSet<DyeingIED> DyeingIEDs { get; set; }
        public virtual DbSet<DyeingRouting> DyeingRoutings { get; set; }
        public virtual DbSet<DyeingProcessChemical> DyeingProcessChemicals { get; set; }
        public virtual DbSet<KnittingBodyType> KnittingBodyTypes { get; set; }
        public virtual DbSet<KnittingType> KnittingTypes { get; set; }
        public virtual DbSet<KnittingShrinkage> KnittingShrinkages { get; set; }
        public virtual DbSet<KnittingFeeder> KnittingFeeders { get; set; }
        public virtual DbSet<KnittingMachineDiameter> KnittingMachineDiameters { get; set; }
        public virtual DbSet<KnittingIED> KnittingIEDs { get; set; }
        public virtual DbSet<KnittingYarn> KnittingYarns { get; set; }
        public virtual DbSet<KnittingRouting> KnittingRoutings { get; set; }
        public virtual DbSet<KnittingGreige> KnittingGreiges { get; set; }
        public virtual DbSet<SewingIED> SewingIEDs { get; set; }
        public virtual DbSet<SewingRouting> SewingRoutings { get; set; }
        public virtual DbSet<SewingRoutingBOL> SewingRoutingBOLs { get; set; }
        public virtual DbSet<SewingOperationLibResult> SewingOperationLibResults { get; set; }
        public virtual DbSet<SewingBundle> SewingBundles { get; set; }
        public virtual DbSet<SewingEfficiencyProfile> SewingEfficiencyProfiles { get; set; }
        public virtual DbSet<SewingMachineEfficiencyProfile> SewingMachineEfficiencyProfiles { get; set; }
        public virtual DbSet<SewingComponent> SewingComponents { get; set; }
        public virtual DbSet<SewingComponentGroup> SewingComponentGroups { get; set; }
        public virtual DbSet<SewingSubcategoryEfficiency> SewingSubcategoryEfficiencies { get; set; }
        public virtual DbSet<SewingFile> SewingFiles { get; set; }
        public virtual DbSet<KnittingFile> KnittingFiles { get; set; }
        public virtual DbSet<WeavingFile> WeavingFiles { get; set; }
        public virtual DbSet<DyeingFile> DyeingFiles { get; set; }
        public virtual DbSet<WeavingReportSetting> WeavingReportSettings { get; set; }
        public virtual DbSet<WeavingReportSettingDetail> WeavingReportSettingDetails { get; set; }
        public virtual DbSet<WeavingOperation> WeavingOperations { get; set; }
        public virtual DbSet<WeavingOperationInputArticle> WeavingOperationInputArticles { get; set; }
        public virtual DbSet<SewingRate> SewingRates { get; set; }
        public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }
        public virtual DbSet<LiquorRatio> LiquorRatios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoIncrementMappingConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessTaskConfiguration());
            modelBuilder.ApplyConfiguration(new LabourSkillConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeUnitConfiguration());
            modelBuilder.ApplyConfiguration(new ConcentrateConfiguration());
            modelBuilder.ApplyConfiguration(new ShadeConfiguration());
            modelBuilder.ApplyConfiguration(new ZoneConfiguration());
            modelBuilder.ApplyConfiguration(new FormulaConfiguration());
            modelBuilder.ApplyConfiguration(new FormulaFieldConfiguration());
            modelBuilder.ApplyConfiguration(new SewingTaskLibConfiguration());
            modelBuilder.ApplyConfiguration(new SewingMacroLibConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new RequestDivisionConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessTemplateItemConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRequestConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRequestFileConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBMaterialColorConfiguration());
            modelBuilder.ApplyConfiguration(new RequestDivisionFileConfiguration());
            modelBuilder.ApplyConfiguration(new FolderTreeConfiguration());
            modelBuilder.ApplyConfiguration(new SewingFeatureLibConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationLibConfiguration());
            modelBuilder.ApplyConfiguration(new RequestDivisionProcessConfiguration());
            modelBuilder.ApplyConfiguration(new SewingMacroLibBOLConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationLibBOLConfiguration());
            modelBuilder.ApplyConfiguration(new SewingFeatureLibBOLConfiguration());
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LightConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingBackgroundStyleConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingBorderStyleConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRecipeConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRTaskConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRChemicalValueConfiguration());
            modelBuilder.ApplyConfiguration(new DCTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new DCTemplateTaskConfiguration());
            modelBuilder.ApplyConfiguration(new DCTemplateDetailConfiguration());
            modelBuilder.ApplyConfiguration(new RequestArticleOutputConfiguration());
            modelBuilder.ApplyConfiguration(new RequestArticleInputConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingIEDConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingRoutingConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingDetailStructureConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingYarnConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingRusticFabricSpecConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingRappoConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingRappoMarkConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingRappoMatricConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeTaskConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingProcessChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingRoutingConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingIEDConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingBodyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingShrinkageConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingFeederConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingMachineDiameterConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingIEDConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingYarnConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingRoutingConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingGreigeConfiguration());
            modelBuilder.ApplyConfiguration(new SewingIEDConfiguration());
            modelBuilder.ApplyConfiguration(new SewingRoutingConfiguration());
            modelBuilder.ApplyConfiguration(new SewingRoutingBOLConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationLibResultConfiguration());
            modelBuilder.ApplyConfiguration(new SewingEfficiencyProfileConfiguration());
            modelBuilder.ApplyConfiguration(new SewingBundleConfiguration());
            modelBuilder.ApplyConfiguration(new SewingMachineEfficiencyProfileConfiguration());
            modelBuilder.ApplyConfiguration(new SewingComponentConfiguration());
            modelBuilder.ApplyConfiguration(new SewingComponentGroupConfiguration());
            modelBuilder.ApplyConfiguration(new SewingSubcategoryEfficiencyConfiguration());
            modelBuilder.ApplyConfiguration(new SewingFileConfiguration());
            modelBuilder.ApplyConfiguration(new KnittingFileConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingFileConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingFileConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingReportSettingConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingReportSettingDetailConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingOperationConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingOperationInputArticleConfiguration());
            modelBuilder.ApplyConfiguration(new SewingRateConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LiquorRatioConfiguration());
        }
    }
}