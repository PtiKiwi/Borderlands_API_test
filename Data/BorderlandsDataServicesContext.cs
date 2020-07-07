using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BorderlandsDataServices.Data
{
    public class BorderlandsDataServicesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BorderlandsDataServicesContext() : base("name=BorderlandsDataServicesContext")
        {
        }

        public System.Data.Entity.DbSet<BorderlandsDataServices.Models.Character> Characters { get; set; }

        public System.Data.Entity.DbSet<BorderlandsDataServices.Models.Loot> Loots { get; set; }

        public System.Data.Entity.DbSet<BorderlandsDataServices.Models.Armor> Armors { get; set; }

        public System.Data.Entity.DbSet<BorderlandsDataServices.Models.Shield> Shields { get; set; }

        public System.Data.Entity.DbSet<BorderlandsDataServices.Models.Weapon> Weapons { get; set; }
    }
}
