using System;
using System.Collections.Generic;
using System.Xml;

namespace xmlTesty
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            var root = doc.DocumentElement;
            PrintItem(root);
            Console.ReadLine();

        }
        /// <summary>
        /// Метод для отображения содержимого xml элемента.
        /// </summary>
        /// <remarks>
        /// Получает элемент xml, отображает его имя, затем все атрибуты
        /// после этого переходит к зависимым элементам.
        /// Отображает зависимые элементы со смещением вправо от начала строки.
        /// </remarks>
        /// <param name="item"> Элемент Xml. </param>
        /// <param name="indent"> Количество отступов от начала строки. </param>

        private static void PrintItem(XmlElement item, int indent = 0)
        {
            Product product = new Product();

            foreach (XmlAttribute attr in item.Attributes)
            {
                // Cod Towaru w hutrowni + kod producenta
                if (item.LocalName.Contains("product"))
                {
                    if (item.HasAttribute("id")||item.HasAttribute("code_producer"))
                    {
                        if (attr.Name == "id"||attr.Name == "code_producer")
                        {
                            Console.WriteLine(attr.InnerXml);
                        }
                    }
                }
                //Producent produkta
                if (item.LocalName.Contains("producer"))
                    if (attr.Name =="name") { Console.WriteLine("Code Produktu: "); Console.WriteLine(attr.InnerXml); }
                //Categoria produkta
                if (item.LocalName.Contains("category"))
                    if (attr.Name == "name") { Console.WriteLine("Categoria: "); Console.WriteLine(attr.InnerXml); }
                //Adres produkta w hurtowni
                if (item.LocalName.Contains("card"))
                    if (attr.Name == "url") { Console.WriteLine("Adres www: "); Console.WriteLine(attr.InnerXml); }
                //Opis skrucony
                if (item.LocalName.Contains("name"))
                    if (attr.Value == "pol") { Console.WriteLine("Nazwa: "); Console.WriteLine(item.InnerText); }
                //Tabela Rozmiarów wymiary wkładki
                if(item.LocalName.Contains("long_desc"))
                    if (attr.Value == "pol") { Console.WriteLine("Tab rozmiar: "); Console.WriteLine(item.InnerText); }
                //Cena brutto
                if (item.LocalName.Contains("price"))
                    if (attr.Name == "gross" || attr.LocalName == "vat")
                    { Console.WriteLine("Cena brutto: "); Console.WriteLine(attr.Value); }
                //Jed VAT
                if (item.LocalName.Contains("srp"))
                    if (attr.Value == "vat") { Console.WriteLine("VAT: "); Console.WriteLine(attr.Value); }
                //Zdjęcia
                if (item.LocalName.Contains("image"))
                    if (attr.LocalName == "url") { Console.WriteLine("image: "); Console.WriteLine(attr.InnerText); }
                //Tabela parametrów 
                if (item.LocalName.Contains("parameter")||item.LocalName.Contains("value"))
                    if (attr.LocalName == "name") { Console.WriteLine("Parametr: "); Console.WriteLine(attr.InnerText); }

                //Rozmiary
                if (item.LocalName.Contains("size") || item.LocalName.Contains("stock"))
                    if (attr.LocalName == "id") { Console.WriteLine("Rozmiar: "); Console.WriteLine(attr.InnerText); }
                   
                // rozmiar-ilość 
                if (item.LocalName.Contains("stock"))
                    if (attr.LocalName == "quantity") { Console.WriteLine("Ilość/roz: "); Console.WriteLine(attr.InnerText); }

            }
            foreach (var child in item.ChildNodes)
            {
                if (child is XmlElement node)
                {
                    // Если зависимый элемент тоже элемент,
                    // то переходим на новую строку 
                    // и рекурсивно вызываем метод.
                    // Следующий элемент будет смещен на один отступ вправо.
                    Console.WriteLine();
                    
                    PrintItem(node, indent + 1);
                }
                if (child is XmlText text) //2 can
                {
                    // Если зависимый элемент текст,
                    // то выводим его через тире.
                    Console.Write($"- {text.InnerText}");
                }
            }  
        }
    }
}
