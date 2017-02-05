using ASPNET_MVC_ANGULAR.Models;
using ASPNET_MVC_ANGULAR.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ASPNET_MVC_ANGULAR.DAL
{

    public class RestauranteContext : DbContext
    {

        public RestauranteContext() : base("RestauranteContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            
            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PratoMap());
            modelBuilder.Configurations.Add(new RestauranteMap());

            base.OnModelCreating(modelBuilder);

        }
    }

}