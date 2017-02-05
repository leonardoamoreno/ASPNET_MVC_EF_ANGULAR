using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_MVC_ANGULAR.Models
{
    public class Restaurante
    {
        public Restaurante() {
            this.Pratos = new List<Prato>();
        }
        public int RestauranteId { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Prato> Pratos { get; set; }
    }
}