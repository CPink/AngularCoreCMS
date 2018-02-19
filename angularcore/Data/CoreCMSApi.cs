using angularcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularcore.Data
{
    public class CoreCMSApi : DbContext
    {
        public CoreCMSApi(DbContextOptions<CoreCMSApi> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Sidebar> Sidebar { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
