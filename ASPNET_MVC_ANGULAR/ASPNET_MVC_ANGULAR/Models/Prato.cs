
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_MVC_ANGULAR.Models
{
    public class Prato
    {
        public int PratoId { get; set; }
        
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int RestauranteId { get; set; }
        
        public virtual Restaurante Restaurante { get; set; }
    }
}