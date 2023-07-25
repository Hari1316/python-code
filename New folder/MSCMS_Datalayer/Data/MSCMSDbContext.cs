using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSCMS_Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MSCMS_BackEnd.Data
{
    public  class MSCMSDbContext : DbContext
    {
        
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MSCMSDbContext(DbContextOptions<MSCMSDbContext> dbContextOptions) : base(dbContextOptions)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public virtual DbSet<AssetsAsset> AssetsAssets { get; set; } = null!;
        public virtual DbSet<AssetsAssetmeasurement> AssetsAssetmeasurements { get; set; } = null!;
        public virtual DbSet<AssetsAssetmodel> AssetsAssetmodels { get; set; } = null!;
        public virtual DbSet<AssetsAssetmodeldatatype> AssetsAssetmodeldatatypes { get; set; } = null!;
        public virtual DbSet<AssetsAssetstatuschange> AssetsAssetstatuschanges { get; set; } = null!;
        public virtual DbSet<AssetsCoupon> AssetsCoupons { get; set; } = null!;
        public virtual DbSet<AssetsCouponmeasurement> AssetsCouponmeasurements { get; set; } = null!;
        public virtual DbSet<AssetsCouponstatuschange> AssetsCouponstatuschanges { get; set; } = null!;
        public virtual DbSet<AssetsDevice> AssetsDevices { get; set; } = null!;
        public virtual DbSet<AssetsErrorlog> AssetsErrorlogs { get; set; } = null!;
        public virtual DbSet<AssetsLivedatum> AssetsLivedata { get; set; } = null!;
        public virtual DbSet<AssetsMimicdiagram> AssetsMimicdiagrams { get; set; } = null!;
        public virtual DbSet<AssetsModbusdatatype> AssetsModbusdatatypes { get; set; } = null!;
        public virtual DbSet<AssetsModbusstoreparameter> AssetsModbusstoreparameters { get; set; } = null!;
        public virtual DbSet<AssetsProbe> AssetsProbes { get; set; } = null!;
        public virtual DbSet<AssetsProbelpr> AssetsProbelprs { get; set; } = null!;
        public virtual DbSet<AssetsProbetype> AssetsProbetypes { get; set; } = null!;
        public virtual DbSet<AssetsProtocol> AssetsProtocols { get; set; } = null!;
        public virtual DbSet<AssetsSerialport> AssetsSerialports { get; set; } = null!;
        public virtual DbSet<AssetsTreemenu> AssetsTreemenus { get; set; } = null!;
        public virtual DbSet<AuthGroup> AuthGroups { get; set; } = null!;
        public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; } = null!;
        public virtual DbSet<AuthPermission> AuthPermissions { get; set; } = null!;
        public virtual DbSet<CorsheadersCorsmodel> CorsheadersCorsmodels { get; set; } = null!;
        public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; } = null!;
        public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; } = null!;
        public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; } = null!;
        public virtual DbSet<DjangoSession> DjangoSessions { get; set; } = null!;
        public virtual DbSet<Oauth2ProviderAccesstoken> Oauth2ProviderAccesstokens { get; set; } = null!;
        public virtual DbSet<Oauth2ProviderApplication> Oauth2ProviderApplications { get; set; } = null!;
        public virtual DbSet<Oauth2ProviderGrant> Oauth2ProviderGrants { get; set; } = null!;
        public virtual DbSet<Oauth2ProviderRefreshtoken> Oauth2ProviderRefreshtokens { get; set; } = null!;
        public virtual DbSet<StaffApplicationconfig> StaffApplicationconfigs { get; set; } = null!;
        public virtual DbSet<StaffApplicationlog> StaffApplicationlogs { get; set; } = null!;
        public virtual DbSet<StaffPasswordhistory> StaffPasswordhistories { get; set; } = null!;
        public virtual DbSet<StaffUser> StaffUsers { get; set; } = null!;
        public virtual DbSet<StaffUserGroup> StaffUserGroups { get; set; } = null!;
        public virtual DbSet<StaffUserUserPermission> StaffUserUserPermissions { get; set; } = null!;
        public virtual DbSet<StaffUsernotification> StaffUsernotifications { get; set; } = null!;
        public virtual DbSet<SystemLicence> SystemLicences { get; set; } = null!;
        public virtual DbSet<SystemSystemconfiguration> SystemSystemconfigurations { get; set; } = null!;
        public virtual DbSet<SystemWebsocketlogging> SystemWebsocketloggings { get; set; } = null!;
        
        public DbSet<LoginResponse> Users { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }


        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Metadata.FindProperty("ModifiedAt") != null)
                {
                    entityEntry.Property("ModifiedAt").CurrentValue = DateTime.UtcNow;
                }
                if (entityEntry.Metadata.FindProperty("CreatedAt") != null)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        //entityEntry.Property("UUID").CurrentValue = Guid.NewGuid();
                        entityEntry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SNS-SYS-037;Database=MSCMS1;User=sa;Password=Test@123;Connection Timeout=300;");
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssetsAsset>(entity =>
            {
                entity.ToTable("assets_asset");

                entity.HasIndex(e => e.AssetModelId, "assets_asset_asset_model_id_2e9f0dfb");

                entity.HasIndex(e => e.DeviceId, "assets_asset_device_id_5f2d868e");

                entity.HasIndex(e => e.LastModifiedUserId, "assets_asset_last_modified_user_id_6454400a");

                entity.HasIndex(e => e.LiveDataId, "assets_asset_live_data_id_a69299e8_uniq")
                    .IsUnique()
                    .HasFilter("([live_data_id] IS NOT NULL)");

                entity.HasIndex(e => e.ModbusStoreCrParamsId, "assets_asset_modbus_store_cr_params_id_2a417cac");

                entity.HasIndex(e => e.ModbusStoreMlParamsId, "assets_asset_modbus_store_ml_params_id_f067b76f");

                entity.HasIndex(e => e.ProbeLprId, "assets_asset_probe_lpr_id_a2be8da8");

                entity.HasIndex(e => e.ProtocolId, "assets_asset_protocol_id_ed0d06df");

                entity.HasIndex(e => e.Uuid, "assets_asset_uuid_e1138e07_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssetModelId).HasColumnName("asset_model_id");

                entity.Property(e => e.Autopolling).HasColumnName("autopolling");

                entity.Property(e => e.CorrosionRateThresholdHigh1).HasColumnName("corrosion_rate_threshold_high_1");

                entity.Property(e => e.CorrosionRateThresholdHigh2).HasColumnName("corrosion_rate_threshold_high_2");

                entity.Property(e => e.CorrosionRateThresholdLow1).HasColumnName("corrosion_rate_threshold_low_1");

                entity.Property(e => e.CorrosionRateThresholdLow2).HasColumnName("corrosion_rate_threshold_low_2");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.DataPollingInterval).HasColumnName("data_polling_interval");

                entity.Property(e => e.DataPollingIntervalStart).HasColumnName("data_polling_interval_start");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.LiveDataId).HasColumnName("live_data_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.MetalLossFormula)
                    .HasMaxLength(255)
                    .HasColumnName("metal_loss_formula");

                entity.Property(e => e.MetalLossThresholdHigh1).HasColumnName("metal_loss_threshold_high_1");

                entity.Property(e => e.MetalLossThresholdHigh2).HasColumnName("metal_loss_threshold_high_2");

                entity.Property(e => e.MetalLossThresholdLow1).HasColumnName("metal_loss_threshold_low_1");

                entity.Property(e => e.MetalLossThresholdLow2).HasColumnName("metal_loss_threshold_low_2");

                entity.Property(e => e.MetalLossUnit)
                    .HasMaxLength(5)
                    .HasColumnName("metal_loss_unit");

                entity.Property(e => e.ModbusStoreCrEnabled).HasColumnName("modbus_store_cr_enabled");

                entity.Property(e => e.ModbusStoreCrParamsId).HasColumnName("modbus_store_cr_params_id");

                entity.Property(e => e.ModbusStoreMlEnabled).HasColumnName("modbus_store_ml_enabled");

                entity.Property(e => e.ModbusStoreMlParamsId).HasColumnName("modbus_store_ml_params_id");

                entity.Property(e => e.Notify).HasColumnName("notify");

                entity.Property(e => e.OpcTag)
                    .HasMaxLength(20)
                    .HasColumnName("opc_tag");

                entity.Property(e => e.ProbeId).HasColumnName("probe_id");

                entity.Property(e => e.ProbeInstallationDate).HasColumnName("probe_installation_date");

                entity.Property(e => e.ProbeLprId).HasColumnName("probe_lpr_id");

                entity.Property(e => e.ProtocolId).HasColumnName("protocol_id");

                entity.Property(e => e.ReportLastDays).HasColumnName("report_last_days");

                entity.Property(e => e.ReportSchedule)
                    .HasMaxLength(6)
                    .HasColumnName("report_schedule");

                entity.Property(e => e.TemperatureCompDataValue).HasColumnName("temperature_comp_data_value");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(130)
                    .HasColumnName("uuid");

                entity.HasOne(d => d.AssetModel)
                    .WithMany(p => p.AssetsAssets)
                    .HasForeignKey(d => d.AssetModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_asset_asset_model_id_2e9f0dfb_fk_assets_assetmodel_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.AssetsAssets)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("assets_asset_device_id_5f2d868e_fk_assets_device_id");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.AssetsAssets)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_asset_last_modified_user_id_6454400a_fk_staff_user_id");

                entity.HasOne(d => d.LiveData)
                    .WithOne(p => p.AssetsAsset)
                    .HasForeignKey<AssetsAsset>(d => d.LiveDataId)
                    .HasConstraintName("assets_asset_live_data_id_a69299e8_fk_assets_livedata_id");

                entity.HasOne(d => d.ModbusStoreCrParams)
                    .WithMany(p => p.AssetsAssetModbusStoreCrParams)
                    .HasForeignKey(d => d.ModbusStoreCrParamsId)
                    .HasConstraintName("assets_asset_modbus_store_cr_params_id_2a417cac_fk_assets_modbusstoreparameters_id");

                entity.HasOne(d => d.ModbusStoreMlParams)
                    .WithMany(p => p.AssetsAssetModbusStoreMlParams)
                    .HasForeignKey(d => d.ModbusStoreMlParamsId)
                    .HasConstraintName("assets_asset_modbus_store_ml_params_id_f067b76f_fk_assets_modbusstoreparameters_id");

                entity.HasOne(d => d.Probe)
                    .WithMany(p => p.AssetsAssets)
                    .HasForeignKey(d => d.ProbeId)
                    .HasConstraintName("assets_asset_probe_id_bb776a4b_fk_assets_probe_id");

                entity.HasOne(d => d.ProbeLpr)
                    .WithMany(p => p.AssetsAssets)
                    .HasForeignKey(d => d.ProbeLprId)
                    .HasConstraintName("assets_asset_probe_lpr_id_a2be8da8_fk_assets_probelpr_id");

                entity.HasOne(d => d.Protocol)
                    .WithMany(p => p.AssetsAssets)
                    .HasForeignKey(d => d.ProtocolId)
                    .HasConstraintName("assets_asset_protocol_id_ed0d06df_fk_assets_protocol_id");

                entity.HasCheckConstraint("CK__assets_as__repor__40F9A68C", "report_last_days >= 0");
            });



            modelBuilder.Entity<AssetsAssetmeasurement>(entity =>
            {
                entity.ToTable("assets_assetmeasurement");

                entity.HasIndex(e => e.AssetId, "assets_assetmeasurement_asset_id_f288a58d");

                entity.HasIndex(e => new { e.AssetId, e.MeasurementTimestampUnix }, "assets_assetmeasurement_asset_id_measurement_timestamp_unix_38517849_idx");

                entity.HasIndex(e => e.CreatedById, "assets_assetmeasurement_created_by_id_8f636a29");

                entity.HasIndex(e => new { e.AssetId, e.MeasurementTimestampUnix }, "idx_assets_assetmeasurement_asset_meas_desc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssetId).HasColumnName("asset_id");

                entity.Property(e => e.CorrosionRate).HasColumnName("corrosion_rate");

                entity.Property(e => e.CreatedById).HasColumnName("created_by_id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.IsManualEntry).HasColumnName("is_manual_entry");

                entity.Property(e => e.LongTermCorrosionRate).HasColumnName("long_term_corrosion_rate");

                entity.Property(e => e.MeasurementTimestamp).HasColumnName("measurement_timestamp");

                entity.Property(e => e.MeasurementTimestampUnix).HasColumnName("measurement_timestamp_unix");

                entity.Property(e => e.MetalLoss).HasColumnName("metal_loss");

                entity.Property(e => e.OpcTag)
                    .HasMaxLength(20)
                    .HasColumnName("opc_tag");

                entity.Property(e => e.RawData).HasColumnName("raw_data");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetsAssetmeasurements)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_assetmeasurement_asset_id_f288a58d_fk_assets_asset_id");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AssetsAssetmeasurements)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("assets_assetmeasurement_created_by_id_8f636a29_fk_staff_user_id");
            });

            modelBuilder.Entity<AssetsAssetmodel>(entity =>
            {
                entity.ToTable("assets_assetmodel");

                entity.HasIndex(e => e.DataTypeId, "assets_assetmodel_data_type_id_7b76e0ff");

                entity.HasIndex(e => e.DataTypeId, "assets_assetmodel_data_type_id_7b76e0ff_idx");

                entity.HasIndex(e => e.ModbusStoreParamsId, "assets_assetmodel_modbus_store_params_id_9c9ce098");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataTypeId).HasColumnName("data_type_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(255)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.MeasurementMethod)
                    .HasMaxLength(10)
                    .HasColumnName("measurement_method");

                entity.Property(e => e.MetalLossFormula)
                    .HasMaxLength(255)
                    .HasColumnName("metal_loss_formula");

                entity.Property(e => e.ModbusStoreParamsId).HasColumnName("modbus_store_params_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");

                entity.Property(e => e.ReadOnly).HasColumnName("read_only");

                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.AssetsAssetmodels)
                    .HasForeignKey(d => d.DataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_assetmodel_data_type_id_7b76e0ff_fk_assets_assetmodeldatatypes_id");

                entity.HasOne(d => d.ModbusStoreParams)
                    .WithMany(p => p.AssetsAssetmodels)
                    .HasForeignKey(d => d.ModbusStoreParamsId)
                    .HasConstraintName("assets_assetmodel_modbus_store_params_id_9c9ce098_fk_assets_modbusstoreparameters_id");

                entity.HasData(
                    new AssetsAssetmodel { Id = 1, Name = "MS 2600E", ReadOnly = true, Deleted = true, MetalLossFormula = "(raw_data - 4) / 16.0 * probe_life", Manufacturer = "Metal Samples", DataTypeId = 1, ModbusStoreParamsId = 1, MeasurementMethod = "ER" },
                    new AssetsAssetmodel { Id = 2, Name = "MS 2700E", ReadOnly = true, Deleted = false, MetalLossFormula = "(raw_data / 65535.0) * probe_life", Manufacturer = "Metal Samples", DataTypeId = 1, ModbusStoreParamsId = 2, MeasurementMethod = "ER" },
                    new AssetsAssetmodel { Id = 3, Name = "MS 2800E", ReadOnly = true, Deleted = true, MetalLossFormula = "(raw_data / 1048575.0) * probe_life", Manufacturer = "Metal Samples", DataTypeId = 1, ModbusStoreParamsId = 3, MeasurementMethod = "ER" },
                    new AssetsAssetmodel { Id = 4, Name = "MS 2801E", ReadOnly = true, Deleted = true, MetalLossFormula = "(raw_data / 1048575.0) * probe_life", Manufacturer = "Metal Samples", DataTypeId = 1, ModbusStoreParamsId = 4, MeasurementMethod = "ER" },
                    new AssetsAssetmodel { Id = 5, Name = "MS 2800E - ME", ReadOnly = true, Deleted = true, MetalLossFormula = "(raw_data / 262144.0) * probe_life", Manufacturer = "Metal Samples", DataTypeId = 1, ModbusStoreParamsId = 5, MeasurementMethod = "ER" },
                    new AssetsAssetmodel { Id = 6, Name = "MT-9485A", ReadOnly = true, Deleted = true, MetalLossFormula = "(raw_data / 262144.0) * probe_life", Manufacturer = "RCS", DataTypeId = 1, MeasurementMethod = "ER" }
                    );
            });

            modelBuilder.Entity<AssetsAssetmodeldatatype>(entity =>
            {
                entity.ToTable("assets_assetmodeldatatypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataType)
                    .HasMaxLength(50)
                    .HasColumnName("data_type");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.HasData(
                    new AssetsAssetmodeldatatype { Id = 1, DataType = "raw_data", Description = "Raw data" },
                    new AssetsAssetmodeldatatype { Id = 2, DataType = "metal_loss", Description = "Metal loss" },
                    new AssetsAssetmodeldatatype { Id = 3, DataType = "corrosion_rate", Description = "Corrosion rate" }
                    );
            });

            modelBuilder.Entity<AssetsAssetstatuschange>(entity =>
            {
                entity.ToTable("assets_assetstatuschange");

                entity.HasIndex(e => e.AssetId, "assets_assetstatuschange_asset_id_ce5a10bb");

                entity.HasIndex(e => e.ErrorLogId, "assets_assetstatuschange_error_log_id_2a13840c");

                entity.HasIndex(e => e.LastMeasurementId, "assets_assetstatuschange_last_measurement_id_3b05f7f0");

                entity.HasIndex(e => e.NextHwId, "assets_assetstatuschange_next_hw_id_55dd8b07");

                entity.HasIndex(e => e.NextLtcrId, "assets_assetstatuschange_next_ltcr_id_acf07a4a");

                entity.HasIndex(e => e.NextMlId, "assets_assetstatuschange_next_ml_id_79480f1a");

                entity.HasIndex(e => e.NextStId, "assets_assetstatuschange_next_st_id_6c6903cc");

                entity.HasIndex(e => e.PreviousId, "assets_assetstatuschange_previous_id_50b56f8a");

                entity.HasIndex(e => e.SeenById, "assets_assetstatuschange_seen_by_id_9cdde098");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlertMailSent).HasColumnName("alert_mail_sent");

                entity.Property(e => e.AssetId).HasColumnName("asset_id");

                entity.Property(e => e.ChangeIn)
                    .HasMaxLength(10)
                    .HasColumnName("change_in");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.ErrorLogId).HasColumnName("error_log_id");

                entity.Property(e => e.HardwareStatus)
                    .HasMaxLength(20)
                    .HasColumnName("hardware_status");

                entity.Property(e => e.LastMeasurementId).HasColumnName("last_measurement_id");

                entity.Property(e => e.LongTermCorrosionRate).HasColumnName("long_term_corrosion_rate");

                entity.Property(e => e.LongTermCorrosionRateStatus)
                    .HasMaxLength(20)
                    .HasColumnName("long_term_corrosion_rate_status");

                entity.Property(e => e.MeasurementTimestamp).HasColumnName("measurement_timestamp");

                entity.Property(e => e.MeasurementTimestampPrev).HasColumnName("measurement_timestamp_prev");

                entity.Property(e => e.MetalLoss).HasColumnName("metal_loss");

                entity.Property(e => e.MetalLossStatus)
                    .HasMaxLength(20)
                    .HasColumnName("metal_loss_status");

                entity.Property(e => e.NextHwId).HasColumnName("next_hw_id");

                entity.Property(e => e.NextLtcrId).HasColumnName("next_ltcr_id");

                entity.Property(e => e.NextMlId).HasColumnName("next_ml_id");

                entity.Property(e => e.NextStId).HasColumnName("next_st_id");

                entity.Property(e => e.PreviousId).HasColumnName("previous_id");

                entity.Property(e => e.Seen).HasColumnName("seen");

                entity.Property(e => e.SeenById).HasColumnName("seen_by_id");

                entity.Property(e => e.SeenOn).HasColumnName("seen_on");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetsAssetstatuschanges)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_assetstatuschange_asset_id_ce5a10bb_fk_assets_asset_id");

                entity.HasOne(d => d.ErrorLog)
                    .WithMany(p => p.AssetsAssetstatuschanges)
                    .HasForeignKey(d => d.ErrorLogId)
                    .HasConstraintName("assets_assetstatuschange_error_log_id_2a13840c_fk_assets_errorlog_id");

                entity.HasOne(d => d.LastMeasurement)
                    .WithMany(p => p.AssetsAssetstatuschanges)
                    .HasForeignKey(d => d.LastMeasurementId)
                    .HasConstraintName("assets_assetstatuschange_last_measurement_id_3b05f7f0_fk_assets_assetmeasurement_id");

                entity.HasOne(d => d.NextHw)
                    .WithMany(p => p.InverseNextHw)
                    .HasForeignKey(d => d.NextHwId)
                    .HasConstraintName("assets_assetstatuschange_next_hw_id_55dd8b07_fk_assets_assetstatuschange_id");

                entity.HasOne(d => d.NextLtcr)
                    .WithMany(p => p.InverseNextLtcr)
                    .HasForeignKey(d => d.NextLtcrId)
                    .HasConstraintName("assets_assetstatuschange_next_ltcr_id_acf07a4a_fk_assets_assetstatuschange_id");

                entity.HasOne(d => d.NextMl)
                    .WithMany(p => p.InverseNextMl)
                    .HasForeignKey(d => d.NextMlId)
                    .HasConstraintName("assets_assetstatuschange_next_ml_id_79480f1a_fk_assets_assetstatuschange_id");

                entity.HasOne(d => d.NextSt)
                    .WithMany(p => p.InverseNextSt)
                    .HasForeignKey(d => d.NextStId)
                    .HasConstraintName("assets_assetstatuschange_next_st_id_6c6903cc_fk_assets_assetstatuschange_id");

                entity.HasOne(d => d.Previous)
                    .WithMany(p => p.InversePrevious)
                    .HasForeignKey(d => d.PreviousId)
                    .HasConstraintName("assets_assetstatuschange_previous_id_50b56f8a_fk_assets_assetstatuschange_id");

                entity.HasOne(d => d.SeenBy)
                    .WithMany(p => p.AssetsAssetstatuschanges)
                    .HasForeignKey(d => d.SeenById)
                    .HasConstraintName("assets_assetstatuschange_seen_by_id_9cdde098_fk_staff_user_id");
            });

            modelBuilder.Entity<AssetsCoupon>(entity =>
            {
                entity.ToTable("assets_coupon");

                entity.HasIndex(e => e.ErrorLogId, "assets_coupon_error_log_id_c63da815");

                entity.HasIndex(e => e.LastMeasurementId, "assets_coupon_last_measurement_id_0a9d3b57");

                entity.HasIndex(e => e.LastModifiedUserId, "assets_coupon_last_modified_user_id_f1435325");

                entity.HasIndex(e => e.ModbusStoreCrParamsId, "assets_coupon_modbus_store_cr_params_id_23c97a04");

                entity.HasIndex(e => e.ModbusStoreMlParamsId, "assets_coupon_modbus_store_ml_params_id_8933ee56");

                entity.HasIndex(e => e.Uuid, "assets_coupon_uuid_f5d1e001_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alloy)
                    .HasMaxLength(50)
                    .HasColumnName("alloy");

                entity.Property(e => e.AlloyDensity).HasColumnName("alloy_density");

                entity.Property(e => e.CorrosionRateStatus)
                    .HasMaxLength(20)
                    .HasColumnName("corrosion_rate_status");

                entity.Property(e => e.CorrosionRateThresholdHigh1).HasColumnName("corrosion_rate_threshold_high_1");

                entity.Property(e => e.CorrosionRateThresholdHigh2).HasColumnName("corrosion_rate_threshold_high_2");

                entity.Property(e => e.CorrosionRateThresholdLow1).HasColumnName("corrosion_rate_threshold_low_1");

                entity.Property(e => e.CorrosionRateThresholdLow2).HasColumnName("corrosion_rate_threshold_low_2");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Diameter).HasColumnName("diameter");

                entity.Property(e => e.DiameterOuter).HasColumnName("diameter_outer");

                entity.Property(e => e.ErrorLogId).HasColumnName("error_log_id");

                entity.Property(e => e.HoleDiameter).HasColumnName("hole_diameter");

                entity.Property(e => e.InitialWeight).HasColumnName("initial_weight");

                entity.Property(e => e.LastMeasurementId).HasColumnName("last_measurement_id");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.MetalLossStatus)
                    .HasMaxLength(20)
                    .HasColumnName("metal_loss_status");

                entity.Property(e => e.MetalLossThresholdHigh1).HasColumnName("metal_loss_threshold_high_1");

                entity.Property(e => e.MetalLossThresholdHigh2).HasColumnName("metal_loss_threshold_high_2");

                entity.Property(e => e.MetalLossThresholdLow1).HasColumnName("metal_loss_threshold_low_1");

                entity.Property(e => e.MetalLossThresholdLow2).HasColumnName("metal_loss_threshold_low_2");

                entity.Property(e => e.ModbusStoreCrEnabled).HasColumnName("modbus_store_cr_enabled");

                entity.Property(e => e.ModbusStoreCrParamsId).HasColumnName("modbus_store_cr_params_id");

                entity.Property(e => e.ModbusStoreMlEnabled).HasColumnName("modbus_store_ml_enabled");

                entity.Property(e => e.ModbusStoreMlParamsId).HasColumnName("modbus_store_ml_params_id");

                entity.Property(e => e.Notify).HasColumnName("notify");

                entity.Property(e => e.NumberOfHoles).HasColumnName("number_of_holes");

                entity.Property(e => e.ReportLastDays).HasColumnName("report_last_days");

                entity.Property(e => e.ReportSchedule)
                    .HasMaxLength(6)
                    .HasColumnName("report_schedule");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Shape)
                    .HasMaxLength(20)
                    .HasColumnName("shape");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.Property(e => e.SurfaceArea).HasColumnName("surface_area");

                entity.Property(e => e.Thickness).HasColumnName("thickness");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(80)
                    .HasColumnName("uuid");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.ErrorLog)
                    .WithMany(p => p.AssetsCoupons)
                    .HasForeignKey(d => d.ErrorLogId)
                    .HasConstraintName("assets_coupon_error_log_id_c63da815_fk_assets_errorlog_id");

                entity.HasOne(d => d.LastMeasurement)
                    .WithMany(p => p.AssetsCoupons)
                    .HasForeignKey(d => d.LastMeasurementId)
                    .HasConstraintName("assets_coupon_last_measurement_id_0a9d3b57_fk_assets_couponmeasurement_id");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.AssetsCoupons)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .HasConstraintName("assets_coupon_last_modified_user_id_f1435325_fk_staff_user_id");

                entity.HasOne(d => d.ModbusStoreCrParams)
                    .WithMany(p => p.AssetsCouponModbusStoreCrParams)
                    .HasForeignKey(d => d.ModbusStoreCrParamsId)
                    .HasConstraintName("assets_coupon_modbus_store_cr_params_id_23c97a04_fk_assets_modbusstoreparameters_id");

                entity.HasOne(d => d.ModbusStoreMlParams)
                    .WithMany(p => p.AssetsCouponModbusStoreMlParams)
                    .HasForeignKey(d => d.ModbusStoreMlParamsId)
                    .HasConstraintName("assets_coupon_modbus_store_ml_params_id_8933ee56_fk_assets_modbusstoreparameters_id");

                entity.HasCheckConstraint("assets_coupon_number_of_holes_b37dae0a_check", "number_of_holes >= 0");

                entity.HasCheckConstraint("assets_coupon_sequence_26eac502_check", "sequence >= 0");

                entity.HasCheckConstraint("CK__assets_co__repor__42E1EEFE", "report_last_days >= 0");
            });

            modelBuilder.Entity<AssetsCouponmeasurement>(entity =>
            {
                entity.ToTable("assets_couponmeasurement");

                entity.HasIndex(e => e.CouponId, "assets_couponmeasurement_coupon_id_49c8dc85");

                entity.HasIndex(e => e.LastModifiedUserId, "assets_couponmeasurement_last_modified_user_id_4469b1e9");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CorrosionRate).HasColumnName("corrosion_rate");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FinalWeight).HasColumnName("final_weight");

                entity.Property(e => e.InstallTst).HasColumnName("install_tst");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.MetalLoss).HasColumnName("metal_loss");

                entity.Property(e => e.RemovalTst).HasColumnName("removal_tst");

                entity.Property(e => e.TotalExposure).HasColumnName("total_exposure");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.AssetsCouponmeasurements)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_couponmeasurement_coupon_id_49c8dc85_fk_assets_coupon_id");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.AssetsCouponmeasurements)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .HasConstraintName("assets_couponmeasurement_last_modified_user_id_4469b1e9_fk_staff_user_id");
            });

            modelBuilder.Entity<AssetsCouponstatuschange>(entity =>
            {
                entity.ToTable("assets_couponstatuschange");

                entity.HasIndex(e => e.CouponId, "assets_couponstatuschange_coupon_id_b5822675");

                entity.HasIndex(e => e.ErrorLogId, "assets_couponstatuschange_error_log_id_540e2695");

                entity.HasIndex(e => e.LastMeasurementId, "assets_couponstatuschange_last_measurement_id_f387c3be");

                entity.HasIndex(e => e.NextCrId, "assets_couponstatuschange_next_cr_id_fdb5f510");

                entity.HasIndex(e => e.NextMlId, "assets_couponstatuschange_next_ml_id_604b6445");

                entity.HasIndex(e => e.NextStId, "assets_couponstatuschange_next_st_id_d5061662");

                entity.HasIndex(e => e.PreviousId, "assets_couponstatuschange_previous_id_a7c95f6c");

                entity.HasIndex(e => e.SeenById, "assets_couponstatuschange_seen_by_id_4c4b2501");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlertMailSent).HasColumnName("alert_mail_sent");

                entity.Property(e => e.ChangeIn)
                    .HasMaxLength(10)
                    .HasColumnName("change_in");

                entity.Property(e => e.CorrosionRate).HasColumnName("corrosion_rate");

                entity.Property(e => e.CorrosionRateStatus)
                    .HasMaxLength(20)
                    .HasColumnName("corrosion_rate_status");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.ErrorLogId).HasColumnName("error_log_id");

                entity.Property(e => e.LastMeasurementId).HasColumnName("last_measurement_id");

                entity.Property(e => e.MeasurementTimestamp).HasColumnName("measurement_timestamp");

                entity.Property(e => e.MeasurementTimestampPrev).HasColumnName("measurement_timestamp_prev");

                entity.Property(e => e.MetalLoss).HasColumnName("metal_loss");

                entity.Property(e => e.MetalLossStatus)
                    .HasMaxLength(20)
                    .HasColumnName("metal_loss_status");

                entity.Property(e => e.NextCrId).HasColumnName("next_cr_id");

                entity.Property(e => e.NextMlId).HasColumnName("next_ml_id");

                entity.Property(e => e.NextStId).HasColumnName("next_st_id");

                entity.Property(e => e.PreviousId).HasColumnName("previous_id");

                entity.Property(e => e.Seen).HasColumnName("seen");

                entity.Property(e => e.SeenById).HasColumnName("seen_by_id");

                entity.Property(e => e.SeenOn).HasColumnName("seen_on");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.AssetsCouponstatuschanges)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_couponstatuschange_coupon_id_b5822675_fk_assets_coupon_id");

                entity.HasOne(d => d.ErrorLog)
                    .WithMany(p => p.AssetsCouponstatuschanges)
                    .HasForeignKey(d => d.ErrorLogId)
                    .HasConstraintName("assets_couponstatuschange_error_log_id_540e2695_fk_assets_errorlog_id");

                entity.HasOne(d => d.LastMeasurement)
                    .WithMany(p => p.AssetsCouponstatuschanges)
                    .HasForeignKey(d => d.LastMeasurementId)
                    .HasConstraintName("assets_couponstatuschange_last_measurement_id_f387c3be_fk_assets_couponmeasurement_id");

                entity.HasOne(d => d.NextCr)
                    .WithMany(p => p.InverseNextCr)
                    .HasForeignKey(d => d.NextCrId)
                    .HasConstraintName("assets_couponstatuschange_next_cr_id_fdb5f510_fk_assets_couponstatuschange_id");

                entity.HasOne(d => d.NextMl)
                    .WithMany(p => p.InverseNextMl)
                    .HasForeignKey(d => d.NextMlId)
                    .HasConstraintName("assets_couponstatuschange_next_ml_id_604b6445_fk_assets_couponstatuschange_id");

                entity.HasOne(d => d.NextSt)
                    .WithMany(p => p.InverseNextSt)
                    .HasForeignKey(d => d.NextStId)
                    .HasConstraintName("assets_couponstatuschange_next_st_id_d5061662_fk_assets_couponstatuschange_id");

                entity.HasOne(d => d.Previous)
                    .WithMany(p => p.InversePrevious)
                    .HasForeignKey(d => d.PreviousId)
                    .HasConstraintName("assets_couponstatuschange_previous_id_a7c95f6c_fk_assets_couponstatuschange_id");

                entity.HasOne(d => d.SeenBy)
                    .WithMany(p => p.AssetsCouponstatuschanges)
                    .HasForeignKey(d => d.SeenById)
                    .HasConstraintName("assets_couponstatuschange_seen_by_id_4c4b2501_fk_staff_user_id");
            });

            modelBuilder.Entity<AssetsDevice>(entity =>
            {
                entity.ToTable("assets_device");

                entity.HasIndex(e => e.LastModifiedUserId, "assets_device_last_modified_user_id_403a7351");

                entity.HasIndex(e => e.ProtocolId, "assets_device_protocol_id_7fb0a20d");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Baudrate).HasColumnName("baudrate");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Databits).HasColumnName("databits");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Dsrdtr).HasColumnName("dsrdtr");

                entity.Property(e => e.Host)
                    .HasMaxLength(255)
                    .HasColumnName("host");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.Parity)
                    .HasMaxLength(10)
                    .HasColumnName("parity");

                entity.Property(e => e.Port).HasColumnName("port");

                entity.Property(e => e.ProtocolId).HasColumnName("protocol_id");

                entity.Property(e => e.ResponseTimeout).HasColumnName("response_timeout");

                entity.Property(e => e.Rtscts).HasColumnName("rtscts");

                entity.Property(e => e.SerialPort)
                    .HasMaxLength(20)
                    .HasColumnName("serial_port");

                entity.Property(e => e.Stopbits).HasColumnName("stopbits");

                entity.Property(e => e.Xonxoff).HasColumnName("xonxoff");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.AssetsDevices)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_device_last_modified_user_id_403a7351_fk_staff_user_id");

                entity.HasOne(d => d.Protocol)
                    .WithMany(p => p.AssetsDevices)
                    .HasForeignKey(d => d.ProtocolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_device_protocol_id_7fb0a20d_fk_assets_protocol_id");
            });

            modelBuilder.Entity<AssetsErrorlog>(entity =>
            {
                entity.ToTable("assets_errorlog");

                entity.HasIndex(e => e.AssetId, "assets_errorlog_asset_id_22998d5d");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssetId).HasColumnName("asset_id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetsErrorlogs)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_errorlog_asset_id_22998d5d_fk_assets_asset_id");
            });

            modelBuilder.Entity<AssetsLivedatum>(entity =>
            {
                entity.ToTable("assets_livedata");

                entity.HasIndex(e => e.ErrorLogId, "assets_livedata_error_log_id_7b83dd28");

                entity.HasIndex(e => e.LastMeasurementId, "assets_livedata_last_measurement_id_bc4b3c66");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ErrorLogId).HasColumnName("error_log_id");

                entity.Property(e => e.HardwareStatus)
                    .HasMaxLength(20)
                    .HasColumnName("hardware_status");

                entity.Property(e => e.LastMeasurementId).HasColumnName("last_measurement_id");

                entity.Property(e => e.LastMeasurementTimestampUnix).HasColumnName("last_measurement_timestamp_unix");

                entity.Property(e => e.LongTermCorrosionRate).HasColumnName("long_term_corrosion_rate");

                entity.Property(e => e.LongTermCorrosionRateStatus)
                    .HasMaxLength(20)
                    .HasColumnName("long_term_corrosion_rate_status");

                entity.Property(e => e.MetalLoss).HasColumnName("metal_loss");

                entity.Property(e => e.MetalLossStatus)
                    .HasMaxLength(20)
                    .HasColumnName("metal_loss_status");

                entity.Property(e => e.ShortTermCorrosionRate).HasColumnName("short_term_corrosion_rate");

                entity.Property(e => e.ShortTermCorrosionRateStatus)
                    .HasMaxLength(20)
                    .HasColumnName("short_term_corrosion_rate_status");

                entity.Property(e => e.SkipNotifyLtcr).HasColumnName("skip_notify_ltcr");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.HasOne(d => d.ErrorLog)
                    .WithMany(p => p.AssetsLivedata)
                    .HasForeignKey(d => d.ErrorLogId)
                    .HasConstraintName("assets_livedata_error_log_id_7b83dd28_fk_assets_errorlog_id");

                entity.HasOne(d => d.LastMeasurement)
                    .WithMany(p => p.AssetsLivedata)
                    .HasForeignKey(d => d.LastMeasurementId)
                    .HasConstraintName("assets_livedata_last_measurement_id_bc4b3c66_fk_assets_assetmeasurement_id");
            });

            modelBuilder.Entity<AssetsMimicdiagram>(entity =>
            {
                entity.ToTable("assets_mimicdiagram");

                entity.HasIndex(e => e.Name, "UQ__assets_m__72E12F1BA2714DA2")
                    .IsUnique();

                entity.HasIndex(e => e.LastModifiedUserId, "assets_mimicdiagram_last_modified_user_id_f95470a0");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Diagram).HasColumnName("diagram");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.AssetsMimicdiagrams)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .HasConstraintName("assets_mimicdiagram_last_modified_user_id_f95470a0_fk_staff_user_id");
            });

            modelBuilder.Entity<AssetsModbusdatatype>(entity =>
            {
                entity.ToTable("assets_modbusdatatypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataType)
                    .HasMaxLength(50)
                    .HasColumnName("data_type");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.HasData(
                    new AssetsModbusdatatype { Id = 1, DataType = "INT16", Description = "Signed integer, 16 bit" },
                    new AssetsModbusdatatype { Id = 2, DataType = "INT32", Description = "Signed integer, 32 bit" },
                    new AssetsModbusdatatype { Id = 3, DataType = "UINT16", Description = "Unsigned integer, 16 bit" },
                    new AssetsModbusdatatype { Id = 4, DataType = "UINT32", Description = "Unsigned integer, 32 bit" },
                    new AssetsModbusdatatype { Id = 5, DataType = "FLOAT32", Description = "Float number, 32 bit (single precision)" },
                    new AssetsModbusdatatype { Id = 6, DataType = "FLOAT16", Description = "Float number, 16 bit (half precision)" }
                    );
            });

            modelBuilder.Entity<AssetsModbusstoreparameter>(entity =>
            {
                entity.ToTable("assets_modbusstoreparameters");

                entity.HasIndex(e => e.ModbusDataTypeId, "assets_modbusstoreparameters_modbus_data_type_id_e09ff40f");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Byteorder)
                    .HasMaxLength(2)
                    .HasColumnName("byteorder");

                entity.Property(e => e.HighValueRegisterAddress).HasColumnName("high_value_register_address");

                entity.Property(e => e.LowValueRegisterAddress).HasColumnName("low_value_register_address");

                entity.Property(e => e.ModbusDataTypeId).HasColumnName("modbus_data_type_id");

                entity.Property(e => e.ScalingFactor).HasColumnName("scaling_factor");

                entity.Property(e => e.Wordorder)
                    .HasMaxLength(2)
                    .HasColumnName("wordorder");

                entity.HasOne(d => d.ModbusDataType)
                    .WithMany(p => p.AssetsModbusstoreparameters)
                    .HasForeignKey(d => d.ModbusDataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_modbusstoreparameters_modbus_data_type_id_e09ff40f_fk_assets_modbusdatatypes_id");

                entity.HasData(
                   new AssetsModbusstoreparameter { Id = 1, Byteorder = "BE", Wordorder = "LE", HighValueRegisterAddress = 40025, LowValueRegisterAddress = 40024, ScalingFactor = 1, ModbusDataTypeId = 4 },
                   new AssetsModbusstoreparameter { Id = 2, Byteorder = "BE", Wordorder = "LE", HighValueRegisterAddress = 40025, LowValueRegisterAddress = 40024, ScalingFactor = 1, ModbusDataTypeId = 4 },
                   new AssetsModbusstoreparameter { Id = 3, Byteorder = "BE", Wordorder = "LE", HighValueRegisterAddress = 40025, LowValueRegisterAddress = 40024, ScalingFactor = 1, ModbusDataTypeId = 4 },
                   new AssetsModbusstoreparameter { Id = 4, Byteorder = "BE", Wordorder = "LE", HighValueRegisterAddress = 40025, LowValueRegisterAddress = 40024, ScalingFactor = 1, ModbusDataTypeId = 4 },
                   new AssetsModbusstoreparameter { Id = 5, Byteorder = "BE", Wordorder = "LE", HighValueRegisterAddress = 40025, LowValueRegisterAddress = 40024, ScalingFactor = 1, ModbusDataTypeId = 4 }
                   );

                entity.HasCheckConstraint("assets_modbusstoreparameters_scaling_factor_692e675d_check", "scaling_factor >= 0");
            });

            modelBuilder.Entity<AssetsProbe>(entity =>
            {
                entity.ToTable("assets_probe");

                entity.HasIndex(e => e.ProbeTypeId, "assets_probe_probe_type_id_58b72880");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ElementId)
                    .HasMaxLength(80)
                    .HasColumnName("element_id");

                entity.Property(e => e.ProbeLife).HasColumnName("probe_life");

                entity.Property(e => e.ProbeTypeId).HasColumnName("probe_type_id");

                entity.Property(e => e.ReadOnly).HasColumnName("read_only");

                entity.Property(e => e.Thickness).HasColumnName("thickness");

                entity.HasOne(d => d.ProbeType)
                    .WithMany(p => p.AssetsProbes)
                    .HasForeignKey(d => d.ProbeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assets_probe_probe_type_id_58b72880_fk_assets_probetype_id");

                entity.HasData(
                  new AssetsProbe { Id = 1, ElementId = "WR40", Thickness = 40, ProbeLife = 10, ReadOnly = true, Deleted = false, ProbeTypeId = 1 },
                  new AssetsProbe { Id = 2, ElementId = "WR80", Thickness = 80, ProbeLife = 20, ReadOnly = true, Deleted = false, ProbeTypeId = 1 },
                  new AssetsProbe { Id = 3, ElementId = "TU04", Thickness = 4, ProbeLife = 2, ReadOnly = true, Deleted = false, ProbeTypeId = 2 },
                  new AssetsProbe { Id = 4, ElementId = "TU08", Thickness = 8, ProbeLife = 4, ReadOnly = true, Deleted = false, ProbeTypeId = 2 },
                  new AssetsProbe { Id = 5, ElementId = "SL05", Thickness = 5, ProbeLife = 1.25, ReadOnly = true, Deleted = false, ProbeTypeId = 3 },
                  new AssetsProbe { Id = 6, ElementId = "SL10", Thickness = 10, ProbeLife = 2.5, ReadOnly = true, Deleted = false, ProbeTypeId = 3 },
                  new AssetsProbe { Id = 7, ElementId = "CT10", Thickness = 10, ProbeLife = 5, ReadOnly = true, Deleted = false, ProbeTypeId = 4 },
                  new AssetsProbe { Id = 8, ElementId = "CT20", Thickness = 20, ProbeLife = 10, ReadOnly = true, Deleted = false, ProbeTypeId = 4 },
                  new AssetsProbe { Id = 9, ElementId = "CT50", Thickness = 50, ProbeLife = 25, ReadOnly = true, Deleted = false, ProbeTypeId = 4 },
                  new AssetsProbe { Id = 10, ElementId = "SP10", Thickness = 10, ProbeLife = 5, ReadOnly = true, Deleted = false, ProbeTypeId = 5 },
                  new AssetsProbe { Id = 11, ElementId = "SP20", Thickness = 20, ProbeLife = 10, ReadOnly = true, Deleted = false, ProbeTypeId = 5 },
                  new AssetsProbe { Id = 12, ElementId = "FS04", Thickness = 4, ProbeLife = 2, ReadOnly = true, Deleted = false, ProbeTypeId = 6 },
                  new AssetsProbe { Id = 13, ElementId = "FS08", Thickness = 8, ProbeLife = 4, ReadOnly = true, Deleted = false, ProbeTypeId = 6 },
                  new AssetsProbe { Id = 14, ElementId = "FS20", Thickness = 20, ProbeLife = 10, ReadOnly = true, Deleted = false, ProbeTypeId = 6 },
                  new AssetsProbe { Id = 15, ElementId = "FL05", Thickness = 5, ProbeLife = 2.5, ReadOnly = true, Deleted = false, ProbeTypeId = 7 },
                  new AssetsProbe { Id = 16, ElementId = "FL10", Thickness = 10, ProbeLife = 5, ReadOnly = true, Deleted = false, ProbeTypeId = 7 },
                  new AssetsProbe { Id = 17, ElementId = "FL20", Thickness = 20, ProbeLife = 10, ReadOnly = true, Deleted = false, ProbeTypeId = 7 },
                  new AssetsProbe { Id = 18, ElementId = "FL40", Thickness = 40, ProbeLife = 20, ReadOnly = true, Deleted = false, ProbeTypeId = 7 },
                  new AssetsProbe { Id = 19, ElementId = "SS10", Thickness = 10, ProbeLife = 5, ReadOnly = true, Deleted = false, ProbeTypeId = 8 },
                  new AssetsProbe { Id = 20, ElementId = "SS20", Thickness = 20, ProbeLife = 10, ReadOnly = true, Deleted = false, ProbeTypeId = 8 },
                  new AssetsProbe { Id = 21, ElementId = "SS40", Thickness = 40, ProbeLife = 20, ReadOnly = true, Deleted = false, ProbeTypeId = 8 }

                  );
            });

            modelBuilder.Entity<AssetsProbelpr>(entity =>
            {
                entity.ToTable("assets_probelpr");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");

                entity.Property(e => e.ReadOnly).HasColumnName("read_only");

                entity.HasData(
                  new AssetsProbelpr { Id = 1, Name = "LP1000", Description = "\"Plug Type\" Fixed Length, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 2, Name = "LP6000", Description = "Fixed Length with Flange, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 3, Name = "LP1100", Description = "\"Plug Type\" Fixed Length, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 4, Name = "LP6100", Description = "Fixed Length with Flange, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 5, Name = "LP2000", Description = "\"Rod Type\" Fixed Length, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 6, Name = "LP2100", Description = "\"Rod Type\" Fixed Length, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 7, Name = "LP7000", Description = "Retrievable, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 8, Name = "LP7100", Description = "Retrievable, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 9, Name = "LP3000", Description = "Adjustable Length, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 10, Name = "LP7210", Description = "Retrievable, Flush-Mount, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 11, Name = "LP3010", Description = "Adjustable Length Epoxy Probe, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 12, Name = "LP3100", Description = "Adjustable Length, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 13, Name = "LP4000", Description = "Retractable, 2 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 14, Name = "LP4100", Description = "Retractable, 3 Electrodes", ReadOnly = true, Deleted = false },
                  new AssetsProbelpr { Id = 15, Name = "LP4300", Description = "Retractable, 3 Electrodes, CorrTran Style", ReadOnly = true, Deleted = false }

                  );
            });

            modelBuilder.Entity<AssetsProbetype>(entity =>
            {
                entity.ToTable("assets_probetype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ReadOnly).HasColumnName("read_only");

                entity.Property(e => e.Type)
                    .HasMaxLength(80)
                    .HasColumnName("type");

                entity.HasData(
                  new AssetsProbetype { Id = 1, Type = "Wire Loop", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 2, Type = "Tube loop", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 3, Type = "Strip loop", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 4, Type = "Cylindrical", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 5, Type = "Spiral loop", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 6, Type = "Flush (small)", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 7, Type = "Flush (large)", ReadOnly = true, Deleted = false },
                  new AssetsProbetype { Id = 8, Type = "Surface Strip", ReadOnly = true, Deleted = false }
                );
            });

            modelBuilder.Entity<AssetsProtocol>(entity =>
            {
                entity.ToTable("assets_protocol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(50)
                    .HasColumnName("code_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasData(
                  new AssetsProtocol { Id = 1, Name = "Modbus TCP/IP", CodeName = "MODBUS_TCPIP" },
                  new AssetsProtocol { Id = 2, Name = "Modbus ASCII", CodeName = "MODBUS_ASCII" },
                  new AssetsProtocol { Id = 3, Name = "Serial ASCII", CodeName = "SERIAL_ASCII" },
                  new AssetsProtocol { Id = 4, Name = "Modbus RTU", CodeName = "MODBUS_RTU" }
                );
            });

            modelBuilder.Entity<AssetsSerialport>(entity =>
            {
                entity.ToTable("assets_serialport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ports).HasColumnName("ports");

                entity.HasData(
                  new AssetsSerialport { Id = 1, Ports = "[]" }
                );
            });

            modelBuilder.Entity<AssetsTreemenu>(entity =>
            {
                entity.ToTable("assets_treemenu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TreeJson).HasColumnName("tree_json");

                entity.HasData(
                 new AssetsTreemenu { Id = 1, TreeJson = "[]" }
               );
            });

            modelBuilder.Entity<AuthGroup>(entity =>
            {
                entity.ToTable("auth_group");

                entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.HasData(
                  new AuthGroup { Id = 1, Name = "USER" },
                  new AuthGroup { Id = 2, Name = "ENGINEER" },
                  new AuthGroup { Id = 3, Name = "ADMIN" },
                  new AuthGroup { Id = 4, Name = "SYSTEM_ADMIN" }
                );
            });

            modelBuilder.Entity<AuthGroupPermission>(entity =>
            {
                entity.ToTable("auth_group_permissions");

                entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

                entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                    .IsUnique()
                    .HasFilter("([group_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

                entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id");


                entity.HasData(
                  new AuthGroupPermission { Id = 1, GroupId = 1, PermissionId = 4 },
                  new AuthGroupPermission { Id = 2, GroupId = 1, PermissionId = 8 },
                  new AuthGroupPermission { Id = 3, GroupId = 1, PermissionId = 16 },
                  new AuthGroupPermission { Id = 4, GroupId = 1, PermissionId = 20 },
                  new AuthGroupPermission { Id = 5, GroupId = 1, PermissionId = 24 },
                  new AuthGroupPermission { Id = 6, GroupId = 1, PermissionId = 28 },
                  new AuthGroupPermission { Id = 7, GroupId = 1, PermissionId = 32 },
                  new AuthGroupPermission { Id = 8, GroupId = 1, PermissionId = 36 },
                  new AuthGroupPermission { Id = 9, GroupId = 1, PermissionId = 40 },
                  new AuthGroupPermission { Id = 10, GroupId = 1, PermissionId = 44 },
                  new AuthGroupPermission { Id = 11, GroupId = 1, PermissionId = 48 },
                  new AuthGroupPermission { Id = 12, GroupId = 1, PermissionId = 52 },
                  new AuthGroupPermission { Id = 13, GroupId = 1, PermissionId = 56 },
                  new AuthGroupPermission { Id = 14, GroupId = 1, PermissionId = 60 },
                  new AuthGroupPermission { Id = 15, GroupId = 1, PermissionId = 64 },
                  new AuthGroupPermission { Id = 16, GroupId = 1, PermissionId = 68 },
                  new AuthGroupPermission { Id = 17, GroupId = 1, PermissionId = 72 },
                  new AuthGroupPermission { Id = 18, GroupId = 1, PermissionId = 76 },
                  new AuthGroupPermission { Id = 19, GroupId = 1, PermissionId = 80 },
                  new AuthGroupPermission { Id = 20, GroupId = 1, PermissionId = 84 },

                  new AuthGroupPermission { Id = 21, GroupId = 1, PermissionId = 88 },
                  new AuthGroupPermission { Id = 22, GroupId = 1, PermissionId = 92 },
                  new AuthGroupPermission { Id = 23, GroupId = 1, PermissionId = 96 },
                  new AuthGroupPermission { Id = 24, GroupId = 1, PermissionId = 100 },
                  new AuthGroupPermission { Id = 25, GroupId = 1, PermissionId = 104 },
                  new AuthGroupPermission { Id = 26, GroupId = 1, PermissionId = 108 },
                  new AuthGroupPermission { Id = 27, GroupId = 1, PermissionId = 110 },
                  new AuthGroupPermission { Id = 28, GroupId = 1, PermissionId = 112 },
                  new AuthGroupPermission { Id = 29, GroupId = 1, PermissionId = 114 },
                  new AuthGroupPermission { Id = 30, GroupId = 1, PermissionId = 116 },
                  new AuthGroupPermission { Id = 31, GroupId = 1, PermissionId = 120 },
                  new AuthGroupPermission { Id = 32, GroupId = 1, PermissionId = 132 },
                  new AuthGroupPermission { Id = 33, GroupId = 1, PermissionId = 144 },
                  new AuthGroupPermission { Id = 34, GroupId = 1, PermissionId = 145 },
                  new AuthGroupPermission { Id = 35, GroupId = 1, PermissionId = 146 },
                  new AuthGroupPermission { Id = 36, GroupId = 1, PermissionId = 147 },
                  new AuthGroupPermission { Id = 37, GroupId = 1, PermissionId = 148 },
                  new AuthGroupPermission { Id = 38, GroupId = 1, PermissionId = 152 },

                    new AuthGroupPermission { Id = 39, GroupId = 2, PermissionId = 4 },//2
                    new AuthGroupPermission { Id = 40, GroupId = 2, PermissionId = 8 },
                    new AuthGroupPermission { Id = 41, GroupId = 2, PermissionId = 16 },
                    new AuthGroupPermission { Id = 42, GroupId = 2, PermissionId = 20 },
                    new AuthGroupPermission { Id = 43, GroupId = 2, PermissionId = 24 },
                    new AuthGroupPermission { Id = 44, GroupId = 2, PermissionId = 28 },
                    new AuthGroupPermission { Id = 45, GroupId = 2, PermissionId = 32 },
                    new AuthGroupPermission { Id = 46, GroupId = 2, PermissionId = 36 },
                    new AuthGroupPermission { Id = 47, GroupId = 2, PermissionId = 40 },
                    new AuthGroupPermission { Id = 48, GroupId = 2, PermissionId = 41 },
                    new AuthGroupPermission { Id = 49, GroupId = 2, PermissionId = 42 },
                    new AuthGroupPermission { Id = 50, GroupId = 2, PermissionId = 43 },
                    new AuthGroupPermission { Id = 51, GroupId = 2, PermissionId = 44 },
                    new AuthGroupPermission { Id = 52, GroupId = 2, PermissionId = 45 },
                    new AuthGroupPermission { Id = 53, GroupId = 2, PermissionId = 46 },
                    new AuthGroupPermission { Id = 54, GroupId = 2, PermissionId = 47 },
                    new AuthGroupPermission { Id = 55, GroupId = 2, PermissionId = 48 },
                    new AuthGroupPermission { Id = 56, GroupId = 2, PermissionId = 49 },
                    new AuthGroupPermission { Id = 57, GroupId = 2, PermissionId = 50 },
                    new AuthGroupPermission { Id = 58, GroupId = 2, PermissionId = 51 },
                    new AuthGroupPermission { Id = 59, GroupId = 2, PermissionId = 52 },
                    new AuthGroupPermission { Id = 60, GroupId = 2, PermissionId = 53 },

                    new AuthGroupPermission { Id = 61, GroupId = 2, PermissionId = 54 },
                    new AuthGroupPermission { Id = 62, GroupId = 2, PermissionId = 55 },
                    new AuthGroupPermission { Id = 63, GroupId = 2, PermissionId = 56 },
                    new AuthGroupPermission { Id = 64, GroupId = 2, PermissionId = 60 },
                    new AuthGroupPermission { Id = 65, GroupId = 2, PermissionId = 61 },
                    new AuthGroupPermission { Id = 66, GroupId = 2, PermissionId = 62 },
                    new AuthGroupPermission { Id = 67, GroupId = 2, PermissionId = 63 },
                    new AuthGroupPermission { Id = 68, GroupId = 2, PermissionId = 64 },
                    new AuthGroupPermission { Id = 69, GroupId = 2, PermissionId = 65 },
                    new AuthGroupPermission { Id = 70, GroupId = 2, PermissionId = 66 },

                    new AuthGroupPermission { Id = 71, GroupId = 2, PermissionId = 67 },
                    new AuthGroupPermission { Id = 72, GroupId = 2, PermissionId = 68 },
                    new AuthGroupPermission { Id = 73, GroupId = 2, PermissionId = 72 },
                    new AuthGroupPermission { Id = 74, GroupId = 2, PermissionId = 74 },
                    new AuthGroupPermission { Id = 75, GroupId = 2, PermissionId = 76 },
                    new AuthGroupPermission { Id = 76, GroupId = 2, PermissionId = 78 },
                    new AuthGroupPermission { Id = 77, GroupId = 2, PermissionId = 80 },
                    new AuthGroupPermission { Id = 78, GroupId = 2, PermissionId = 84 },
                    new AuthGroupPermission { Id = 79, GroupId = 2, PermissionId = 88 },
                    new AuthGroupPermission { Id = 80, GroupId = 2, PermissionId = 92 },
                    new AuthGroupPermission { Id = 81, GroupId = 2, PermissionId = 93 },
                    new AuthGroupPermission { Id = 82, GroupId = 2, PermissionId = 94 },
                    new AuthGroupPermission { Id = 83, GroupId = 2, PermissionId = 95 },
                    new AuthGroupPermission { Id = 84, GroupId = 2, PermissionId = 96 },
                    new AuthGroupPermission { Id = 85, GroupId = 2, PermissionId = 97 },
                    new AuthGroupPermission { Id = 86, GroupId = 2, PermissionId = 98 },
                    new AuthGroupPermission { Id = 87, GroupId = 2, PermissionId = 99 },
                    new AuthGroupPermission { Id = 88, GroupId = 2, PermissionId = 100 },
                    new AuthGroupPermission { Id = 89, GroupId = 2, PermissionId = 101 },
                    new AuthGroupPermission { Id = 90, GroupId = 2, PermissionId = 104 },

                    new AuthGroupPermission { Id = 91, GroupId = 2, PermissionId = 105 },
                    new AuthGroupPermission { Id = 92, GroupId = 2, PermissionId = 106 },
                    new AuthGroupPermission { Id = 93, GroupId = 2, PermissionId = 107 },
                    new AuthGroupPermission { Id = 94, GroupId = 2, PermissionId = 108 },
                    new AuthGroupPermission { Id = 95, GroupId = 2, PermissionId = 110 },
                    new AuthGroupPermission { Id = 96, GroupId = 2, PermissionId = 112 },
                    new AuthGroupPermission { Id = 97, GroupId = 2, PermissionId = 114 },
                    new AuthGroupPermission { Id = 98, GroupId = 2, PermissionId = 116 },
                    new AuthGroupPermission { Id = 99, GroupId = 2, PermissionId = 120 },
                    new AuthGroupPermission { Id = 100, GroupId = 2, PermissionId = 124 },

                    new AuthGroupPermission { Id = 101, GroupId = 2, PermissionId = 132 },
                    new AuthGroupPermission { Id = 102, GroupId = 2, PermissionId = 144 },
                    new AuthGroupPermission { Id = 103, GroupId = 2, PermissionId = 145 },
                    new AuthGroupPermission { Id = 104, GroupId = 2, PermissionId = 146 },
                    new AuthGroupPermission { Id = 105, GroupId = 2, PermissionId = 147 },
                    new AuthGroupPermission { Id = 106, GroupId = 2, PermissionId = 148 },
                    new AuthGroupPermission { Id = 107, GroupId = 2, PermissionId = 152 },

                    new AuthGroupPermission { Id = 108, GroupId = 3, PermissionId = 4 },//3
                    new AuthGroupPermission { Id = 109, GroupId = 3, PermissionId = 8 },
                    new AuthGroupPermission { Id = 110, GroupId = 3, PermissionId = 12 },

                    new AuthGroupPermission { Id = 111, GroupId = 3, PermissionId = 16 },
                    new AuthGroupPermission { Id = 112, GroupId = 3, PermissionId = 20 },
                    new AuthGroupPermission { Id = 113, GroupId = 3, PermissionId = 24 },
                    new AuthGroupPermission { Id = 114, GroupId = 3, PermissionId = 28 },
                    new AuthGroupPermission { Id = 115, GroupId = 3, PermissionId = 32 },
                    new AuthGroupPermission { Id = 116, GroupId = 3, PermissionId = 36 },
                    new AuthGroupPermission { Id = 117, GroupId = 3, PermissionId = 40 },
                    new AuthGroupPermission { Id = 118, GroupId = 3, PermissionId = 41 },
                    new AuthGroupPermission { Id = 119, GroupId = 3, PermissionId = 42 },
                    new AuthGroupPermission { Id = 120, GroupId = 3, PermissionId = 43 },

                    new AuthGroupPermission { Id = 121, GroupId = 3, PermissionId = 44 },
                    new AuthGroupPermission { Id = 122, GroupId = 3, PermissionId = 45 },
                    new AuthGroupPermission { Id = 123, GroupId = 3, PermissionId = 46 },
                    new AuthGroupPermission { Id = 124, GroupId = 3, PermissionId = 47 },
                    new AuthGroupPermission { Id = 125, GroupId = 3, PermissionId = 48 },
                    new AuthGroupPermission { Id = 126, GroupId = 3, PermissionId = 49 },
                    new AuthGroupPermission { Id = 127, GroupId = 3, PermissionId = 50 },
                    new AuthGroupPermission { Id = 128, GroupId = 3, PermissionId = 51 },
                    new AuthGroupPermission { Id = 129, GroupId = 3, PermissionId = 52 },
                    new AuthGroupPermission { Id = 130, GroupId = 3, PermissionId = 53 },

                    new AuthGroupPermission { Id = 131, GroupId = 3, PermissionId = 54 },
                    new AuthGroupPermission { Id = 132, GroupId = 3, PermissionId = 55 },
                    new AuthGroupPermission { Id = 133, GroupId = 3, PermissionId = 56 },
                    new AuthGroupPermission { Id = 134, GroupId = 3, PermissionId = 60 },
                    new AuthGroupPermission { Id = 135, GroupId = 3, PermissionId = 61 },
                    new AuthGroupPermission { Id = 136, GroupId = 3, PermissionId = 62 },
                    new AuthGroupPermission { Id = 137, GroupId = 3, PermissionId = 63 },
                    new AuthGroupPermission { Id = 138, GroupId = 3, PermissionId = 64 },
                    new AuthGroupPermission { Id = 139, GroupId = 3, PermissionId = 65 },
                    new AuthGroupPermission { Id = 140, GroupId = 3, PermissionId = 66 },

                    new AuthGroupPermission { Id = 141, GroupId = 3, PermissionId = 67 },
                    new AuthGroupPermission { Id = 142, GroupId = 3, PermissionId = 68 },
                    new AuthGroupPermission { Id = 143, GroupId = 3, PermissionId = 72 },
                    new AuthGroupPermission { Id = 144, GroupId = 3, PermissionId = 74 },
                    new AuthGroupPermission { Id = 145, GroupId = 3, PermissionId = 76 },
                    new AuthGroupPermission { Id = 146, GroupId = 3, PermissionId = 78 },
                    new AuthGroupPermission { Id = 147, GroupId = 3, PermissionId = 80 },
                    new AuthGroupPermission { Id = 148, GroupId = 3, PermissionId = 84 },
                    new AuthGroupPermission { Id = 149, GroupId = 3, PermissionId = 88 },
                    new AuthGroupPermission { Id = 150, GroupId = 3, PermissionId = 92 },

                    new AuthGroupPermission { Id = 151, GroupId = 3, PermissionId = 93 },
                    new AuthGroupPermission { Id = 152, GroupId = 3, PermissionId = 94 },
                    new AuthGroupPermission { Id = 153, GroupId = 3, PermissionId = 95 },
                    new AuthGroupPermission { Id = 154, GroupId = 3, PermissionId = 96 },
                    new AuthGroupPermission { Id = 155, GroupId = 3, PermissionId = 97 },
                    new AuthGroupPermission { Id = 156, GroupId = 3, PermissionId = 98 },
                    new AuthGroupPermission { Id = 157, GroupId = 3, PermissionId = 99 },
                    new AuthGroupPermission { Id = 158, GroupId = 3, PermissionId = 100 },
                    new AuthGroupPermission { Id = 159, GroupId = 3, PermissionId = 101 },
                    new AuthGroupPermission { Id = 160, GroupId = 3, PermissionId = 102 },

                    new AuthGroupPermission { Id = 161, GroupId = 3, PermissionId = 103 },
                    new AuthGroupPermission { Id = 162, GroupId = 3, PermissionId = 104 },
                    new AuthGroupPermission { Id = 163, GroupId = 3, PermissionId = 105 },
                    new AuthGroupPermission { Id = 164, GroupId = 3, PermissionId = 106 },
                    new AuthGroupPermission { Id = 165, GroupId = 3, PermissionId = 107 },
                    new AuthGroupPermission { Id = 166, GroupId = 3, PermissionId = 108 },
                    new AuthGroupPermission { Id = 167, GroupId = 3, PermissionId = 110 },
                    new AuthGroupPermission { Id = 168, GroupId = 3, PermissionId = 112 },
                    new AuthGroupPermission { Id = 169, GroupId = 3, PermissionId = 114 },
                    new AuthGroupPermission { Id = 170, GroupId = 3, PermissionId = 116 },

                    new AuthGroupPermission { Id = 171, GroupId = 3, PermissionId = 120 },
                    new AuthGroupPermission { Id = 172, GroupId = 3, PermissionId = 124 },
                    new AuthGroupPermission { Id = 173, GroupId = 3, PermissionId = 125 },
                    new AuthGroupPermission { Id = 174, GroupId = 3, PermissionId = 126 },
                    new AuthGroupPermission { Id = 175, GroupId = 3, PermissionId = 127 },
                    new AuthGroupPermission { Id = 176, GroupId = 3, PermissionId = 128 },
                    new AuthGroupPermission { Id = 177, GroupId = 3, PermissionId = 132 },
                    new AuthGroupPermission { Id = 178, GroupId = 3, PermissionId = 133 },
                    new AuthGroupPermission { Id = 179, GroupId = 3, PermissionId = 134 },
                    new AuthGroupPermission { Id = 180, GroupId = 3, PermissionId = 135 },

                    new AuthGroupPermission { Id = 181, GroupId = 3, PermissionId = 136 },
                    new AuthGroupPermission { Id = 182, GroupId = 3, PermissionId = 140 },
                    new AuthGroupPermission { Id = 183, GroupId = 3, PermissionId = 144 },
                    new AuthGroupPermission { Id = 184, GroupId = 3, PermissionId = 145 },
                    new AuthGroupPermission { Id = 185, GroupId = 3, PermissionId = 146 },
                    new AuthGroupPermission { Id = 186, GroupId = 3, PermissionId = 147 },
                    new AuthGroupPermission { Id = 187, GroupId = 3, PermissionId = 148 },
                    new AuthGroupPermission { Id = 188, GroupId = 3, PermissionId = 152 },

                    new AuthGroupPermission { Id = 189, GroupId = 4, PermissionId = 1 },//4
                    new AuthGroupPermission { Id = 190, GroupId = 4, PermissionId = 2 },

                    new AuthGroupPermission { Id = 191, GroupId = 4, PermissionId = 3 },
                    new AuthGroupPermission { Id = 192, GroupId = 4, PermissionId = 4 },
                    new AuthGroupPermission { Id = 193, GroupId = 4, PermissionId = 5 },
                    new AuthGroupPermission { Id = 194, GroupId = 4, PermissionId = 6 },
                    new AuthGroupPermission { Id = 195, GroupId = 4, PermissionId = 7 },
                    new AuthGroupPermission { Id = 196, GroupId = 4, PermissionId = 8 },
                    new AuthGroupPermission { Id = 197, GroupId = 4, PermissionId = 9 },
                    new AuthGroupPermission { Id = 198, GroupId = 4, PermissionId = 10 },
                    new AuthGroupPermission { Id = 199, GroupId = 4, PermissionId = 11 },
                    new AuthGroupPermission { Id = 200, GroupId = 4, PermissionId = 12 },

                    new AuthGroupPermission { Id = 201, GroupId = 4, PermissionId = 13 },
                    new AuthGroupPermission { Id = 202, GroupId = 4, PermissionId = 14 },
                    new AuthGroupPermission { Id = 203, GroupId = 4, PermissionId = 15 },
                    new AuthGroupPermission { Id = 204, GroupId = 4, PermissionId = 16 },
                    new AuthGroupPermission { Id = 205, GroupId = 4, PermissionId = 17 },
                    new AuthGroupPermission { Id = 206, GroupId = 4, PermissionId = 18 },
                    new AuthGroupPermission { Id = 207, GroupId = 4, PermissionId = 19 },
                    new AuthGroupPermission { Id = 208, GroupId = 4, PermissionId = 20 },
                    new AuthGroupPermission { Id = 209, GroupId = 4, PermissionId = 21 },
                    new AuthGroupPermission { Id = 210, GroupId = 4, PermissionId = 22 },

                    new AuthGroupPermission { Id = 211, GroupId = 4, PermissionId = 23 },
                    new AuthGroupPermission { Id = 212, GroupId = 4, PermissionId = 24 },
                    new AuthGroupPermission { Id = 213, GroupId = 4, PermissionId = 25 },
                    new AuthGroupPermission { Id = 214, GroupId = 4, PermissionId = 26 },
                    new AuthGroupPermission { Id = 215, GroupId = 4, PermissionId = 27 },
                    new AuthGroupPermission { Id = 216, GroupId = 4, PermissionId = 28 },
                    new AuthGroupPermission { Id = 217, GroupId = 4, PermissionId = 29 },
                    new AuthGroupPermission { Id = 218, GroupId = 4, PermissionId = 30 },
                    new AuthGroupPermission { Id = 219, GroupId = 4, PermissionId = 31 },
                    new AuthGroupPermission { Id = 220, GroupId = 4, PermissionId = 32 },

                    new AuthGroupPermission { Id = 221, GroupId = 4, PermissionId = 33 },
                    new AuthGroupPermission { Id = 222, GroupId = 4, PermissionId = 34 },
                    new AuthGroupPermission { Id = 223, GroupId = 4, PermissionId = 35 },
                    new AuthGroupPermission { Id = 224, GroupId = 4, PermissionId = 36 },
                    new AuthGroupPermission { Id = 225, GroupId = 4, PermissionId = 37 },
                    new AuthGroupPermission { Id = 226, GroupId = 4, PermissionId = 38 },
                    new AuthGroupPermission { Id = 227, GroupId = 4, PermissionId = 39 },
                    new AuthGroupPermission { Id = 228, GroupId = 4, PermissionId = 40 },
                    new AuthGroupPermission { Id = 229, GroupId = 4, PermissionId = 41 },
                    new AuthGroupPermission { Id = 230, GroupId = 4, PermissionId = 42 },

                    new AuthGroupPermission { Id = 231, GroupId = 4, PermissionId = 43 },
                    new AuthGroupPermission { Id = 232, GroupId = 4, PermissionId = 44 },
                    new AuthGroupPermission { Id = 233, GroupId = 4, PermissionId = 45 },
                    new AuthGroupPermission { Id = 234, GroupId = 4, PermissionId = 46 },
                    new AuthGroupPermission { Id = 235, GroupId = 4, PermissionId = 47 },
                    new AuthGroupPermission { Id = 236, GroupId = 4, PermissionId = 48 },
                    new AuthGroupPermission { Id = 237, GroupId = 4, PermissionId = 49 },
                    new AuthGroupPermission { Id = 238, GroupId = 4, PermissionId = 50 },
                    new AuthGroupPermission { Id = 239, GroupId = 4, PermissionId = 51 },
                    new AuthGroupPermission { Id = 240, GroupId = 4, PermissionId = 52 },

                    new AuthGroupPermission { Id = 241, GroupId = 4, PermissionId = 53 },
                    new AuthGroupPermission { Id = 242, GroupId = 4, PermissionId = 54 },
                    new AuthGroupPermission { Id = 243, GroupId = 4, PermissionId = 55 },
                    new AuthGroupPermission { Id = 244, GroupId = 4, PermissionId = 56 },
                    new AuthGroupPermission { Id = 245, GroupId = 4, PermissionId = 57 },
                    new AuthGroupPermission { Id = 246, GroupId = 4, PermissionId = 58 },
                    new AuthGroupPermission { Id = 247, GroupId = 4, PermissionId = 59 },
                    new AuthGroupPermission { Id = 248, GroupId = 4, PermissionId = 60 },
                    new AuthGroupPermission { Id = 249, GroupId = 4, PermissionId = 61 },
                    new AuthGroupPermission { Id = 250, GroupId = 4, PermissionId = 62 },

                    new AuthGroupPermission { Id = 251, GroupId = 4, PermissionId = 63 },
                    new AuthGroupPermission { Id = 252, GroupId = 4, PermissionId = 64 },
                    new AuthGroupPermission { Id = 253, GroupId = 4, PermissionId = 65 },
                    new AuthGroupPermission { Id = 254, GroupId = 4, PermissionId = 66 },
                    new AuthGroupPermission { Id = 255, GroupId = 4, PermissionId = 67 },
                    new AuthGroupPermission { Id = 256, GroupId = 4, PermissionId = 68 },
                    new AuthGroupPermission { Id = 257, GroupId = 4, PermissionId = 69 },
                    new AuthGroupPermission { Id = 258, GroupId = 4, PermissionId = 70 },
                    new AuthGroupPermission { Id = 259, GroupId = 4, PermissionId = 71 },
                    new AuthGroupPermission { Id = 260, GroupId = 4, PermissionId = 72 },

                    new AuthGroupPermission { Id = 261, GroupId = 4, PermissionId = 73 },
                    new AuthGroupPermission { Id = 262, GroupId = 4, PermissionId = 74 },
                    new AuthGroupPermission { Id = 263, GroupId = 4, PermissionId = 75 },
                    new AuthGroupPermission { Id = 264, GroupId = 4, PermissionId = 76 },
                    new AuthGroupPermission { Id = 265, GroupId = 4, PermissionId = 77 },
                    new AuthGroupPermission { Id = 266, GroupId = 4, PermissionId = 78 },
                    new AuthGroupPermission { Id = 267, GroupId = 4, PermissionId = 79 },
                    new AuthGroupPermission { Id = 268, GroupId = 4, PermissionId = 80 },
                    new AuthGroupPermission { Id = 269, GroupId = 4, PermissionId = 81 },
                    new AuthGroupPermission { Id = 270, GroupId = 4, PermissionId = 82 },

                    new AuthGroupPermission { Id = 271, GroupId = 4, PermissionId = 83 },
                    new AuthGroupPermission { Id = 272, GroupId = 4, PermissionId = 84 },
                    new AuthGroupPermission { Id = 273, GroupId = 4, PermissionId = 85 },
                    new AuthGroupPermission { Id = 274, GroupId = 4, PermissionId = 86 },
                    new AuthGroupPermission { Id = 275, GroupId = 4, PermissionId = 87 },
                    new AuthGroupPermission { Id = 276, GroupId = 4, PermissionId = 88 },
                    new AuthGroupPermission { Id = 277, GroupId = 4, PermissionId = 89 },
                    new AuthGroupPermission { Id = 278, GroupId = 4, PermissionId = 90 },
                    new AuthGroupPermission { Id = 279, GroupId = 4, PermissionId = 91 },
                    new AuthGroupPermission { Id = 280, GroupId = 4, PermissionId = 92 },

                    new AuthGroupPermission { Id = 281, GroupId = 4, PermissionId = 93 },
                    new AuthGroupPermission { Id = 282, GroupId = 4, PermissionId = 94 },
                    new AuthGroupPermission { Id = 283, GroupId = 4, PermissionId = 95 },
                    new AuthGroupPermission { Id = 284, GroupId = 4, PermissionId = 96 },
                    new AuthGroupPermission { Id = 285, GroupId = 4, PermissionId = 97 },
                    new AuthGroupPermission { Id = 286, GroupId = 4, PermissionId = 98 },
                    new AuthGroupPermission { Id = 287, GroupId = 4, PermissionId = 99 },
                    new AuthGroupPermission { Id = 288, GroupId = 4, PermissionId = 100 },
                    new AuthGroupPermission { Id = 289, GroupId = 4, PermissionId = 101 },
                    new AuthGroupPermission { Id = 290, GroupId = 4, PermissionId = 102 },

                    new AuthGroupPermission { Id = 291, GroupId = 4, PermissionId = 103 },
                    new AuthGroupPermission { Id = 292, GroupId = 4, PermissionId = 104 },
                    new AuthGroupPermission { Id = 293, GroupId = 4, PermissionId = 105 },
                    new AuthGroupPermission { Id = 294, GroupId = 4, PermissionId = 106 },
                    new AuthGroupPermission { Id = 295, GroupId = 4, PermissionId = 107 },
                    new AuthGroupPermission { Id = 296, GroupId = 4, PermissionId = 108 },
                    new AuthGroupPermission { Id = 297, GroupId = 4, PermissionId = 109 },
                    new AuthGroupPermission { Id = 298, GroupId = 4, PermissionId = 110 },
                    new AuthGroupPermission { Id = 299, GroupId = 4, PermissionId = 111 },
                    new AuthGroupPermission { Id = 300, GroupId = 4, PermissionId = 112 },

                    new AuthGroupPermission { Id = 301, GroupId = 4, PermissionId = 113 },
                    new AuthGroupPermission { Id = 302, GroupId = 4, PermissionId = 114 },
                    new AuthGroupPermission { Id = 303, GroupId = 4, PermissionId = 115 },
                    new AuthGroupPermission { Id = 304, GroupId = 4, PermissionId = 116 },
                    new AuthGroupPermission { Id = 305, GroupId = 4, PermissionId = 117 },
                    new AuthGroupPermission { Id = 306, GroupId = 4, PermissionId = 118 },
                    new AuthGroupPermission { Id = 307, GroupId = 4, PermissionId = 119 },
                    new AuthGroupPermission { Id = 308, GroupId = 4, PermissionId = 120 },
                    new AuthGroupPermission { Id = 309, GroupId = 4, PermissionId = 121 },
                    new AuthGroupPermission { Id = 310, GroupId = 4, PermissionId = 122 },

                    new AuthGroupPermission { Id = 311, GroupId = 4, PermissionId = 123 },
                  new AuthGroupPermission { Id = 312, GroupId = 4, PermissionId = 124 },
                  new AuthGroupPermission { Id = 313, GroupId = 4, PermissionId = 125 },
                  new AuthGroupPermission { Id = 314, GroupId = 4, PermissionId = 126 },
                  new AuthGroupPermission { Id = 315, GroupId = 4, PermissionId = 127 },
                  new AuthGroupPermission { Id = 316, GroupId = 4, PermissionId = 128 },
                  new AuthGroupPermission { Id = 317, GroupId = 4, PermissionId = 129 },
                  new AuthGroupPermission { Id = 318, GroupId = 4, PermissionId = 130 },
                  new AuthGroupPermission { Id = 319, GroupId = 4, PermissionId = 131 },
                  new AuthGroupPermission { Id = 320, GroupId = 4, PermissionId = 132 },

                  new AuthGroupPermission { Id = 321, GroupId = 4, PermissionId = 133 },
                  new AuthGroupPermission { Id = 322, GroupId = 4, PermissionId = 134 },
                  new AuthGroupPermission { Id = 323, GroupId = 4, PermissionId = 135 },
                  new AuthGroupPermission { Id = 324, GroupId = 4, PermissionId = 136 },
                  new AuthGroupPermission { Id = 325, GroupId = 4, PermissionId = 137 },
                  new AuthGroupPermission { Id = 326, GroupId = 4, PermissionId = 138 },
                  new AuthGroupPermission { Id = 327, GroupId = 4, PermissionId = 139 },
                  new AuthGroupPermission { Id = 328, GroupId = 4, PermissionId = 140 },
                  new AuthGroupPermission { Id = 329, GroupId = 4, PermissionId = 141 },
                  new AuthGroupPermission { Id = 330, GroupId = 4, PermissionId = 142 },

                  new AuthGroupPermission { Id = 331, GroupId = 4, PermissionId = 143 },
                  new AuthGroupPermission { Id = 332, GroupId = 4, PermissionId = 144 },
                  new AuthGroupPermission { Id = 333, GroupId = 4, PermissionId = 145 },
                  new AuthGroupPermission { Id = 334, GroupId = 4, PermissionId = 146 },
                  new AuthGroupPermission { Id = 335, GroupId = 4, PermissionId = 147 },
                  new AuthGroupPermission { Id = 336, GroupId = 4, PermissionId = 148 },
                  new AuthGroupPermission { Id = 337, GroupId = 4, PermissionId = 149 },
                  new AuthGroupPermission { Id = 338, GroupId = 4, PermissionId = 150 },
                  new AuthGroupPermission { Id = 339, GroupId = 4, PermissionId = 151 },
                  new AuthGroupPermission { Id = 340, GroupId = 4, PermissionId = 152 }
                  );

            });

            modelBuilder.Entity<AuthPermission>(entity =>
            {
                entity.ToTable("auth_permission");

                entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

                entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                    .IsUnique()
                    .HasFilter("([content_type_id] IS NOT NULL AND [codename] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codename)
                    .HasMaxLength(100)
                    .HasColumnName("codename");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.AuthPermissions)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_content_type_id");

                entity.HasData(
                new AuthPermission { Id = 1, Name = "Can add log entry", ContentTypeId = 1, Codename = "add_logentry" },
                new AuthPermission { Id = 2, Name = "Can change log entry", ContentTypeId = 1, Codename = "change_logentry" },
                new AuthPermission { Id = 3, Name = "Can delete log entry", ContentTypeId = 1, Codename = "delete_logentry" },
                new AuthPermission { Id = 4, Name = "Can view log entry", ContentTypeId = 1, Codename = "view_logentry" },
                new AuthPermission { Id = 5, Name = "Can add permission", ContentTypeId = 2, Codename = "add_permission" },
                new AuthPermission { Id = 6, Name = "Can change permission", ContentTypeId = 2, Codename = "change_permission" },
                new AuthPermission { Id = 7, Name = "Can delete permission", ContentTypeId = 2, Codename = "delete_permission" },
                new AuthPermission { Id = 8, Name = "Can view permission", ContentTypeId = 2, Codename = "view_permission" },
                new AuthPermission { Id = 9, Name = "Can add group", ContentTypeId = 3, Codename = "add_group" },
                new AuthPermission { Id = 10, Name = "Can change group", ContentTypeId = 3, Codename = "change_group" },
                new AuthPermission { Id = 11, Name = "Can delete group", ContentTypeId = 3, Codename = "delete_group" },
                new AuthPermission { Id = 12, Name = "Can view group", ContentTypeId = 3, Codename = "view_group" },//3

                new AuthPermission { Id = 13, Name = "Can add content type", ContentTypeId = 4, Codename = "add_contenttype" },
                new AuthPermission { Id = 14, Name = "Can change content type", ContentTypeId = 4, Codename = "change_contenttype" },
                new AuthPermission { Id = 15, Name = "Can delete content type", ContentTypeId = 4, Codename = "delete_contenttype" },
                new AuthPermission { Id = 16, Name = "Can view content type", ContentTypeId = 4, Codename = "view_contenttype" },

                new AuthPermission { Id = 17, Name = "Can add session", ContentTypeId = 5, Codename = "add_session" },
                new AuthPermission { Id = 18, Name = "Can change session", ContentTypeId = 5, Codename = "change_session" },
                new AuthPermission { Id = 19, Name = "Can delete session", ContentTypeId = 5, Codename = "delete_session" },
                new AuthPermission { Id = 20, Name = "Can view session", ContentTypeId = 5, Codename = "view_session" },//5

                new AuthPermission { Id = 21, Name = "Can add application", ContentTypeId = 6, Codename = "add_application" },
                new AuthPermission { Id = 22, Name = "Can change application", ContentTypeId = 6, Codename = "change_application" },
                new AuthPermission { Id = 23, Name = "Can delete application", ContentTypeId = 6, Codename = "delete_application" },
                new AuthPermission { Id = 24, Name = "Can view application", ContentTypeId = 6, Codename = "view_application" },

                new AuthPermission { Id = 25, Name = "Can add access token", ContentTypeId = 7, Codename = "add_accesstoken" },
                new AuthPermission { Id = 26, Name = "Can change access token", ContentTypeId = 7, Codename = "change_accesstoken" },
                new AuthPermission { Id = 27, Name = "Can delete access token", ContentTypeId = 7, Codename = "delete_accesstoken" },
                new AuthPermission { Id = 28, Name = "Can view access token", ContentTypeId = 7, Codename = "view_accesstoken" },

                new AuthPermission { Id = 29, Name = "Can add grant", ContentTypeId = 8, Codename = "add_grant" },
                new AuthPermission { Id = 30, Name = "Can change grant", ContentTypeId = 8, Codename = "change_grant" },
                new AuthPermission { Id = 31, Name = "Can delete grant", ContentTypeId = 8, Codename = "delete_grant" },
                new AuthPermission { Id = 32, Name = "Can view grant", ContentTypeId = 8, Codename = "view_grant" },

                new AuthPermission { Id = 33, Name = "Can add refresh token", ContentTypeId = 9, Codename = "add_refreshtoken" },
                new AuthPermission { Id = 34, Name = "Can change refresh token", ContentTypeId = 9, Codename = "change_refreshtoken" },
                new AuthPermission { Id = 35, Name = "Can delete refresh token", ContentTypeId = 9, Codename = "delete_refreshtoken" },
                new AuthPermission { Id = 36, Name = "Can view refresh token", ContentTypeId = 9, Codename = "view_refreshtoken" },

                new AuthPermission { Id = 37, Name = "Can add cors model", ContentTypeId = 10, Codename = "add_corsmodel" },
                new AuthPermission { Id = 38, Name = "Can change cors model", ContentTypeId = 10, Codename = "change_corsmodel" },
                new AuthPermission { Id = 39, Name = "Can delete cors model", ContentTypeId = 10, Codename = "delete_corsmodel" },
                new AuthPermission { Id = 40, Name = "Can view cors model", ContentTypeId = 10, Codename = "view_corsmodel" },

                new AuthPermission { Id = 41, Name = "Can add asset", ContentTypeId = 11, Codename = "add_asset" },
                new AuthPermission { Id = 42, Name = "Can change asset", ContentTypeId = 11, Codename = "change_asset" },
                new AuthPermission { Id = 43, Name = "Can delete asset", ContentTypeId = 11, Codename = "delete_asset" },
                new AuthPermission { Id = 44, Name = "Can view asset", ContentTypeId = 11, Codename = "view_asset" },
                new AuthPermission { Id = 45, Name = "Can add asset measurement", ContentTypeId = 12, Codename = "add_assetmeasurement" },
                new AuthPermission { Id = 46, Name = "Can change asset measurement", ContentTypeId = 12, Codename = "change_assetmeasurement" },
                new AuthPermission { Id = 47, Name = "Can delete asset measurement", ContentTypeId = 12, Codename = "delete_assetmeasurement" },
                new AuthPermission { Id = 48, Name = "Can view asset measurement", ContentTypeId = 12, Codename = "view_assetmeasurement" },

                new AuthPermission { Id = 49, Name = "Can add asset model", ContentTypeId = 13, Codename = "add_assetmodel" },
                new AuthPermission { Id = 50, Name = "Can change asset model", ContentTypeId = 13, Codename = "change_assetmodel" },
                new AuthPermission { Id = 51, Name = "Can delete asset model", ContentTypeId = 13, Codename = "delete_assetmodel" },
                new AuthPermission { Id = 52, Name = "Can view asset model", ContentTypeId = 13, Codename = "view_assetmodel" },


                new AuthPermission { Id = 53, Name = "Can add device", ContentTypeId = 14, Codename = "add_device" },
                new AuthPermission { Id = 54, Name = "Can change device", ContentTypeId = 14, Codename = "change_device" },
                new AuthPermission { Id = 55, Name = "Can delete device", ContentTypeId = 14, Codename = "delete_device" },
                new AuthPermission { Id = 56, Name = "Can view device", ContentTypeId = 14, Codename = "view_device" },

                new AuthPermission { Id = 57, Name = "Can add live data", ContentTypeId = 15, Codename = "add_livedata" },
                new AuthPermission { Id = 58, Name = "Can change live data", ContentTypeId = 15, Codename = "change_livedata" },
                new AuthPermission { Id = 59, Name = "Can delete live data", ContentTypeId = 15, Codename = "delete_livedata" },
                new AuthPermission { Id = 60, Name = "Can view live data", ContentTypeId = 15, Codename = "view_livedata" },

                new AuthPermission { Id = 61, Name = "Can add probe", ContentTypeId = 16, Codename = "add_probe" },
                new AuthPermission { Id = 62, Name = "Can change probe", ContentTypeId = 16, Codename = "change_probe" },
                new AuthPermission { Id = 63, Name = "Can delete probe", ContentTypeId = 16, Codename = "delete_probe" },
                new AuthPermission { Id = 64, Name = "Can view probe", ContentTypeId = 16, Codename = "view_probe" },

                new AuthPermission { Id = 65, Name = "Can add probe type", ContentTypeId = 17, Codename = "add_probetype" },
                new AuthPermission { Id = 66, Name = "Can change probe type", ContentTypeId = 17, Codename = "change_probetype" },
                new AuthPermission { Id = 67, Name = "Can delete probe type", ContentTypeId = 17, Codename = "delete_probetype" },
                new AuthPermission { Id = 68, Name = "Can view probe type", ContentTypeId = 17, Codename = "view_probetype" },

                new AuthPermission { Id = 69, Name = "Can add protocol", ContentTypeId = 18, Codename = "add_protocol" },
                new AuthPermission { Id = 70, Name = "Can change protocol", ContentTypeId = 18, Codename = "change_protocol" },
                new AuthPermission { Id = 71, Name = "Can delete protocol", ContentTypeId = 18, Codename = "delete_protocol" },
                new AuthPermission { Id = 72, Name = "Can view protocol", ContentTypeId = 18, Codename = "view_protocol" },

                new AuthPermission { Id = 73, Name = "Can add serial port", ContentTypeId = 19, Codename = "add_serialport" },
                new AuthPermission { Id = 74, Name = "Can change serial port", ContentTypeId = 19, Codename = "change_serialport" },
                new AuthPermission { Id = 75, Name = "Can delete serial port", ContentTypeId = 19, Codename = "delete_serialport" },
                new AuthPermission { Id = 76, Name = "Can view serial port", ContentTypeId = 19, Codename = "view_serialport" },

                new AuthPermission { Id = 77, Name = "Can add tree menu", ContentTypeId = 20, Codename = "add_treemenu" },
                new AuthPermission { Id = 78, Name = "Can change tree menu", ContentTypeId = 20, Codename = "change_treemenu" },
                new AuthPermission { Id = 79, Name = "Can delete tree menu", ContentTypeId = 20, Codename = "delete_treemenu" },
                new AuthPermission { Id = 80, Name = "Can view tree menu", ContentTypeId = 20, Codename = "view_treemenu" },

                new AuthPermission { Id = 81, Name = "Can add error log", ContentTypeId = 21, Codename = "add_errorlog" },
                new AuthPermission { Id = 82, Name = "Can change error log", ContentTypeId = 21, Codename = "change_errorlog" },
                new AuthPermission { Id = 83, Name = "Can delete error log", ContentTypeId = 21, Codename = "delete_errorlog" },
                new AuthPermission { Id = 84, Name = "Can view error log", ContentTypeId = 21, Codename = "view_errorlog" },
                new AuthPermission { Id = 85, Name = "Can add modbus data types", ContentTypeId = 22, Codename = "add_modbusdatatypes" },
                new AuthPermission { Id = 86, Name = "Can change modbus data types", ContentTypeId = 22, Codename = "change_modbusdatatypes" },
                new AuthPermission { Id = 87, Name = "Can delete modbus data types", ContentTypeId = 22, Codename = "delete_modbusdatatypes" },
                new AuthPermission { Id = 88, Name = "Can view modbus data types", ContentTypeId = 22, Codename = "view_modbusdatatypes" },
                new AuthPermission { Id = 89, Name = "Can add asset model data types", ContentTypeId = 23, Codename = "add_assetmodeldatatypes" },
                new AuthPermission { Id = 90, Name = "Can change asset model data types", ContentTypeId = 23, Codename = "change_assetmodeldatatypes" },
                new AuthPermission { Id = 91, Name = "Can delete asset model data types", ContentTypeId = 23, Codename = "delete_assetmodeldatatypes" },
                new AuthPermission { Id = 92, Name = "Can view asset model data types", ContentTypeId = 23, Codename = "view_assetmodeldatatypes" },

                new AuthPermission { Id = 93, Name = "Can add modbus store parameters", ContentTypeId = 24, Codename = "add_modbusstoreparameters" },
                new AuthPermission { Id = 94, Name = "Can change modbus store parameters", ContentTypeId = 24, Codename = "change_modbusstoreparameters" },
                new AuthPermission { Id = 95, Name = "Can delete modbus store parameters", ContentTypeId = 24, Codename = "delete_modbusstoreparameters" },
                new AuthPermission { Id = 96, Name = "Can view modbus store parameters", ContentTypeId = 24, Codename = "view_modbusstoreparameters" },

                new AuthPermission { Id = 97, Name = "Can add coupon", ContentTypeId = 25, Codename = "add_coupon" },
                new AuthPermission { Id = 98, Name = "Can change coupon", ContentTypeId = 25, Codename = "change_coupon" },
                new AuthPermission { Id = 99, Name = "Can delete coupon", ContentTypeId = 25, Codename = "delete_coupon" },
                new AuthPermission { Id = 100, Name = "Can view coupon", ContentTypeId = 25, Codename = "view_coupon" },

                new AuthPermission { Id = 101, Name = "Can add coupon measurement", ContentTypeId = 26, Codename = "add_couponmeasurement" },
                new AuthPermission { Id = 102, Name = "Can change coupon measurement", ContentTypeId = 26, Codename = "change_couponmeasurement" },
                new AuthPermission { Id = 103, Name = "Can delete coupon measurement", ContentTypeId = 26, Codename = "delete_couponmeasurement" },
                new AuthPermission { Id = 104, Name = "Can view coupon measurement", ContentTypeId = 26, Codename = "view_couponmeasurement" },
                new AuthPermission { Id = 105, Name = "Can add mimic diagram", ContentTypeId = 27, Codename = "add_mimicdiagram" },
                new AuthPermission { Id = 106, Name = "Can change mimic diagram", ContentTypeId = 27, Codename = "change_mimicdiagram" },
                new AuthPermission { Id = 107, Name = "Can delete mimic diagram", ContentTypeId = 27, Codename = "delete_mimicdiagram" },
                new AuthPermission { Id = 108, Name = "Can view mimic diagram", ContentTypeId = 27, Codename = "view_mimicdiagram" },

                new AuthPermission { Id = 109, Name = "Can add asset status change", ContentTypeId = 28, Codename = "add_assetstatuschange" },
                new AuthPermission { Id = 110, Name = "Can change asset status change", ContentTypeId = 28, Codename = "change_assetstatuschange" },
                new AuthPermission { Id = 111, Name = "Can delete asset status change", ContentTypeId = 28, Codename = "delete_assetstatuschange" },
                new AuthPermission { Id = 112, Name = "Can view asset status change", ContentTypeId = 28, Codename = "view_assetstatuschange" },

                new AuthPermission { Id = 113, Name = "Can add coupon status change", ContentTypeId = 29, Codename = "add_couponstatuschange" },
                new AuthPermission { Id = 114, Name = "Can change coupon status change", ContentTypeId = 29, Codename = "change_couponstatuschange" },
                new AuthPermission { Id = 115, Name = "Can delete coupon status change", ContentTypeId = 29, Codename = "delete_couponstatuschange" },
                new AuthPermission { Id = 116, Name = "Can view coupon status change", ContentTypeId = 29, Codename = "view_couponstatuschange" },
                new AuthPermission { Id = 117, Name = "Can add probe lpr", ContentTypeId = 30, Codename = "add_probelpr" },
                new AuthPermission { Id = 118, Name = "Can change probe lpr", ContentTypeId = 30, Codename = "change_probelpr" },
                new AuthPermission { Id = 119, Name = "Can delete probe lpr", ContentTypeId = 30, Codename = "delete_probelpr" },
                new AuthPermission { Id = 120, Name = "Can view probe lpr", ContentTypeId = 30, Codename = "view_probelpr" },

                new AuthPermission { Id = 121, Name = "Can add licence", ContentTypeId = 31, Codename = "add_licence" },
                new AuthPermission { Id = 122, Name = "Can change licence", ContentTypeId = 31, Codename = "change_licence" },
                new AuthPermission { Id = 123, Name = "Can delete licence", ContentTypeId = 31, Codename = "delete_licence" },
                new AuthPermission { Id = 124, Name = "Can view licence", ContentTypeId = 31, Codename = "view_licence" },

                new AuthPermission { Id = 125, Name = "Can add system configuration", ContentTypeId = 32, Codename = "add_systemconfiguration" },
                new AuthPermission { Id = 126, Name = "Can change system configuration", ContentTypeId = 32, Codename = "change_systemconfiguration" },
                new AuthPermission { Id = 127, Name = "Can delete system configuration", ContentTypeId = 32, Codename = "delete_systemconfiguration" },
                new AuthPermission { Id = 128, Name = "Can view system configuration", ContentTypeId = 32, Codename = "view_systemconfiguration" },
                new AuthPermission { Id = 129, Name = "Can add web socket logging", ContentTypeId = 33, Codename = "add_websocketlogging" },
                new AuthPermission { Id = 130, Name = "Can change web socket logging", ContentTypeId = 33, Codename = "change_websocketlogging" },
                new AuthPermission { Id = 131, Name = "Can delete web socket logging", ContentTypeId = 33, Codename = "delete_websocketlogging" },
                new AuthPermission { Id = 132, Name = "Can view web socket logging", ContentTypeId = 33, Codename = "view_websocketlogging" },

                new AuthPermission { Id = 133, Name = "Can add user", ContentTypeId = 34, Codename = "add_user" },
                new AuthPermission { Id = 134, Name = "Can change user", ContentTypeId = 34, Codename = "change_user" },
                new AuthPermission { Id = 135, Name = "Can delete user", ContentTypeId = 34, Codename = "delete_user" },
                new AuthPermission { Id = 136, Name = "Can view user", ContentTypeId = 34, Codename = "view_user" },

                new AuthPermission { Id = 137, Name = "Can add application log", ContentTypeId = 35, Codename = "add_applicationlog" },
                new AuthPermission { Id = 138, Name = "Can change application log", ContentTypeId = 35, Codename = "change_applicationlog" },
                new AuthPermission { Id = 139, Name = "Can delete application log", ContentTypeId = 35, Codename = "delete_applicationlog" },
                new AuthPermission { Id = 140, Name = "Can view application log", ContentTypeId = 35, Codename = "view_applicationlog" },

                new AuthPermission { Id = 141, Name = "Can add user notification", ContentTypeId = 36, Codename = "add_usernotification" },
                new AuthPermission { Id = 142, Name = "Can change user notification", ContentTypeId = 36, Codename = "change_usernotification" },
                new AuthPermission { Id = 143, Name = "Can delete user notification", ContentTypeId = 36, Codename = "delete_usernotification" },
                new AuthPermission { Id = 144, Name = "Can view user notification", ContentTypeId = 36, Codename = "view_usernotification" },

                new AuthPermission { Id = 145, Name = "Can add application config", ContentTypeId = 37, Codename = "add_applicationconfig" },
                new AuthPermission { Id = 146, Name = "Can change application config", ContentTypeId = 37, Codename = "change_applicationconfig" },
                new AuthPermission { Id = 147, Name = "Can delete application config", ContentTypeId = 37, Codename = "delete_applicationconfig" },
                new AuthPermission { Id = 148, Name = "Can view application config", ContentTypeId = 37, Codename = "view_applicationconfig" },

                new AuthPermission { Id = 149, Name = "Can add password history", ContentTypeId = 38, Codename = "add_passwordhistory" },
                new AuthPermission { Id = 150, Name = "Can change password history", ContentTypeId = 38, Codename = "change_passwordhistory" },
                new AuthPermission { Id = 151, Name = "Can delete password history", ContentTypeId = 38, Codename = "delete_passwordhistory" },
                new AuthPermission { Id = 152, Name = "Can view password history", ContentTypeId = 38, Codename = "view_passwordhistory" }
                );
            });

            modelBuilder.Entity<CorsheadersCorsmodel>(entity =>
            {
                entity.ToTable("corsheaders_corsmodel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cors)
                    .HasMaxLength(255)
                    .HasColumnName("cors");
            });

            modelBuilder.Entity<DjangoAdminLog>(entity =>
            {
                entity.ToTable("django_admin_log");

                entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

                entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionFlag).HasColumnName("action_flag");

                entity.Property(e => e.ActionTime).HasColumnName("action_time");

                entity.Property(e => e.ChangeMessage).HasColumnName("change_message");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectRepr)
                    .HasMaxLength(200)
                    .HasColumnName("object_repr");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_content_type_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("django_admin_log_user_id_c564eba6_fk_staff_user_id");

                entity.HasCheckConstraint("django_admin_log_action_flag_a8637d59_check", "action_flag > 0");
            });

            modelBuilder.Entity<DjangoContentType>(entity =>
            {
                entity.ToTable("django_content_type");

                entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                    .IsUnique()
                    .HasFilter("([app_label] IS NOT NULL AND [model] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppLabel)
                    .HasMaxLength(100)
                    .HasColumnName("app_label");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.HasData(
                 new DjangoContentType { Id = 1, AppLabel = "admin", Model = "logentry" },
                 new DjangoContentType { Id = 2, AppLabel = "assets", Model = "asset" },
                 new DjangoContentType { Id = 3, AppLabel = "assets", Model = "assetmeasurement" },
                 new DjangoContentType { Id = 4, AppLabel = "assets", Model = "assetmodel" },
                 new DjangoContentType { Id = 5, AppLabel = "assets", Model = "assetmodeldatatypes" },
                 new DjangoContentType { Id = 6, AppLabel = "assets", Model = "assetstatuschange" },
                 new DjangoContentType { Id = 7, AppLabel = "assets", Model = "coupon" },
                 new DjangoContentType { Id = 8, AppLabel = "assets", Model = "couponmeasurement" },
                 new DjangoContentType { Id = 9, AppLabel = "assets", Model = "couponstatuschange" },
                 new DjangoContentType { Id = 10, AppLabel = "assets", Model = "device" },
                 new DjangoContentType { Id = 11, AppLabel = "assets", Model = "errorlog" },
                 new DjangoContentType { Id = 12, AppLabel = "assets", Model = "livedata" },
                 new DjangoContentType { Id = 13, AppLabel = "assets", Model = "mimicdiagram" },
                 new DjangoContentType { Id = 14, AppLabel = "assets", Model = "modbusdatatypes" },
                 new DjangoContentType { Id = 15, AppLabel = "assets", Model = "modbusstoreparameters" },
                 new DjangoContentType { Id = 16, AppLabel = "assets", Model = "probe" },
                 new DjangoContentType { Id = 17, AppLabel = "assets", Model = "probelpr" },
                 new DjangoContentType { Id = 18, AppLabel = "assets", Model = "probetype" },
                 new DjangoContentType { Id = 19, AppLabel = "assets", Model = "protocol" },
                 new DjangoContentType { Id = 20, AppLabel = "assets", Model = "serialport" },
                 new DjangoContentType { Id = 21, AppLabel = "assets", Model = "treemenu" },
                 new DjangoContentType { Id = 22, AppLabel = "auth", Model = "group" },
                 new DjangoContentType { Id = 23, AppLabel = "auth", Model = "permission" },
                 new DjangoContentType { Id = 24, AppLabel = "contenttypes", Model = "contenttype" },
                 new DjangoContentType { Id = 25, AppLabel = "corsheaders", Model = "corsmodel" },
                 new DjangoContentType { Id = 26, AppLabel = "oauth2_provider", Model = "accesstoken" },
                 new DjangoContentType { Id = 27, AppLabel = "oauth2_provider", Model = "application" },
                 new DjangoContentType { Id = 28, AppLabel = "oauth2_provider", Model = "grant" },
                 new DjangoContentType { Id = 29, AppLabel = "oauth2_provider", Model = "refreshtoken" },
                 new DjangoContentType { Id = 30, AppLabel = "sessions", Model = "session" },
                 new DjangoContentType { Id = 31, AppLabel = "staff", Model = "applicationconfig" },
                 new DjangoContentType { Id = 32, AppLabel = "staff", Model = "applicationlog" },
                 new DjangoContentType { Id = 33, AppLabel = "staff", Model = "passwordhistory" },
                 new DjangoContentType { Id = 34, AppLabel = "staff", Model = "user" },
                 new DjangoContentType { Id = 35, AppLabel = "staff", Model = "usernotification" },
                 new DjangoContentType { Id = 36, AppLabel = "system", Model = "licence" },
                 new DjangoContentType { Id = 37, AppLabel = "system", Model = "systemconfiguration" },
                 new DjangoContentType { Id = 38, AppLabel = "system", Model = "websocketlogging" }
                 );
            });

            modelBuilder.Entity<DjangoMigration>(entity =>
            {
                entity.ToTable("django_migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.App)
                    .HasMaxLength(255)
                    .HasColumnName("app");

                entity.Property(e => e.Applied).HasColumnName("applied");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DjangoSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey)
                    .HasName("PK__django_s__B3BA0F1F09BB0663");

                entity.ToTable("django_session");

                entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(40)
                    .HasColumnName("session_key");

                entity.Property(e => e.ExpireDate).HasColumnName("expire_date");

                entity.Property(e => e.SessionData).HasColumnName("session_data");
            });

            modelBuilder.Entity<Oauth2ProviderAccesstoken>(entity =>
            {
                entity.ToTable("oauth2_provider_accesstoken");

                //entity.HasIndex(e => e.Token, "UQ__oauth2_p__CA90DA7A693547B9")
                //    .IsUnique();

                entity.HasIndex(e => e.ApplicationId, "oauth2_provider_accesstoken_application_id_b22886e1");

                entity.HasIndex(e => e.SourceRefreshTokenId, "oauth2_provider_accesstoken_source_refresh_token_id_e66fbc72_uniq")
                    .IsUnique()
                    .HasFilter("([source_refresh_token_id] IS NOT NULL)");

                entity.HasIndex(e => e.UserId, "oauth2_provider_accesstoken_user_id_6e4c9a65");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationId).HasColumnName("application_id");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Expires).HasColumnName("expires");

                entity.Property(e => e.Scope).HasColumnName("scope");

                entity.Property(e => e.SourceRefreshTokenId).HasColumnName("source_refresh_token_id");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");

                entity.Property(e => e.Updated).HasColumnName("updated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Oauth2ProviderAccesstokens)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("oauth2_provider_accesstoken_application_id_b22886e1_fk_oauth2_provider_application_id");

                entity.HasOne(d => d.SourceRefreshToken)
                    .WithOne(p => p.Oauth2ProviderAccesstoken)
                    .HasForeignKey<Oauth2ProviderAccesstoken>(d => d.SourceRefreshTokenId)
                    .HasConstraintName("oauth2_provider_accesstoken_source_refresh_token_id_e66fbc72_fk_oauth2_provider_refreshtoken_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Oauth2ProviderAccesstokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("oauth2_provider_accesstoken_user_id_6e4c9a65_fk_staff_user_id");

                entity.HasData(
                    new Oauth2ProviderAccesstoken { Id = 1, Token = "", Scope = "", ApplicationId = 1, UserId = 2 },
                    new Oauth2ProviderAccesstoken { Id = 2, Token = " ", Scope = "", ApplicationId = 1, UserId = 1 }
                    );

            });

            modelBuilder.Entity<Oauth2ProviderApplication>(entity =>
            {
                entity.ToTable("oauth2_provider_application");

                entity.HasIndex(e => e.ClientId, "UQ__oauth2_p__BF21A42526D4F77E")
                    .IsUnique();

                entity.HasIndex(e => e.ClientSecret, "oauth2_provider_application_client_secret_53133678");

                entity.HasIndex(e => e.UserId, "oauth2_provider_application_user_id_79829054");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorizationGrantType)
                    .HasMaxLength(32)
                    .HasColumnName("authorization_grant_type");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(100)
                    .HasColumnName("client_id");

                entity.Property(e => e.ClientSecret)
                    .HasMaxLength(255)
                    .HasColumnName("client_secret");

                entity.Property(e => e.ClientType)
                    .HasMaxLength(32)
                    .HasColumnName("client_type");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.RedirectUris).HasColumnName("redirect_uris");

                entity.Property(e => e.SkipAuthorization).HasColumnName("skip_authorization");

                entity.Property(e => e.Updated).HasColumnName("updated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Oauth2ProviderApplications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("oauth2_provider_application_user_id_79829054_fk_staff_user_id");

                entity.HasData(
                    new Oauth2ProviderApplication { Id = 1, ClientId = "", RedirectUris = "", ClientType = "Confidential", AuthorizationGrantType = "password", ClientSecret = "", Name = "", UserId = 1, SkipAuthorization = false }
                    );
            });

            modelBuilder.Entity<Oauth2ProviderGrant>(entity =>
            {
                entity.ToTable("oauth2_provider_grant");

                entity.HasIndex(e => e.Code, "UQ__oauth2_p__357D4CF9CEE30AEA")
                    .IsUnique();

                entity.HasIndex(e => e.ApplicationId, "oauth2_provider_grant_application_id_81923564");

                entity.HasIndex(e => e.UserId, "oauth2_provider_grant_user_id_e8f62af8");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationId).HasColumnName("application_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.CodeChallenge)
                    .HasMaxLength(128)
                    .HasColumnName("code_challenge");

                entity.Property(e => e.CodeChallengeMethod)
                    .HasMaxLength(10)
                    .HasColumnName("code_challenge_method");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Expires).HasColumnName("expires");

                entity.Property(e => e.RedirectUri)
                    .HasMaxLength(255)
                    .HasColumnName("redirect_uri");

                entity.Property(e => e.Scope).HasColumnName("scope");

                entity.Property(e => e.Updated).HasColumnName("updated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Oauth2ProviderGrants)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oauth2_provider_grant_application_id_81923564_fk_oauth2_provider_application_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Oauth2ProviderGrants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oauth2_provider_grant_user_id_e8f62af8_fk_staff_user_id");
            });

            modelBuilder.Entity<Oauth2ProviderRefreshtoken>(entity =>
            {
                entity.ToTable("oauth2_provider_refreshtoken");

                entity.HasIndex(e => e.AccessTokenId, "oauth2_provider_refreshtoken_access_token_id_775e84e8_uniq")
                    .IsUnique()
                    .HasFilter("([access_token_id] IS NOT NULL)");

                entity.HasIndex(e => e.ApplicationId, "oauth2_provider_refreshtoken_application_id_2d1c311b");

                entity.HasIndex(e => new { e.Token, e.Revoked }, "oauth2_provider_refreshtoken_token_revoked_af8a5134_uniq")
                    .IsUnique()
                    .HasFilter("([token] IS NOT NULL AND [revoked] IS NOT NULL)");

                entity.HasIndex(e => e.UserId, "oauth2_provider_refreshtoken_user_id_da837fce");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessTokenId).HasColumnName("access_token_id");

                entity.Property(e => e.ApplicationId).HasColumnName("application_id");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Revoked).HasColumnName("revoked");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");

                entity.Property(e => e.Updated).HasColumnName("updated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AccessToken)
                    .WithOne(p => p.Oauth2ProviderRefreshtoken)
                    .HasForeignKey<Oauth2ProviderRefreshtoken>(d => d.AccessTokenId)
                    .HasConstraintName("oauth2_provider_refreshtoken_access_token_id_775e84e8_fk_oauth2_provider_accesstoken_id");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Oauth2ProviderRefreshtokens)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oauth2_provider_refreshtoken_application_id_2d1c311b_fk_oauth2_provider_application_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Oauth2ProviderRefreshtokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oauth2_provider_refreshtoken_user_id_da837fce_fk_staff_user_id");
            });

            modelBuilder.Entity<StaffApplicationconfig>(entity =>
            {
                entity.ToTable("staff_applicationconfig");

                entity.HasIndex(e => e.LastModifiedUserId, "staff_applicationconfig_last_modified_user_id_5f4a673b");

                entity.HasIndex(e => e.UserId, "staff_applicationconfig_user_id_30181d6e");

                entity.HasIndex(e => new { e.UserId, e.Key }, "staff_applicationconfig_user_id_key_fd199e8c_uniq")
                    .IsUnique()
                    .HasFilter("([user_id] IS NOT NULL AND [key] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Key)
                    .HasMaxLength(20)
                    .HasColumnName("key");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.StaffApplicationconfigLastModifiedUsers)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .HasConstraintName("staff_applicationconfig_last_modified_user_id_5f4a673b_fk_staff_user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StaffApplicationconfigUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("staff_applicationconfig_user_id_30181d6e_fk_staff_user_id");

                entity.HasData(
                    new StaffApplicationconfig { Id = 1, Key = "language", Value = "en" },
                    new StaffApplicationconfig { Id = 2, Key = "dateformat", Value = "yyyy-MM-dd hh:mm:ss a" },
                    new StaffApplicationconfig { Id = 3, Key = "mimic-diagram", Value = "{}" },
                    new StaffApplicationconfig { Id = 4, Key = "MAIL_RPT_LAST_DAYS_D", Value = "7" },
                    new StaffApplicationconfig { Id = 5, Key = "MAIL_RPT_LAST_DAYS_W", Value = "7" },
                    new StaffApplicationconfig { Id = 6, Key = "MAIL_RPT_LAST_DAYS_M", Value = "30" },
                    new StaffApplicationconfig { Id = 7, Key = "WDOG_MISSED_READINGS", Value = "3" }

                    );
            });

            modelBuilder.Entity<StaffApplicationlog>(entity =>
            {
                entity.ToTable("staff_applicationlog");

                entity.HasIndex(e => e.Time, "staff_applicationlog_time_fe56c73c");

                entity.HasIndex(e => e.UserId, "staff_applicationlog_user_id_c09d3418");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.Ip)
                    .HasMaxLength(39)
                    .HasColumnName("ip");

                entity.Property(e => e.Method)
                    .HasMaxLength(7)
                    .HasColumnName("method");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");

                entity.Property(e => e.QueryParams)
                    .HasMaxLength(1023)
                    .HasColumnName("query_params");

                entity.Property(e => e.Response).HasColumnName("response");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StaffApplicationlogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("staff_applicationlog_user_id_c09d3418_fk_staff_user_id");
            });

            modelBuilder.Entity<StaffPasswordhistory>(entity =>
            {
                entity.ToTable("staff_passwordhistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<StaffUser>(entity =>
            {
                entity.ToTable("staff_user");

                entity.HasIndex(e => e.Email, "UQ__staff_us__AB6E6164E5FE1FF3")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__staff_us__F3DBC572226366BE")
                    .IsUnique();

                entity.HasIndex(e => e.LastModifiedUserId, "staff_user_last_modified_user_id_a4e9bb13");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.ExpiredTimestamp).HasColumnName("expired_timestamp");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.InvalidLoginAttempts).HasColumnName("invalid_login_attempts");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.IsCollector).HasColumnName("is_collector");

                entity.Property(e => e.IsLockedOut).HasColumnName("is_locked_out");

                entity.Property(e => e.IsStaff).HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.LockedTimestamp).HasColumnName("locked_timestamp");

                entity.Property(e => e.Notify).HasColumnName("notify");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.InverseLastModifiedUser)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .HasConstraintName("staff_user_last_modified_user_id_a4e9bb13_fk_staff_user_id");

                entity.HasData(
                    new StaffUser { Id = 1, Password = "", IsSuperuser = false, Username = "admin", Email = "-", IsActive = true, IsAdmin = false, IsStaff = true, IsCollector = false, PhoneNumber = "", FirstName = "-", LastName = "-", Notify = false, IsLockedOut = false, InvalidLoginAttempts = 0 },
                    new StaffUser { Id = 2, Password = "", IsSuperuser = false, Username = "collector", Email = "not needed", IsActive = true, IsAdmin = false, IsStaff = true, IsCollector = true, PhoneNumber = "not needed", FirstName = "not needed", LastName = "not needed", Notify = false, IsLockedOut = false, InvalidLoginAttempts = 0 }
                    );
            });

            modelBuilder.Entity<StaffUserGroup>(entity =>
            {
                entity.ToTable("staff_user_groups");

                entity.HasIndex(e => e.GroupId, "staff_user_groups_group_id_f268c67d");

                entity.HasIndex(e => e.UserId, "staff_user_groups_user_id_d6a7bab4");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "staff_user_groups_user_id_group_id_7487dd55_uniq")
                    .IsUnique()
                    .HasFilter("([user_id] IS NOT NULL AND [group_id] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StaffUserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_user_groups_group_id_f268c67d_fk_auth_group_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StaffUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_user_groups_user_id_d6a7bab4_fk_staff_user_id");

                entity.HasData(
                    new StaffUserGroup { Id = 1, UserId = 1, GroupId = 4 }
                    );
            });

            modelBuilder.Entity<StaffUserUserPermission>(entity =>
            {
                entity.ToTable("staff_user_user_permissions");

                entity.HasIndex(e => e.PermissionId, "staff_user_user_permissions_permission_id_f36572eb");

                entity.HasIndex(e => e.UserId, "staff_user_user_permissions_user_id_47d1712b");

                entity.HasIndex(e => new { e.UserId, e.PermissionId }, "staff_user_user_permissions_user_id_permission_id_508e3d20_uniq")
                    .IsUnique()
                    .HasFilter("([user_id] IS NOT NULL AND [permission_id] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.StaffUserUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_user_user_permissions_permission_id_f36572eb_fk_auth_permission_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StaffUserUserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_user_user_permissions_user_id_47d1712b_fk_staff_user_id");
            });

            modelBuilder.Entity<StaffUsernotification>(entity =>
            {
                entity.ToTable("staff_usernotification");

                entity.HasIndex(e => e.UserId, "staff_usernotification_user_id_9df782fb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SendEmail).HasColumnName("send_email");

                entity.Property(e => e.SendTextMessage).HasColumnName("send_text_message");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StaffUsernotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_usernotification_user_id_9df782fb_fk_staff_user_id");
            });

            modelBuilder.Entity<SystemLicence>(entity =>
            {
                entity.ToTable("system_licence");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Database)
                    .HasMaxLength(50)
                    .HasColumnName("database");

                entity.Property(e => e.MaxAssets).HasColumnName("max_assets");

                entity.Property(e => e.MaxConcurrentUsers).HasColumnName("max_concurrent_users");

                entity.Property(e => e.MaxUsers).HasColumnName("max_users");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasData(
                        new SystemLicence { Id = 1, Name = "Plant system", MaxUsers = 25, MaxAssets = 255, Database = "", Active = true, MaxConcurrentUsers = 5 },
                        new SystemLicence { Id = 2, Name = "Mini system", MaxUsers = 5, MaxAssets = 32, Database = "", Active = false, MaxConcurrentUsers = 5 },
                        new SystemLicence { Id = 3, Name = "Standalone", MaxUsers = 1, MaxAssets = 1, Database = "", Active = false, MaxConcurrentUsers = 5 }
                    );
            });

            modelBuilder.Entity<SystemSystemconfiguration>(entity =>
            {
                entity.ToTable("system_systemconfiguration");

                entity.HasIndex(e => e.ActiveLicenceId, "system_systemconfiguration_active_licence_id_0d843f01");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveLicenceId).HasColumnName("active_licence_id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.EmailNotificationsEnabled).HasColumnName("email_notifications_enabled");

                entity.Property(e => e.EmailPassword)
                    .HasMaxLength(50)
                    .HasColumnName("email_password");

                entity.Property(e => e.EmailServerAddress)
                    .HasMaxLength(50)
                    .HasColumnName("email_server_address");

                entity.Property(e => e.EmailServerPort).HasColumnName("email_server_port");

                entity.Property(e => e.EmailUsername)
                    .HasMaxLength(50)
                    .HasColumnName("email_username");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.LastModifiedUserId).HasColumnName("last_modified_user_id");

                entity.Property(e => e.PasswordExpiryDuration).HasColumnName("password_expiry_duration");

                entity.Property(e => e.PasswordExpiryNotification).HasColumnName("password_expiry_notification");

                entity.Property(e => e.SmsEmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("sms_email_address");

                entity.Property(e => e.SmsServerAddress)
                    .HasMaxLength(50)
                    .HasColumnName("sms_server_address");

                entity.HasOne(d => d.ActiveLicence)
                    .WithMany(p => p.SystemSystemconfigurations)
                    .HasForeignKey(d => d.ActiveLicenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("system_systemconfiguration_active_licence_id_0d843f01_fk_system_licence_id");

                entity.HasOne(d => d.LastModifiedUser)
                    .WithMany(p => p.SystemSystemconfigurations)
                    .HasForeignKey(d => d.LastModifiedUserId)
                    .HasConstraintName("system_systemconfiguration_last_modified_user_id_58c06626_fk_staff_user_id");

                entity.HasData(
                        new SystemSystemconfiguration { Id = 1, EmailServerAddress = "email_server_address", SmsServerAddress = "sms_server_address", EmailUsername = "email_username", EmailPassword = "email_password", SmsEmailAddress = "sms_email_address", ActiveLicenceId = 1, EmailServerPort = 587, EmailNotificationsEnabled = true, PasswordExpiryDuration = 90, PasswordExpiryNotification = 10 }
                    );
            });

            modelBuilder.Entity<SystemWebsocketlogging>(entity =>
            {
                entity.ToTable("system_websocketlogging");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");

                entity.Property(e => e.Message).HasColumnName("message");
            });

            //OnModelCreating(modelBuilder);
        }

        //public void OnModelCreating(ModelBuilder modelBuilder);
    }
}
