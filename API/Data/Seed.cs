using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager, DataContext context)
        {
            if (await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<AppUser>>(userData);

            WebClient client = new WebClient();
            var json_data = client.DownloadString("https://6b9b8bef3c0b387287e826964b122804.m.pipedream.net/");
            var messagesFromUrl = JsonConvert.DeserializeObject<Root>(json_data).Content.MessageDetails;

            if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "UserAccount"},
                new AppRole{Name = "Admin"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
            
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                user.Bio = user.Bio;
                await userManager.CreateAsync(user, "Password");
                await userManager.AddToRoleAsync(user, "UserAccount");
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Password");
            await userManager.AddToRoleAsync(admin, "Admin");

            foreach(var data in messagesFromUrl ) 
            { 
                var message = new Message
                {
                    Title = data.Title,
                    MessageBody = data.MessageBody,
                    // CreateDate = data.CreateDate.ToDate,
                    CreateBy = data.CreateBy,
                    DeepLinkAction = data.DeepLinkAction,
                    ImportanceLevel = data.ImportanceLevel,
                    AppUserId = 5
                };

                context.Messages.Add(message);
                await context.SaveChangesAsync();
            }
        }       
    }
}