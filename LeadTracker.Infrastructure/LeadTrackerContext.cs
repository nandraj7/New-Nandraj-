﻿using System;
using System.Collections.Generic;
using LeadTracker.API.Entities;
using LeadTracker.API.LeadTracker.API.SQL;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadTracker.API;

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

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<AttendanceApproval> AttendanceApprovals { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Lead> Leads { get; set; }

    public virtual DbSet<LeadSource> LeadSources { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<OrgAttendanceLocation> OrgAttendanceLocations { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }

    public virtual DbSet<Tracker> Trackers { get; set; }

    public virtual DbSet<UserLocation> UserLocations { get; set; }

    public virtual DbSet<VisitTracking> VisitTrackings { get; set; }

    public virtual DbSet<WorkFlow> WorkFlows { get; set; }

    public virtual DbSet<WorkFlowDetail> WorkFlowDetails { get; set; }

    public virtual DbSet<WorkFlowStep> WorkFlowSteps { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    public virtual DbSet<spEnquiryDTO> Enquiries { get; set; }

    public virtual DbSet<spParentAndChildrenDTO> ParentAndChildrenDTOs { get; set; }

    public virtual DbSet<spStepCountDTO> StepCountDTOs { get; set; }

    public virtual DbSet<spParentDTO> ParentDTOs { get; set; }

    public virtual DbSet<TrackerDataDTO> TrackerDataDTOs { get; set; }


    //public virtual DbSet<spGetActivitiesRequestDTO> ActivitiesRequestDTOs { get; set; }
    //spGetTimelineResponseDTO
    public virtual DbSet<spGetActivitiesResponseDTO> ActivitiesResponseDTOs { get; set; }
    public virtual DbSet<spGetMonthlyAttendanceSummaryResponseDTO> spGetMonthlyAttendanceSummaryDTOs { get; set; }
    public virtual DbSet<spGetEmployeeBookingSummaryResponseDTO> spGetEmployeeBookingSummaryDTOs { get; set; }

    public virtual DbSet<spGetTimelineResponseDTO> TimeLineResponseDTOs { get; set; }
    public virtual DbSet<spGetAllAttendanceDTO> spGetAllAttendanceDTOs { get; set; }
    public virtual DbSet<spUpdateAttendanceDTO> spUpdateAttendanceDTOs { get; set; }
    public virtual DbSet<AttendanceDTO> AttendanceDTOs { get; set; }
    public virtual DbSet<VisitStatusDTO> VisitStatusDTOs { get; set; }

    public virtual DbSet<RoutePathResponseDTO> RoutePathResponseDTOs { get; set; }

    public virtual DbSet<Attendance2DTO> Attendance2DTOs { get; set; }

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
                .HasConstraintName("FK__Address__CodeId__54CB950F");
        });


        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("AttendanceId");
            entity.HasKey(e => e.Id).HasName("PK__Attendan__8B69261C3D8C2F97");

            entity.ToTable("Attendance");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LoginDate).HasColumnType("datetime");
            entity.Property(e => e.LoginLatitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LoginLongitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LogoutDate).HasColumnType("datetime");
            entity.Property(e => e.LogoutLatitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LogoutLongitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PunchInStatus).HasMaxLength(250);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.AttendanceApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK_Attendance_Employee");

            entity.HasOne(d => d.User).WithMany(p => p.AttendanceUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Attendanc__UserI__67DE6983");
        });


        modelBuilder.Entity<AttendanceApproval>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ApprovalId");
            entity.HasKey(e => e.Id).HasName("PK__Attendan__328477F4D46DBE5D");

            entity.ToTable("AttendanceApproval");

            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ApproveRequest).WithMany(p => p.AttendanceApprovalApproveRequests)
                .HasForeignKey(d => d.ApproveRequestId)
                .HasConstraintName("FK__Attendanc__Appro__06CD04F7");

            entity.HasOne(d => d.Attendance).WithMany(p => p.AttendanceApprovals)
                .HasForeignKey(d => d.AttendanceId)
                .HasConstraintName("FK__Attendanc__Atten__04E4BC85");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttendanceApprovalEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Attendanc__Emplo__05D8E0BE");
        });

        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("BankDetailId");

            entity.HasKey(e => e.Id).HasName("PK__BankDeta__1741077C4612440E");

            entity.ToTable("BankDetail");

            entity.Property(e => e.AadharCardNumber).HasMaxLength(100);
            entity.Property(e => e.AccountNo).HasMaxLength(100);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(100)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.MobileNumber).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PancardNumber)
                .HasMaxLength(100)
                .HasColumnName("PANCardNumber");

            entity.HasOne(d => d.Employee).WithMany(p => p.BankDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__BankDetai__Emplo__681373AD");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("BookingId");

            entity.HasKey(e => e.Id).HasName("PK__Booking__73951AED520F1265");

            entity.ToTable("Booking");

            entity.Property(e => e.AgreementCost).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BrokerageSlab)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ClientName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ClientPhone)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Wing)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Enquiry).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EnquiryId)
                .HasConstraintName("FK__Booking__Enquiry__58D1301D");

            entity.HasOne(d => d.Project).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Booking__Project__59C55456");
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

            entity.HasOne(d => d.Org).WithMany(p => p.Codes)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Code__OrgId__05D8E0BE");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("DocumentId");
            entity.HasKey(e => e.Id).HasName("PK__Document__1ABEEF0F438FC9F7");

            entity.ToTable("Document");

            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Enquiry).WithMany(p => p.Documents)
                .HasForeignKey(d => d.EnquiryId)
                .HasConstraintName("FK__Document__Enquir__7DCDAAA2");

            entity.HasOne(d => d.ModuleTypeNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ModuleType)
                .HasConstraintName("FK__Document__Module__7FB5F314");

            entity.HasOne(d => d.Org).WithMany(p => p.Documents)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Document__OrgId__5812160E");

            entity.HasOne(d => d.Tracker).WithMany(p => p.Documents)
                .HasForeignKey(d => d.TrackerId)
                .HasConstraintName("FK__Document__Tracke__7EC1CEDB");

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Document__UserId__00AA174D");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.Documents)
                .HasForeignKey(d => d.WorkFlowId)
                .HasConstraintName("FK__Document__WorkFl__02925FBF");

            entity.HasOne(d => d.WorkFlowStep).WithMany(p => p.Documents)
                .HasForeignKey(d => d.WorkFlowStepId)
                .HasConstraintName("FK_Document_WorkFlowStep");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("EducationId");

            entity.HasKey(e => e.Id).HasName("PK__Educatio__4BBE3805D1BF39A8");

            entity.ToTable("Education");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GraduationPercentage).HasMaxLength(100);
            entity.Property(e => e.GraduationType).HasMaxLength(100);
            entity.Property(e => e.GraduationYearOfPassing).HasMaxLength(100);
            entity.Property(e => e.Hscpercentage)
                .HasMaxLength(100)
                .HasColumnName("HSCPercentage");
            entity.Property(e => e.HscyearOfPassing)
                .HasMaxLength(100)
                .HasColumnName("HSCYearOfPassing");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Sscpercentage)
                .HasMaxLength(100)
                .HasColumnName("SSCPercentage");
            entity.Property(e => e.SscyearOfPassing)
                .HasMaxLength(100)
                .HasColumnName("SSCYearOfPassing");

            entity.HasOne(d => d.Employee).WithMany(p => p.Educations)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Education__Emplo__65370702");
        });

        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity.Property(e => e.Id).HasColumnName("EmployeeId");
        //    entity.HasKey(e => e.Id).HasName("PK__Employee__1788CC4CD8101590");

        //    entity.ToTable("Employee");

        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.DeviceId)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.EmailId)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Gender)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Mobile)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        //    entity.Property(e => e.Mpin)
        //        .HasMaxLength(250)
        //        .IsUnicode(false)
        //        .HasColumnName("MPIN");
        //    entity.Property(e => e.Name).HasMaxLength(250);
        //    entity.Property(e => e.Password).HasMaxLength(250);
        //    entity.Property(e => e.UserName).HasMaxLength(250);

        //    entity.HasOne(d => d.Org).WithMany(p => p.Employees)
        //        .HasForeignKey(d => d.OrgId)
        //        .HasConstraintName("FK__Employee__OrgId__5CD6CB2B");

        //    entity.HasOne(d => d.Role).WithMany(p => p.Employees)
        //        .HasForeignKey(d => d.RoleId)
        //        .HasConstraintName("FK__Employee__RoleId__5DCAEF64");
        //});


        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity.Property(e => e.Id).HasColumnName("EmployeeId");

        //    entity.HasKey(e => e.Id).HasName("PK__Employee__1788CC4CD8101590");

        //    entity.ToTable("Employee");

        //    entity.Property(e => e.AadharCardNumber)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.DeviceId)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Dob)
        //        .HasMaxLength(500)
        //        .HasColumnName("DOB");
        //    entity.Property(e => e.Document).IsUnicode(false);
        //    entity.Property(e => e.EmailId)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.EmployeeNumber)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Gender)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Mobile)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);
        //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        //    entity.Property(e => e.Mpin)
        //        .HasMaxLength(250)
        //        .IsUnicode(false)
        //        .HasColumnName("MPIN");
        //    entity.Property(e => e.Name).HasMaxLength(250);
        //    entity.Property(e => e.PancardNumber)
        //        .HasMaxLength(250)
        //        .HasColumnName("PANCardNumber");
        //    entity.Property(e => e.Password).HasMaxLength(250);
        //    entity.Property(e => e.ProfilePhoto).IsUnicode(false);
        //    entity.Property(e => e.UserName).HasMaxLength(250);

        //    entity.HasOne(d => d.Org).WithMany(p => p.Employees)
        //        .HasForeignKey(d => d.OrgId)
        //        .HasConstraintName("FK__Employee__OrgId__5CD6CB2B");

        //    entity.HasOne(d => d.Role).WithMany(p => p.Employees)
        //        .HasForeignKey(d => d.RoleId)
        //        .HasConstraintName("FK__Employee__RoleId__5DCAEF64");
        //});

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("EmployeeId");

            entity.HasKey(e => e.Id).HasName("PK__Employee__1788CC4CD8101590");

            entity.ToTable("Employee");

            entity.Property(e => e.AadharCardNumber).HasMaxLength(100);
            //entity.Property(e => e.Address)
            //    .HasMaxLength(250)
            //    .IsUnicode(false);
            entity.Property(e => e.AlternateNo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.BioMatricCode)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CorrespondanceAddressDetails)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CorrespondancePincode)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CorrespondancePlace)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Designation)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DeviceId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.Doj)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DOJ");
            entity.Property(e => e.EmailId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FatherNameOfEmployee)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
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
            entity.Property(e => e.PancardNumber)
                .HasMaxLength(100)
                .HasColumnName("PANCardNumber");
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.PermanentAdressDetails)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PermanentPincode)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PermanentPlace)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Reference)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Salary)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(250);

            entity.HasOne(d => d.Org).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Employee__OrgId__0E6E26BF");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employee__RoleId__0F624AF8");
        });


        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmployeeRole");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

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

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("HolidayId");
            entity.HasKey(e => e.Id).HasName("PK__Holiday__2D35D57A43BDF8A9");

            entity.ToTable("Holiday");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Day).HasMaxLength(250);
            entity.Property(e => e.HolidayReason).HasMaxLength(250);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Org).WithMany(p => p.Holidays)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Holiday__OrgId__671F4F74");
        });


        modelBuilder.Entity<Lead>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("EnquiryId");
            entity.HasKey(e => e.Id).HasName("PK__Lead__0A019B7DE448629C");


            entity.ToTable("Lead");

            entity.Property(e => e.Budget).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.EnquiryType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FinalRemark)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LeadSource)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LeadSourceProject)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MobNo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Requirement)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.Leads)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK__Lead__AssignedTo__65F62111");

            entity.HasOne(d => d.Org).WithMany(p => p.Leads)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Lead__OrgId__79FD19BE");

            entity.HasOne(d => d.TrackerFlowStep).WithMany(p => p.Leads)
                .HasForeignKey(d => d.TrackerFlowStepId)
                .HasConstraintName("FK_Lead_WorkFlowStep");
        });


        modelBuilder.Entity<LeadSource>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("LeadSourceId");
            entity.HasKey(e => e.Id).HasName("PK__LeadSour__0A019B7D4A5215E9");

            entity.ToTable("LeadSource");

            entity.Property(e => e.Budget).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.EnquiryType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LeadSourceProject)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LeadsSource)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MobNo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Requirement)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("LocationId");
            entity.HasKey(e => e.Id).HasName("PK__Location__E7FEA497B463375E");

            entity.ToTable("Location");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Zone).WithMany(p => p.Locations)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("FK__Location__ZoneId__3C34F16F");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("NotificationId");
            entity.HasKey(e => e.Id).HasName("PK__Notifica__20CF2E123A28C8CC");

            entity.ToTable("Notification");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NotificationText).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.ParentUser).WithMany(p => p.NotificationParentUsers)
                .HasForeignKey(d => d.ParentUserId)
                .HasConstraintName("FK__Notificat__Paren__503BEA1C");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__4F47C5E3");
        });

        modelBuilder.Entity<OrgAttendanceLocation>(entity =>
        {
            entity.HasKey(e => e.OrgLocationId).HasName("PK__OrgAtten__98FA95B190F78330");

            entity.ToTable("OrgAttendanceLocation");

            entity.Property(e => e.Latitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Org).WithMany(p => p.OrgAttendanceLocations)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__OrgAttend__OrgId__72E607DB");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("OrgId");
            entity.HasKey(e => e.Id).HasName("PK__Organiza__420C9E6CDFD4FD10");

            entity.ToTable("Organisation");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("PermissionId");
            entity.HasKey(e => e.Id).HasName("PK__Permissi__EFA6FB2F8FA60969");


            entity.ToTable("Permission");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Org).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Permissio__OrgId__52593CB8");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ProjectId");
            entity.HasKey(e => e.Id).HasName("PK__Project__761ABEF0DEF8FA1B");

            entity.ToTable("Project");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BuilderName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Location).WithMany(p => p.Projects)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Project__Locatio__41EDCAC5");
        });

        modelBuilder.Entity<ProjectDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ProjectDetailsId");
            entity.HasKey(e => e.Id).HasName("PK__ProjectD__38DB9E06D261836D");

            entity.ToTable("ProjectDetail");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Floor)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Unit)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Wing)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectDetails)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ProjectDe__Proje__540C7B00");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("RoleId");
            entity.HasKey(e => e.Id).HasName("PK__Roles__8AFACE1AB07AC017");

            entity.ToTable("Role");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

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

        modelBuilder.Entity<SystemConfiguration>(entity =>
        {
            entity.HasKey(e => e.ConfigId).HasName("PK__System_C__C3BC335C7C3803BF");

            entity.ToTable("System_Configuration");

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.KeyDetail)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Org).WithMany(p => p.SystemConfigurations)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__System_Co__OrgId__5AC46587");
        });

        modelBuilder.Entity<Tracker>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("TrackerId");
            entity.HasKey(e => e.Id).HasName("PK__Tracker__DEF88A01B0151E11");


            entity.ToTable("Tracker");

            entity.ToTable("Tracker");
            entity.Property(e => e.Budget).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VisitExpectedDate).HasColumnType("datetime");
            entity.Property(e => e.VisitRemark)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Org).WithMany(p => p.Trackers)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__Tracker__OrgId__7AF13DF7");

            entity.HasOne(d => d.VisitedProject).WithMany(p => p.Trackers)
                .HasForeignKey(d => d.VisitedProjectId)
                .HasConstraintName("FK_Tracker_Project");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.Trackers)
                .HasForeignKey(d => d.WorkFlowId)
                .HasConstraintName("FK__Tracker__WorkFlo__52E34C9D");

            entity.HasOne(d => d.WorkFlowStep).WithMany(p => p.Trackers)
                .HasForeignKey(d => d.WorkFlowStepId)
                .HasConstraintName("FK_Tracker_WorkFlowStep");
        });

        modelBuilder.Entity<UserLocation>(entity =>
        {
            entity.HasKey(e => e.UserLocationId).HasName("PK__UserLoca__3C542CAA2F391518");

            entity.ToTable("UserLocation");

            entity.Property(e => e.CurrentLatitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CurrentLongitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.StartLatitude)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StartLongitude)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Org).WithMany(p => p.UserLocations)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__UserLocat__OrgId__0EF836A4");

            entity.HasOne(d => d.User).WithMany(p => p.UserLocations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserLocat__UserI__0E04126B");
        });

        modelBuilder.Entity<VisitTracking>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("VisitTrackingId");
            entity.HasKey(e => e.Id).HasName("PK__VisitTra__E755F8E29949568F");

            entity.ToTable("VisitTracking");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.StartLatitude).HasMaxLength(100);
            entity.Property(e => e.StartLongitude).HasMaxLength(100);
            entity.Property(e => e.StopDateTime).HasColumnType("datetime");
            entity.Property(e => e.StopLatitude).HasMaxLength(100);
            entity.Property(e => e.StopLongitude).HasMaxLength(100);
            entity.Property(e => e.VisitStatus).HasMaxLength(250);

            entity.HasOne(d => d.Enquiry).WithMany(p => p.VisitTrackings)
                .HasForeignKey(d => d.EnquiryId)
                .HasConstraintName("FK__VisitTrac__Enqui__1A9EF37A");

            entity.HasOne(d => d.Project).WithMany(p => p.VisitTrackings)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__VisitTrac__Proje__0A688BB1");

            entity.HasOne(d => d.User).WithMany(p => p.VisitTrackings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__VisitTrac__UserI__09746778");

            entity.HasOne(d => d.WorkFlowStep).WithMany(p => p.VisitTrackings)
                .HasForeignKey(d => d.WorkFlowStepId)
                .HasConstraintName("FK__VisitTrac__WorkF__0880433F");
        });


        modelBuilder.Entity<WorkFlow>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("WorkFlowId");
            entity.HasKey(e => e.Id).HasName("PK__WorkFlow__F98B18EE97E54649");

            entity.ToTable("WorkFlow");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.WorkFlowName).HasMaxLength(250);

            entity.HasOne(d => d.Org).WithMany(p => p.WorkFlows)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__WorkFlow__OrgId__6AEFE058");
        });

        modelBuilder.Entity<WorkFlowDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("WorkFlowDetailId");
            entity.HasKey(e => e.Id).HasName("PK__WorkFlow__025B35FB8909F460");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentStep).HasMaxLength(250);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NextStep).HasMaxLength(250);
            entity.Property(e => e.PreviousStep).HasMaxLength(250);

            entity.HasOne(d => d.Org).WithMany(p => p.WorkFlowDetails)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__WorkFlowS__OrgId__70A8B9AE");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.WorkFlowDetails)
                .HasForeignKey(d => d.WorkFlowId)
                .HasConstraintName("FK__WorkFlowS__WorkF__6FB49575");
        });




        modelBuilder.Entity<WorkFlowStep>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("WorkFlowStepId");
            entity.HasKey(e => e.Id).HasName("PK__WorkFlow__025B35FB8909F460");

            entity.ToTable("WorkFlowStep");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StepName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Org).WithMany(p => p.WorkFlowSteps)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK_WorkFlowStep_Organisation");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.WorkFlowSteps)
                .HasForeignKey(d => d.WorkFlowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkFlowStep_WorkFlow");
        });


        modelBuilder.Entity<Zone>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ZoneId");
            entity.HasKey(e => e.Id).HasName("PK__Zone__601667B5323531CE");

            entity.ToTable("Zone");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ZoneName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<spEnquiryDTO>().HasNoKey();

        modelBuilder.Entity<spParentAndChildrenDTO>().HasNoKey();

        modelBuilder.Entity<spStepCountDTO>().HasNoKey();

        modelBuilder.Entity<spParentDTO>().HasNoKey();

        //modelBuilder.Entity<spGetActivitiesRequestDTO>().HasNoKey();

        modelBuilder.Entity<spGetActivitiesResponseDTO>().HasNoKey();

        modelBuilder.Entity<spGetMonthlyAttendanceSummaryResponseDTO>().HasNoKey();

        modelBuilder.Entity<spGetEmployeeBookingSummaryResponseDTO>().HasNoKey();

        modelBuilder.Entity<spGetTimelineResponseDTO>().HasNoKey();

        modelBuilder.Entity<spGetAllAttendanceDTO>().HasNoKey();

        modelBuilder.Entity<spUpdateAttendanceDTO>().HasNoKey();

        modelBuilder.Entity<AttendanceDTO>().HasNoKey();

        modelBuilder.Entity<RoutePathResponseDTO>().HasNoKey();

        modelBuilder.Entity<Attendance2DTO>().HasNoKey();

        modelBuilder.Entity<TrackerDataDTO>().HasNoKey();

        modelBuilder.Entity<VisitStatusDTO>().HasNoKey();






        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


