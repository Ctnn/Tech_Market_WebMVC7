using Microsoft.AspNetCore.Identity;
using Tech_Market_WebMVC7UI.Constants;
namespace Tech_Market_WebMVC7UI.Data
{
    public class DbSeeder
    {
       public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
           

            // Rolleri Database'imize entegre ediyoruz.

            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // Yeni bir admin kullanıcısı oluşturuyoruz.

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);

            if (userInDb == null)
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin,Roles.Admin.ToString());
            }


           
        }
    }
}
