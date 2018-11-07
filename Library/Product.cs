using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Product
    {
        public int Id { get; set; }
        public string Manufacture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Product(int id, string name, string manufacture, string description)
        {
            Id = id;
            Name = name;
            Manufacture = manufacture;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} : {2} ({3})");
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Product)
            {
                Product prd = obj as Product;
                if (Id == prd.Id)
                    return true;
            }
            return false;
        }
    }
}
