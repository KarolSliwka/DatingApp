using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<AppUser>? Users { get; set; }

        // this should be only used when we would like to access the photo by it's id key. EF will allow us to use photos assigned to users without adding photos into context by a convention
        //public DbSet<Photo>? Photos { get; set; }
    }
}