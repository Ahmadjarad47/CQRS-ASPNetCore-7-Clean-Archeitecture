using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Category:BaseEntity<int>
    {
        public Category()
        {

        }
        public Category(int id,string name,string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
