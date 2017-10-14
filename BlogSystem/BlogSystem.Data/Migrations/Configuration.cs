namespace BlogSystem.Data.Migrations
{
    using BlogSystem.Data.Model;
    using BlogSystem.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BlogSystem.Data.MsSqlDbContext>
    {
        private const string AdministratorUserName = "simona.arsova@abv.bg";
        private const string AdministratorPassword = "123456";
        private const string CategoryName = "Other";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedCategories(context);
            base.Seed(context);

        }

        private void SeedUsers(MsSqlDbContext context)
        {
            if (!context.Roles.Any())
            {
                CreateRole(GlobalConstants.AdminRole, context);
                CreateRole(GlobalConstants.RegisteredUserRole, context);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, GlobalConstants.AdminRole);
                userManager.AddToRole(user.Id, GlobalConstants.RegisteredUserRole);
            }
        }

        private void CreateRole(string roleName, MsSqlDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = roleName };

            roleManager.Create(role);
        }

        private void SeedCategories(MsSqlDbContext context)
        {
            if (!context.Categories.Any())
            {
                var category = new Category(CategoryName);

                context.Categories.Add(category);
            }
        }
    }
}
