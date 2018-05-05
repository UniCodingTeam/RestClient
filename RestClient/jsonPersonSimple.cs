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
    "isAlive": false
 }
 */
namespace RestClient
{
    class jsonPersonSimple
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public double age { get; set; }
        public bool isAlive { get; set; }
    }
}
