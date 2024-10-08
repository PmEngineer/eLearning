
using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Master;
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
}
