using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SharpTrooper.Core;
using SharpTrooper.Entities;
using System.Xml;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            SharpTrooperCore sharpTrooper = new SharpTrooperCore();
            Console.WriteLine("Введите идентификатор");
            string id = Console.ReadLine();
            if (int.TryParse(id, out int result))
            {
                if(id >= 1 && id <= 88){
                    People people = sharpTrooper.GetPeople(id);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(People));

                    using (FileStream writer = new FileStream("file.xml", FileMode.OpenOrCreate))
                    {
                         xmlSerializer.Serialize(writer, people);
                    }
                    Console.WriteLine(people.name);
                }
            }
        }
    }
}
