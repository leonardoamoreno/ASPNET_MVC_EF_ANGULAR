using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ASPNET_MVC_ANGULAR.Models.Mapping
{
    public class PratoMap : EntityTypeConfiguration<Prato>
    {
        public PratoMap()
        {
            // Primary Key
            this.HasKey(t => t.PratoId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Prato");
            this.Property(t => t.PratoId).HasColumnName("PratoId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Preco).HasColumnName("Preco");
            this.Property(t => t.RestauranteId).HasColumnName("RestauranteId");

            // Relationships
            this.HasRequired(t => t.Restaurante)
                .WithMany(t => t.Pratos)
                .HasForeignKey(d => d.RestauranteId);

        }
    }
}
