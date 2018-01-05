using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudyLab.Models;

namespace StudyLab.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudyLab.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudyLab.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "admin@studylab.com", UserName = "Administrator" };
            userManager.Create(user, "123456");

            // CREATE NEW ROLE (ADMINISTRATOR)
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            rm.Create(new IdentityRole("Administrator"));

            // ADD ADMIN ACCOUNT TO ROLE
            var email = userManager.FindByEmail("admin@studylab.com");
            userManager.AddToRole(email.Id, "Administrator");

        }
    }
}
