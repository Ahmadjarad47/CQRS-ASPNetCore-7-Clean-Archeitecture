using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public Product()
        {

        }
        public Product(int id,string name, string description, decimal price, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        //Navigational Property
        public virtual Category Category { get; set; }
        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
