
using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using ELearning_Core.Model.Student;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Data;

public class ELearningContext : IdentityDbContext<IdentityUser>
{
    public ELearningContext(DbContextOptions<ELearningContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }

    public DbSet<Company> Company { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Lessons> Lessons { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<MainMenu> MainMenus { get; set; }
    public DbSet<SubMenu> SubMenus { get; set; }
    public DbSet<AppNotification> Notifications { get; set; }
    public DbSet<Trade> Trades { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<SubCategory> subCategories { get; set; }

    public DbSet<Post> posts { get; set; }

    public DbSet<Doubt> doubts { get; set; }

    public DbSet<DoubtComment> doubtsComment { get; set; }
    public DbSet<StudentInfo> StudentInfo { get; set; }

    public DbSet<DoubtLike> doubtLikes { get; set; }

    public DbSet<PdfNote> pdfNotes { get; set; }
    public DbSet<PreviousYearPaper> previousYearPapers { get; set; }
    public DbSet<PaperYear> paperYears { get; set; }
    public DbSet<Licence> Licences { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Batch> Batches {  get; set; } 
    public DbSet<BatchSubject> BatchSubjects { get; set; }
    public DbSet<HelpDesk> HelpDesks { get; set; }
}
