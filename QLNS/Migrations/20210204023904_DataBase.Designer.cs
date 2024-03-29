﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLNS.Data;

namespace QLNS.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210204023904_DataBase")]
    partial class DataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QLNS.Models.BlogRoles", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("BlogId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("BlogRoles");
                });

            modelBuilder.Entity("QLNS.Models.BlogTags", b =>
                {
                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("BlogId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("BlogTags");
                });

            modelBuilder.Entity("QLNS.Models.Blogs", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("('2020-10-12T11:56:50.8034466+07:00')");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BlogId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("QLNS.Models.ChildComments", b =>
                {
                    b.Property<int>("ChildCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateComment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.HasKey("ChildCommentId");

                    b.HasIndex("CommentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ChildComments");
                });

            modelBuilder.Entity("QLNS.Models.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateComment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("QLNS.Models.DayWorks", b =>
                {
                    b.Property<int>("DayWorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("DayInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TimeSheetId")
                        .HasColumnType("int");

                    b.HasKey("DayWorkId");

                    b.HasIndex("TimeSheetId");

                    b.ToTable("DayWorks");
                });

            modelBuilder.Entity("QLNS.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("QLNS.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addresses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreateNewPassword")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("ShiftWorkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.HasIndex("ShiftWorkId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("QLNS.Models.FormVersions", b =>
                {
                    b.Property<int>("FormVersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("VersionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormVersionId");

                    b.HasIndex("FormId");

                    b.ToTable("FormVersions");
                });

            modelBuilder.Entity("QLNS.Models.Forms", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FormType")
                        .HasColumnType("int");

                    b.HasKey("FormId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("QLNS.Models.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DataUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSaw")
                        .HasColumnType("bit");

                    b.Property<string>("LinkRelated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbNailImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNotification")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("QLNS.Models.PositionHistory", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId", "Id");

                    b.ToTable("PositionHistory");
                });

            modelBuilder.Entity("QLNS.Models.RefreshToken", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId", "Id");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("QLNS.Models.RequestApprovals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeTimeOff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserApprovalId")
                        .HasColumnName("userApprovalID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("RequestApprovals");
                });

            modelBuilder.Entity("QLNS.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("QLNS.Models.ShiftWorks", b =>
                {
                    b.Property<int>("ShiftWorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EndTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.HasKey("ShiftWorkId");

                    b.ToTable("ShiftWorks");
                });

            modelBuilder.Entity("QLNS.Models.Tags", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("QLNS.Models.TimeSheets", b =>
                {
                    b.Property<int>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.Property<int>("TotalDay")
                        .HasColumnType("int");

                    b.Property<int>("TotalDayOfMonth")
                        .HasColumnType("int");

                    b.Property<int>("TotalHoliday")
                        .HasColumnType("int");

                    b.Property<int>("TotalLeaveDay")
                        .HasColumnType("int");

                    b.Property<int>("TotalNoCheck")
                        .HasColumnType("int");

                    b.Property<int>("TotalOffDay")
                        .HasColumnType("int");

                    b.Property<int>("TotalWeekendDay")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("TimeSheetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("QLNS.Models.BlogRoles", b =>
                {
                    b.HasOne("QLNS.Models.Blogs", "Blog")
                        .WithMany("BlogRoles")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLNS.Models.Roles", "Role")
                        .WithMany("BlogRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.BlogTags", b =>
                {
                    b.HasOne("QLNS.Models.Blogs", "Blog")
                        .WithMany("BlogTags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLNS.Models.Tags", "Tag")
                        .WithMany("BlogTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.Blogs", b =>
                {
                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("Blogs")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.ChildComments", b =>
                {
                    b.HasOne("QLNS.Models.Comments", "Comment")
                        .WithMany("ChildComments")
                        .HasForeignKey("CommentId");

                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("ChildComments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("QLNS.Models.Comments", b =>
                {
                    b.HasOne("QLNS.Models.Blogs", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId");

                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("Comments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("QLNS.Models.DayWorks", b =>
                {
                    b.HasOne("QLNS.Models.TimeSheets", "TimeSheet")
                        .WithMany("DayWorks")
                        .HasForeignKey("TimeSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.Employees", b =>
                {
                    b.HasOne("QLNS.Models.Departments", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("QLNS.Models.Roles", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.HasOne("QLNS.Models.ShiftWorks", "ShiftWork")
                        .WithMany("Employees")
                        .HasForeignKey("ShiftWorkId");
                });

            modelBuilder.Entity("QLNS.Models.FormVersions", b =>
                {
                    b.HasOne("QLNS.Models.Forms", "Form")
                        .WithMany("FormVersions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.PositionHistory", b =>
                {
                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("PositionHistory")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.RefreshToken", b =>
                {
                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("RefreshToken")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.RequestApprovals", b =>
                {
                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("RequestApprovals")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLNS.Models.TimeSheets", b =>
                {
                    b.HasOne("QLNS.Models.Employees", "Employee")
                        .WithMany("TimeSheets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
