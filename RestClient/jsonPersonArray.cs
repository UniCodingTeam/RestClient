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
    },
    "phoneNumbers":
    [
        {
            "type":"mobile",
            "number":"+61 0405 111 222"
        },
        {
            "type":"home",
            "number":"+61 0405 111 333"
        },
        {
            "type":"work",
            "number":"+61 0405 111 444"
        }
    ]
 } 
 */
namespace RestClient
{
    class jsonPersonArray : jsonPersonComplex
    {
        public List<phoneNumber> phoneNumbers { get; set; }

        public class phoneNumber
        {
            public string type { get; set; }
            public string number { get; set; }
        }
    }
}
