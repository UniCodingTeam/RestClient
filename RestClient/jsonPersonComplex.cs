using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 {
    "firstname":"Roger",
    "lastname":"Moore",
    "age":89,
    "isAlive": false,
    "address":
    {
        "streetAddress":"1 Main Street",
        "city":"London",
        "postCode":"N1 3XX"
    }
 } 
 */
namespace RestClient
{
    class jsonPersonComplex : jsonPersonSimple
    {
        public addr address {get; set;}

        public class addr
        {
            public string streetAddress { get; set; }
            public string city { get; set; }
        }
    }
}
