using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Data
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogRoles> BlogRoles { get; set; }
        public virtual DbSet<BlogTags> BlogTags { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<ChildComments> ChildComments { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<DayWorks> DayWorks { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FormVersions> FormVersions { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PositionHistory> PositionHistory { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<RequestApprovals> RequestApprovals { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ShiftWorks> ShiftWorks { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TimeSheets> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogRoles>(entity =>
            {
                entity.HasKey(e => new { e.BlogId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogRoles)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.BlogRoles)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<BlogTags>(entity =>
            {
                entity.HasKey(e => new { e.BlogId, e.TagId });

                entity.HasIndex(e => e.TagId);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.TagId);
            });

            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.CreateDate).HasDefaultValueSql("('2020-10-12T11:56:50.8034466+07:00')");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<ChildComments>(entity =>
            {
                entity.HasKey(e => e.ChildCommentId);

                entity.HasIndex(e => e.CommentId);

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.ChildComments)
                    .HasForeignKey(d => d.CommentId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ChildComments)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasIndex(e => e.BlogId);

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<DayWorks>(entity =>
            {
                entity.HasKey(e => e.DayWorkId);

                entity.HasIndex(e => e.TimeSheetId);

                entity.HasOne(d => d.TimeSheet)
                    .WithMany(p => p.DayWorks)
                    .HasForeignKey(d => d.TimeSheetId);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.ShiftWorkId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.ShiftWork)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ShiftWorkId);
            });

            modelBuilder.Entity<FormVersions>(entity =>
            {
                entity.HasKey(e => e.FormVersionId);

                entity.HasIndex(e => e.FormId);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormVersions)
                    .HasForeignKey(d => d.FormId);
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.FormId);
            });

            modelBuilder.Entity<PositionHistory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PositionHistory)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<RequestApprovals>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.UserApprovalId).HasColumnName("userApprovalID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RequestApprovals)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");
            });

            modelBuilder.Entity<ShiftWorks>(entity =>
            {
                entity.HasKey(e => e.ShiftWorkId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");
            });

            modelBuilder.Entity<TimeSheets>(entity =>
            {
                entity.HasKey(e => e.TimeSheetId);

                entity.HasIndex(e => e.EmployeeId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TimeSheets)
                    .HasForeignKey(d => d.EmployeeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
