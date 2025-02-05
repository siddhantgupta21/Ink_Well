
namespace IMDBApplication
{

    using System;
    using System.Collections.Generic;
   public class Actor
    {
        public string Name { get; set; }

        public Actor(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
