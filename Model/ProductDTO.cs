using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace treinamento1ASPNET.Model
{
    public class ProductDTO
    {
        public string Nome {get;set;}
        public decimal Preco {get;set;}
        public int Estoque {get;set;}
    }
}