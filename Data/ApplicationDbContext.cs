using KeepetFinal.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeepetFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // تنظیمات پیش‌فرض Identity

            // تعریف رابطه بین ApplicationUser و Pet
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری

            // تعریف رابطه بین ApplicationUser و Service
            modelBuilder.Entity<Service>()
                .HasOne(s => s.User)
                .WithMany(u => u.Services)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری

            // تعریف رابطه بین ApplicationUser و Booking
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری

            // تعریف رابطه بین Booking و Service
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری

            // تعریف رابطه بین Booking و Pet
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Pet)
                .WithMany()
                .HasForeignKey(b => b.PetId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری

            // تعریف رابطه بین Review و ApplicationUser
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری

            // تعریف رابطه بین Review و Service
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Service)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.NoAction); // غیرفعال کردن حذف آبشاری
        }

        //public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        //{
        //    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //    // ایجاد نقش Admin در صورت عدم وجود
        //    if (!await roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    }

        //    // افزودن کاربر Admin در صورت عدم وجود
        //    var adminUser = await userManager.FindByNameAsync("tahadabiri");
        //    if (adminUser == null)
        //    {
        //        adminUser = new ApplicationUser
        //        {
        //            UserName = "tahadabiri",
        //            Email = "tahadabiri@example.com",
        //            Name = "Admin User",
        //            EmailConfirmed = true
        //        };

        //        var result = await userManager.CreateAsync(adminUser, "Mahan1391?");
        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(adminUser, "Admin");
        //        }
        //    }
        //}
        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // ایجاد نقش Admin در صورت عدم وجود
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // افزودن کاربر Admin در صورت عدم وجود
            var adminUser = await userManager.FindByNameAsync("tahadabiri");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "tahadabiri",
                    Email = "tahadabiri@example.com",
                    Name = "Admin User",
                    Address = "آدرس پیش‌فرض", // مقداردهی به Address
                    NationalCode = "4121199901",
                    EmailConfirmed = true,
                    Role = "Admin"
                };

                var result = await userManager.CreateAsync(adminUser, "Mahan1391?");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

    }
}
