using System;

namespace xmlTesty
{
    class Product
    {

        int Id { get; set; }
        string CodeProducer { get; set; }
        string Producer { get; set; }
        string Name { get; set; }
        //string Category { get; set; }
        //string Color { get; set; }
        //string LongDesc { get; set; }
        //int Gross { get; set; }
        //string Image { get; set; }
        //string Sizes { get; set; }

        public Product(){ }
        public Product(int id, string codeProducer, string producer, string name)
        {
            Id = id;
            CodeProducer = codeProducer;
            Producer = producer;
            Name = name;
        }

    }

    
}
