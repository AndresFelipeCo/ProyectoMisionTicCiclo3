using System.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Persistence.AppRepositories
{
  public class AppDbContext : DbContext
  {
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<User> Users { get; set; }

    // protected override void OnModelCreating(DbModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    //     modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
    //     modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();
    // } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>();
      modelBuilder.Entity<Degree>();
      // modelBuilder.Entity<User>(e => 
      // {
      //   e.HasOne(u => u.Degre).WithMany(d => d.Students).OnDelete(DeleteBehavior.NoAction);
      // });
      modelBuilder.Entity<Subject>(e => 
      {
        e.HasOne(r => r.Teacher).WithMany(u => u.SubjectsTe).HasForeignKey(r => r.TeacherId).OnDelete(DeleteBehavior.NoAction);
        e.HasOne(r => r.Tutor).WithMany(u => u.SubjectsTu).HasForeignKey(r => r.TutorId).OnDelete(DeleteBehavior.NoAction);
      });
      modelBuilder.Entity<Inscription>(e => 
      {
        e.HasOne(i => i.Student).WithMany(u => u.Inscriptions).HasForeignKey(i => i.StudentId).OnDelete(DeleteBehavior.NoAction);
      });

      // modelBuilder.Entity<Subject>()
      //       .HasOne(s => s.Teacher)
      //       .WithMany(u => u.SubjectsTe)
      //       .HasForeignKey(s => s.Teacher);
      // modelBuilder.Entity<Subject>()
      //       .HasOne(s => s.Tutor)
      //       .WithMany(u => u.SubjectsTu)
      //       .HasForeignKey(s => s.Tutor);
      // modelBuilder.Entity<Subject>()
      //     .HasOne(a => a.Teacher)
      //     .WithMany()
      //     .OnDelete(DeleteBehavior.NoAction);
      // modelBuilder.Entity<Subject>()
      //     .HasOne(a => a.Tutor)
      //     .WithMany()
      //     .OnDelete(DeleteBehavior.NoAction);
      // modelBuilder.Entity<User>()
      //     .HasOne(a => a.Degre)
      //     .WithMany()
      //     .OnDelete(DeleteBehavior.SetNull);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FollowStudent");
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=FollowStudent;user=sa;password=Y#vfausG;Trusted_Connection=False;MultipleActiveResultSets=true;"
        );
        // optionsBuilder.UseSqlite(
        //     "Filename=FollowStudent.db;"
        // );
      }
    }
  }
}
