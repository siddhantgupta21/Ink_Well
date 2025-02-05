
namespace IMDBApplication
{

    using System;
    using System.Collections.Generic;

    public class Producer
    {
        public string Name { get; set; }

        public Producer(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
