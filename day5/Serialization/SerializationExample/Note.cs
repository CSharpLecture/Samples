using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationExample
{
    //For the XML Serializer it is important that the class is public
    public class Note
    {
        //Also having an empty default constructor is important!

        //Only public properties will be serialized
        public string Description { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Title, Description, Created.ToLongDateString());
        }
    }
}
