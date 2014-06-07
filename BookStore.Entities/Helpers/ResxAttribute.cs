using System;

namespace BookStore.Entities.Helpers
{
    public class ResxAttribute : Attribute
    {
        public string Name { get; private set; }

        public ResxAttribute(string name)
        {
            Name = name;
        }
    }
}
