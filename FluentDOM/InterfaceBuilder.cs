using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentDOM
{
    public class InterfaceBuilder
    {
        public string InterfaceName { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public List<AttributeBuilder> Attributes { get; set; } = new List<AttributeBuilder>();

        public InterfaceBuilder Name(string name)
        {
            InterfaceName = name;
            return this;
        }
        public InterfaceBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            Attributes = Attributes ?? new List<AttributeBuilder>();
            var attribute = new AttributeBuilder();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
        public InterfaceBuilder Public()
        {
            IsPublic = true;
            return this;
        }

        public InterfaceBuilder Partial()
        {
            IsPartial = true;
            return this;
        }

        public InterfaceBuilder Private()
        {
            IsPrivate = true;
            return this;
        }

        public InterfaceBuilder Protected()
        {
            IsProtected = true;
            return this;
        }

        public InterfaceBuilder Internal()
        {
            IsInternal = true;
            return this;
        }
    }
}