using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConcertGo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Concert> Concerts { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<File> Files { get; set; }
    }

    public class Concert
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public ICollection<Media> Media { get; set; }
    }

    public class Artist
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Concert> Concerts { get; set; }
    }

    public class Media
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public ICollection<File> File { get; set; }
    }

    public class File
    {
        public Guid Id { get; set; }

        public FileType Type { get; set; }

        public string Location { get; set; }

        public DateTime UploadDateTime { get; set; }

        public bool HasMedia { get; set; }
    }

    public enum FileType
    {
        Photo, Video
    }
}