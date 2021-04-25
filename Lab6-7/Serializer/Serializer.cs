using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Collections.ObjectModel;
namespace Lab6_7.Serializer
{
    public static class Serializer
    {

        public static void AddNode(Product p, string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            var rootNode = xDoc.GetElementsByTagName("ArrayOfProduct")[0];
            var nav = rootNode.CreateNavigator();
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (var writer = nav.AppendChild())
            {
                var serializer = new XmlSerializer(p.GetType());
                writer.WriteWhitespace("");
                serializer.Serialize(writer, p, emptyNamepsaces);
                writer.Close();
            }
            xDoc.Save(path);
        }

        public static ObservableCollection<Product> Deserialiaze(string path)
        {
            List<Product> list = new List<Product>();
            ObservableCollection<Product> arr = new ObservableCollection<Product>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                list = (List<Product>)formatter.Deserialize(fs);
              foreach(Product p in list)
                {
                    arr.Add(p);
                }
                return arr;
            }
        }

        public static void RewriteXML(string path, string id, ObservableCollection<Product> p)
        {
            ObservableCollection<Product> buf = new ObservableCollection<Product>();
            buf = Deserialiaze(path);

            for (int i = 0; i < buf.Count; i++)
            {
                if (Convert.ToString(buf[i].Id).Equals(id))
                { buf.Remove(buf[i]);
                   
                }
            }
            Product updatedNode = new Product();
            updatedNode.Id = p[0].Id;
            updatedNode.Name = p[0].Name;
            updatedNode.Description = p[0].Description;
            updatedNode.ImagePath = p[0].ImagePath;
            updatedNode.Quantity = p[0].Quantity;
            updatedNode.Price = p[0].Price;
            updatedNode.Color = p[0].Color;
            buf.Add(updatedNode);

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("Product");
            foreach (XmlNode n in childnodes)
            {
                xRoot.RemoveChild(n);
                xDoc.Save(path);
            }
            foreach (Product t in buf)
            {
                AddNode(t, path);
            }
        }

        public static void DeleteNode(string path, int id)
        {
            ObservableCollection<Product> buf = new ObservableCollection<Product>();
            buf = Deserialiaze(path);

            for (int i = 0; i < buf.Count; i++)
            {
                if (buf[i].Id == id)
                    buf.Remove(buf[i]);
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("Product");
            foreach (XmlNode n in childnodes)
            {
                xRoot.RemoveChild(n);
                xDoc.Save(path);
            }
            foreach (Product t in buf)
            {
                AddNode(t, path);
            }
        }
    }
}
