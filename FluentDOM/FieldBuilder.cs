using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class FieldBuilder
    {
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public bool? IsAbstract { get; set; }
        public bool? IsSealed { get; set; }
        public bool? IsStatic { get; set; }
        public bool? IsNew { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public List<AttributeBuilder> Attributes { get; set; }


        public FieldBuilder Name(string name)
        {
            FieldName = name;
            return this;
        }

        public FieldBuilder Type(string type)
        {
            FieldType = type;
            return this;
        }

        public FieldBuilder Public()
        {
            IsPublic = true;
            return this;
        }
        public FieldBuilder Private()
        {
            IsPrivate = true;
            return this;
        }
        public FieldBuilder Protected()
        {
            IsProtected = true;
            return this;
        }
        public FieldBuilder Internal()
        {
            IsInternal = true;
            return this;
        }


        public FieldBuilder New()
        {
            IsNew = true;
            return this;
        }
        public FieldBuilder Partial()
        {
            IsPartial = true;
            return this;
        }
        public FieldBuilder Static()
        {
            IsStatic = true;
            return this;
        }
        public FieldBuilder Sealed()
        {
            IsSealed = true;
            return this;
        }
        public FieldBuilder Abstract()
        {
            IsAbstract = true;
            return this;
        }
        public FieldBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            Attributes = Attributes ?? new List<AttributeBuilder>();
            var attribute = new AttributeBuilder();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }

    }
}