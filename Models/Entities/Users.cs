using KeepetFinal.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } // نام کاربر
    public string Address { get; set; } // آدرس کاربر
    public string Role { get; set; } // نقش (صاحب حیوان یا ارائه‌دهنده خدمات)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // تاریخ ایجاد
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // تاریخ بروزرسانی
    public string NationalCode { get; set; }

    // روابط
    public ICollection<Pet> Pets { get; set; } // رابطه با حیوانات
    public ICollection<Service> Services { get; set; } // رابطه با خدمات
    public ICollection<Booking> Bookings { get; set; } // رابطه با رزروها
}