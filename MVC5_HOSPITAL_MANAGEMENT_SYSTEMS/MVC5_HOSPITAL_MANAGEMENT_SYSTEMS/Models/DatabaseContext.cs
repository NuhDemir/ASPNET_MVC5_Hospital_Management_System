using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Security.Policy;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models.VmModels;
namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("hastaneConnection")
        {
            Database.SetInitializer(new DataInitilalizer());

        }



      
        public DbSet<Doktor> TBLDoktor { get; set; }
        public DbSet<Personel> TBLPersonel { get; set; }
        public DbSet<Medicine> TBLMedicine { get; set; }
        public DbSet<Recete> TBLRecete { get; set; }
        public DbSet<Hasta> TBLHasta { get; set; }
       
       
        public DbSet<Admin> TBLAdmin { get; set; }
        public DbSet<Kan> TBLKan { get; set; }
        public DbSet<Idrar> TBLIdrar { get; set; }
        public DbSet<Radyoloji> TBLRadyoloji { get; set; }
        public DbSet<Yorum> TBLYorum { get; set; }
        public DbSet<Message> TBLMessage { get; set; }
    
}
}