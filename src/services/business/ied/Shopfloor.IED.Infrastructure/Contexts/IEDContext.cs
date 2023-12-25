using Microsoft.EntityFrameworkCore;
using Shopfloor.Article.Infrastructure.TypeConfigurations;
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

        public virtual DbSet<DyeingTBRequestFile> DyeingTBRequestFiles { get; set; }
        public virtual DbSet<RequestDivisionFile> RequestDivisionFiles { get; set; }

        public virtual DbSet<DyeingTBMaterialColor> DyeingTBMaterialColors { get; set; }
        public virtual DbSet<FolderTree> FolderTrees { get; set; }
        public virtual DbSet<SewingTask> SewingTasks { get; set; }
        public virtual DbSet<SewingMacro> SewingMacros { get; set; }
        public virtual DbSet<SewingOperation> SewingOperations { get; set; }
        public virtual DbSet<SewingFeature> SewingFeatures { get; set; }
        public virtual DbSet<SewingFeatureBOL> SewingFeatureBOLs { get; set; }
        public virtual DbSet<SewingOperationBOL> SewingOperationBOLs { get; set; }
        public virtual DbSet<SewingMacroBOL> SewingMacroBOLs { get; set; }
        public virtual DbSet<RequestDivisionProcess> RequestDivisionProcesses { get; set; }
        public virtual DbSet<SewingOperationWFX> SewingOperationWFXs { get; set; }
        public virtual DbSet<SewingOperationWFXVersion> SewingOperationWFXVersions { get; set; }
        public virtual DbSet<SewingSubOperationWFX> SewingSubOperationWFXs { get; set; }
        public virtual DbSet<SewingSubOperationWFXResult> SewingSubOperationWFXResults { get; set; }
        public virtual DbSet<SewingSubOperationWFXBOL> SewingSubOperationWFXBOLs { get; set; }
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
        public virtual DbSet<WeavingArticle> WeavingArticles { get; set; }
        public virtual DbSet<WeavingRappoMatric> WeavingRappoMatrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.ApplyConfiguration(new SewingTaskConfiguration());
            modelBuilder.ApplyConfiguration(new SewingMacroConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationConfiguration());
            modelBuilder.ApplyConfiguration(new SewingFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new SewingFeatureBOLConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationBOLConfiguration());
            modelBuilder.ApplyConfiguration(new SewingMacroBOLConfiguration());
            modelBuilder.ApplyConfiguration(new RequestDivisionProcessConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationWFXConfiguration());
            modelBuilder.ApplyConfiguration(new SewingOperationWFXVersionConfiguration());
            modelBuilder.ApplyConfiguration(new SewingSubOperationWFXConfiguration());
            modelBuilder.ApplyConfiguration(new SewingSubOperationWFXReaultConfiguration());
            modelBuilder.ApplyConfiguration(new SewingSubOperationWFXBOLConfiguration());
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LightConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingBackgrounStyleConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingBorderStyleConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRecipeConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRTaskConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRVersionConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new DyeingTBRCValueConfiguration());
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
            modelBuilder.ApplyConfiguration(new WeavingArticleConfiguration());
            modelBuilder.ApplyConfiguration(new WeavingRappoMatricConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeTaskConfiguration());
        }
    }
}