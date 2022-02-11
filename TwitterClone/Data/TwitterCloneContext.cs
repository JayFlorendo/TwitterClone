#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Models;

namespace TwitterClone.Data
{
    public class TwitterCloneContext : DbContext
    {
        public TwitterCloneContext (DbContextOptions<TwitterCloneContext> options)
            : base(options)
        {
        }

        public DbSet<TwitterClone.Models.Users> Users { get; set; }

        public DbSet<TwitterClone.Models.Tweets> Tweets { get; set; }

        public DbSet<TwitterClone.Models.Followers> Followers { get; set; }
    }
}
