using Microsoft.EntityFrameworkCore;

namespace ExamineApp.Models;

public partial class ExamineDbContext : DbContext
{
    public ExamineDbContext()
    {
    }

    public ExamineDbContext(DbContextOptions<ExamineDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Examine> Examines { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Pupil> Pupils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=ExamineDB; Trusted_Connection=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Examine>(entity =>
        {
            entity.ToTable("Examine");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.LessonCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PupilNumber).HasColumnType("numeric(5, 0)");
            entity.Property(e => e.Result).HasColumnType("numeric(1, 0)");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClassNum).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TeacherName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TeacherSurName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pupil>(entity =>
        {
            entity.ToTable("Pupil");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClassNum).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Number).HasColumnType("numeric(5, 0)");
            entity.Property(e => e.SurName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
