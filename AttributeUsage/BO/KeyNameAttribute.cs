using System;

namespace AttributeUsage.BO
{
    internal class KeyNameAttribute : Attribute
    {
        public KeyNameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}