using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Starter
{
    public class Equipment
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Equipment()
        {
        }

        public Equipment(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
