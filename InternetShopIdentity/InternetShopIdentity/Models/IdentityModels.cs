using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using InternetShop.Models;
using InternetShopIdentity.Models.DataBaseModel;

namespace InternetShopIdentity.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public override string Id { get;  set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("InternetShopContext", throwIfV1Schema: false)
        {
        }

        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BasketModel> Baskets { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //}
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}