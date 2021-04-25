using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Lab6_7
{
    [Serializable]
   public  class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        

        public Product() { }
        public Product(int id, string name, string desc, int quantity, double price, string imgpath, string color)
        {
            Id = id;
            Name = name;
            Description = desc;
            Quantity = quantity;
            Price = price;
            ImagePath = imgpath;
            Color = color;
        }
    }
}
