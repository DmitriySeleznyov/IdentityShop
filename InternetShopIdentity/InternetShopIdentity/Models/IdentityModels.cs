using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using InternetShop.Models;
using InternetShopIdentity.Models.DataBaseModel;

namespace InternetShopIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public override string Id { get;  set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("InternetShopContext", throwIfV1Schema: false)
        {
        }

        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BasketModel> Baskets { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}