using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cBaseQMS.Core.DAL.Models
{
    public partial class cBaseDevContext : DbContext
    {
        public virtual DbSet<AppParameter> AppParameter { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Equations> Equations { get; set; }
        public virtual DbSet<InputFields> InputFields { get; set; }
        public virtual DbSet<InputFieldsValue> InputFieldsValue { get; set; }
        public virtual DbSet<LocationAttribtes> LocationAttribtes { get; set; }
        public virtual DbSet<LocationMaster> LocationMaster { get; set; }
        public virtual DbSet<MathConstants> MathConstants { get; set; }
        public virtual DbSet<PartAttributes> PartAttributes { get; set; }
        public virtual DbSet<PartMaster> PartMaster { get; set; }
        public virtual DbSet<TestAttributes> TestAttributes { get; set; }
        public virtual DbSet<TestCalculatedFields> TestCalculatedFields { get; set; }
        public virtual DbSet<TestInputs> TestInputs { get; set; }
        public virtual DbSet<TestMaster> TestMaster { get; set; }
        public virtual DbSet<TestMasterMapping> TestMasterMapping { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<UoM> UoM { get; set; }

        // Unable to generate entity type for table 'dbo.ELMAH_Error'. Please see the warning messages.
        public cBaseDevContext(DbContextOptions options) : base(options)
        {

        }
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //        {

        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=POWELLS-DB\SQL2014;Database=cBaseDev;user id=cBase;password=abcd@1234;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppParameter>(entity =>
            {
                entity.HasKey(e => e.AppParamId);

                entity.Property(e => e.AppParamId).HasColumnName("AppParamID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ParamName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParamValue).IsRequired();
            });

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.ComponentId);

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.ComponentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnType("char(3)");
            });

            modelBuilder.Entity<Equations>(entity =>
            {
                entity.HasKey(e => e.EquationId);

                entity.Property(e => e.EquationId).HasColumnName("EquationID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EquationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Equations)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equations_Tests");
            });

            modelBuilder.Entity<InputFields>(entity =>
            {
                entity.HasKey(e => e.InputFieldId);

                entity.Property(e => e.InputFieldId).HasColumnName("InputFieldID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CurrentFieldValue).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.FieldColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.TestInputId).HasColumnName("TestInputID");

                entity.HasOne(d => d.TestInput)
                    .WithMany(p => p.InputFields)
                    .HasForeignKey(d => d.TestInputId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestInputs_InputFields");
            });

            modelBuilder.Entity<InputFieldsValue>(entity =>
            {
                entity.HasKey(e => e.InputFieldValueId);

                entity.Property(e => e.InputFieldValueId).HasColumnName("InputFieldValueID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InputFieldId).HasColumnName("InputFieldID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("numeric(18, 5)");

                entity.HasOne(d => d.InputField)
                    .WithMany(p => p.InputFieldsValue)
                    .HasForeignKey(d => d.InputFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputFields_InputFieldsValue");
            });

            modelBuilder.Entity<LocationAttribtes>(entity =>
            {
                entity.HasKey(e => e.LocAttrId);

                entity.Property(e => e.LocAttrId).HasColumnName("LocAttrID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LocAttrName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MasterLocationId).HasColumnName("MasterLocationID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Uomid).HasColumnName("UOMID");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<LocationMaster>(entity =>
            {
                entity.Property(e => e.LocationMasterId)
                    .HasColumnName("LocationMasterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedTimestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<MathConstants>(entity =>
            {
                entity.HasKey(e => e.ConstantId);

                entity.Property(e => e.ConstantId).HasColumnName("ConstantID");

                entity.Property(e => e.ConstantName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<PartAttributes>(entity =>
            {
                entity.HasKey(e => e.PartAttrId);

                entity.Property(e => e.PartAttrId).HasColumnName("PartAttrID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InputFieldId).HasColumnName("InputFieldID");

                entity.Property(e => e.MaxValue).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.MinValue).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PartAttrName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PartMasterId).HasColumnName("PartMasterID");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.Uomid).HasColumnName("UOMID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.PartAttributes)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartAttributes_Tests");
            });

            modelBuilder.Entity<PartMaster>(entity =>
            {
                entity.Property(e => e.PartMasterId)
                    .HasColumnName("PartMasterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedTimestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestAttributes>(entity =>
            {
                entity.HasKey(e => e.TestAttrId);

                entity.Property(e => e.TestAttrId).HasColumnName("TestAttrID");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestAttributes)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestAttributes_Tests");
            });

            modelBuilder.Entity<TestCalculatedFields>(entity =>
            {
                entity.HasKey(e => e.CalcFieldId);

                entity.Property(e => e.CalcFieldId).HasColumnName("CalcFieldID");

                entity.Property(e => e.Calculation).IsRequired();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestCalculatedFields)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestCalculatedFields_Tests");
            });

            modelBuilder.Entity<TestInputs>(entity =>
            {
                entity.HasKey(e => e.TestInputId);

                entity.Property(e => e.TestInputId).HasColumnName("TestInputID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasColumnType("binary(5000)");

                entity.Property(e => e.InputName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestInputs)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Test_TestInputs");
            });

            modelBuilder.Entity<TestMaster>(entity =>
            {
                entity.Property(e => e.TestMasterId).HasColumnName("TestMasterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestMasterName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TestMasterMapping>(entity =>
            {
                entity.HasKey(e => e.TestMasterMapId);

                entity.Property(e => e.TestMasterMapId).HasColumnName("TestMasterMapID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LocationMasterId).HasColumnName("LocationMasterID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PartMasterId).HasColumnName("PartMasterID");

                entity.Property(e => e.TestMasterId).HasColumnName("TestMasterID");

                entity.HasOne(d => d.LocationMaster)
                    .WithMany(p => p.TestMasterMapping)
                    .HasForeignKey(d => d.LocationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestMasterMapping_LocationMaster");

                entity.HasOne(d => d.PartMaster)
                    .WithMany(p => p.TestMasterMapping)
                    .HasForeignKey(d => d.PartMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestMasterMapping_PartMaster");

                entity.HasOne(d => d.TestMaster)
                    .WithMany(p => p.TestMasterMapping)
                    .HasForeignKey(d => d.TestMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestMasterMapping_TestMasterMapping");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasKey(e => e.TestId);

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Descriptions).HasMaxLength(500);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TestMasterId).HasColumnName("TestMasterID");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TestMaster)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.TestMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestMaster_Tests");
            });

            modelBuilder.Entity<UoM>(entity =>
            {
                entity.Property(e => e.Uomid).HasColumnName("UOMID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Uom)
                    .IsRequired()
                    .HasColumnName("UOM")
                    .HasMaxLength(30);

                entity.Property(e => e.Uomname)
                    .IsRequired()
                    .HasColumnName("UOMName")
                    .HasMaxLength(100);
            });
        }
    }
}
