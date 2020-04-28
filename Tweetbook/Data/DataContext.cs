
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Tweetbook.Domain;

namespace Tweetbook.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<FiverrServices> FiverrServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<PostTag>().Ignore(xx => xx.Post).HasKey(x => new {x.PostId, x.TagName});
        }
      
    }
    public partial class InMememoryData
    {
        public List<FiverrServices> GetServices()
        {
            List<FiverrServices> services = new List<FiverrServices>()
            {
                new FiverrServices(){Id=Guid.NewGuid(),Description="Having ability to learn quickly and apply new skills to existing problems. Having rich experience in developing web applications through acontinuous learning process and keep myself dynamic, visionary and competitive with the changing scenario of the world.",Rate=10,Title="First",Image="assets/img/profilestekch1.PNG",FiverrURL="https://www.fiverr.com/zazi_developer/convert-html-static-pages-to-wordpress",UserId="c50bbbe4-6c39-42e3-be19-a49c40579aa3"},
           };
            return services;
        }
    }
}
