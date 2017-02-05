using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ASPNET_MVC_ANGULAR.Models.Mapping
{
    public class RestauranteMap : EntityTypeConfiguration<Restaurante>
    {
        public RestauranteMap()
        {
            // Primary Key
            this.HasKey(t => t.RestauranteId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Restaurante");
            this.Property(t => t.RestauranteId).HasColumnName("RestauranteId");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
