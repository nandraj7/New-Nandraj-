using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LeadTracker.Core.Entities;


namespace LeadTracker.Infrastructure;

public partial class LeadTrackerContext : DbContext
{
    public LeadTrackerContext()
    {
    }

    public LeadTrackerContext(DbContextOptions<LeadTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=LeadTracker;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("AddressId");

            entity.HasKey(e => e.Id).HasName("PK__Address__7F4FF737758BB134");

            entity.ToTable("Address");

            entity.Property(e => e.AddressDetails)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.State)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Code).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CodeId)
                .HasConstraintName("FK__Address__CodeId__02FC7413");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AddressCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Address__Created__75A278F5");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AddressModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Address__Modifie__76969D2E");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("BranchId");
            entity.HasKey(e => e.Id).HasName("PK__Branch__A1682FC5AAED213D");

            entity.ToTable("Branch");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Code).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CodeId)
                .HasConstraintName("FK__Branch__CodeId__04E4BC85");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BranchCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Branch__CreatedB__778AC167");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.BranchModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Branch__Modified__787EE5A0");

            entity.HasOne(d => d.Org).WithMany(p => p.Branches)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Branch__OrgId__03F0984C");
        });

        modelBuilder.Entity<Code>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("CodeId");
            entity.HasKey(e => e.Id).HasName("PK__Codes__C6DE2C15C940DECF");

            entity.ToTable("Code");

            entity.Property(e => e.CodesGroup)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CodeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Codes__CreatedBy__7D439ABD");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.CodeModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Codes__ModifiedB__7E37BEF6");

            entity.HasOne(d => d.Org).WithMany(p => p.Codes)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Code__OrgId__05D8E0BE");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("UserId");
            entity.HasKey(e => e.Id).HasName("PK__Employee__1788CC4CD8101590");

            entity.ToTable("Employee");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Mpin)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("MPIN");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(250);

            entity.HasOne(d => d.Org).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Employees__OrgId__5535A963");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmployeeRole");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany()
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__EmployeeR__Creat__01142BA1");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany()
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__EmployeeR__Modif__02084FDA");

            entity.HasOne(d => d.Org).WithMany()
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__EmployeeR__OrgId__5CD6CB2B");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__EmployeeR__RoleI__5BE2A6F2");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__EmployeeR__UserI__5AEE82B9");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("OrgId");
            entity.HasKey(e => e.Id).HasName("PK__Organiza__420C9E6CDFD4FD10");

            entity.ToTable("Organisation");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrganisationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Organizat__Creat__73BA3083");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.OrganisationModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Organizat__Modif__74AE54BC");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("PermissionId");
            entity.HasKey(e => e.Id).HasName("PK__Permissi__EFA6FB2F8FA60969");

            entity.ToTable("Permission");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PermissionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Permissio__Creat__7B5B524B");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.PermissionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Permissio__Modif__7C4F7684");

            entity.HasOne(d => d.Org).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Permissio__OrgId__52593CB8");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("RoleId");
            entity.HasKey(e => e.Id).HasName("PK__Roles__8AFACE1AB07AC017");

            entity.ToTable("Role");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RoleCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Roles__CreatedBy__797309D9");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RoleModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__Roles__ModifiedB__7A672E12");

            entity.HasOne(d => d.Org).WithMany(p => p.Roles)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Roles__OrgId__4F7CD00D");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("RolePermissionId");
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__120F46BAEF739DF1");

            entity.ToTable("RolePermission");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RolePermissionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__RolePermi__Creat__7F2BE32F");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RolePermissionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK__RolePermi__Modif__00200768");

            entity.HasOne(d => d.Org).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__RolePermi__OrgId__619B8048");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__60A75C0F");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}