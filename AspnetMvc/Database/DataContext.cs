using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspnetMvc.Models;

namespace AspnetMvc.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<List> Lists { get; set; }
        
        public DbSet<Role> Roles { get; set;}
        public DbSet<SecActivity> SecActivities { get; set; }
        public DbSet<SecActivityRole> SecActivityRoles { get; set; }
        public DbSet<SecModel> SecModels { get; set; }
        public DbSet<SecModelAttribute> SecModelAttributes { get; set; }
        public DbSet<SecModelAttributeRole> SecModelAttributesRoles { get; set; }
        public DbSet<SecModelRole> SecModelRoles { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRoles { get; set; }
    }
}