using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is the first class created manually. The class is in the Entities folder of API. Then in the class we create the properties of the class. Type 'prop' + tab to get syntax update each and tab to next to complete the property
namespace API.Entities
{
    public class Product
    {
        // In the database, we will have a table based on the class. Each property is a column in the table.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int QuantityInStock { get; set; }
    }
}