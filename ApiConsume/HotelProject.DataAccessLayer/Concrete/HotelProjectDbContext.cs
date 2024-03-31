using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class HotelProjectDbContext:IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CASPER\SQL2022; Database=UdemyHotelProject; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        //SQL'de yazılan trigger'ların hata vermemesi için yazıldı.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>(entry => 
            {
                entry.ToTable("Rooms", tb => tb.HasTrigger("RoomIncrease"));
                entry.ToTable("Rooms", tb => tb.HasTrigger("RoomDecrease"));
            });

            builder.Entity<Staff>(entry => 
            {
                entry.ToTable("Staffs", tb => tb.HasTrigger("StaffIncrease"));
                entry.ToTable("Staffs", tb => tb.HasTrigger("StaffDecrease"));
            });

            builder.Entity<Guest>(entry => 
            {
                entry.ToTable("Guests", tb => tb.HasTrigger("CustomerIncrease"));
                entry.ToTable("Guests", tb => tb.HasTrigger("CustomerDecrease"));
            });
        }

        public DbSet<Room> Rooms{ get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }

        //MessageCategories tablosu Contacts tablosu ile ilişkili olduğu ve Contacts tablosunda da veri olduğu için "update-database" işleminde hata verecektir. O yüzden migration yapılmadan önce Contacts tablosu içindeki veriler silinmeli.
        public DbSet<MessageCategory> MessageCategories { get; set; }
    }
}
