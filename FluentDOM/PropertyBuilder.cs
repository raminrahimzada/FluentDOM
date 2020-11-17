using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class PropertyBuilder
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
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public List<AttributeBuilder> Attributes { get; set; } = new List<AttributeBuilder>();
        public PropertyGetterSetterBuilder Get { get; set; } = new PropertyGetterSetterBuilder();
        public PropertyGetterSetterBuilder Set { get; set; } = new PropertyGetterSetterBuilder();
        public bool? HasGet { get; set; }
        public bool? HasSet { get; set; }
        public bool? IsOverride { get; set; }


        public PropertyBuilder HasGetMethod()
        {
            HasGet = true;
            return this;
        }
        public PropertyBuilder HasSetMethod()
        {
            HasSet = true;
            return this;
        }
        public PropertyBuilder Name(string name)
        {
            PropertyName = name;
            return this;
        }

        public PropertyBuilder Type(string type)
        {
            PropertyType = type;
            return this;
        }
        public PropertyBuilder Type<T>()
        {
            PropertyType = typeof(T).FullName;
            return this;
        }

        public PropertyBuilder Public()
        {
            IsPublic = true;
            return this;
        }
        public PropertyBuilder Override()
        {
            IsOverride = true;
            return this;
        }
        public PropertyBuilder Private()
        {
            IsPrivate = true;
            return this;
        }
        public PropertyBuilder Protected()
        {
            IsProtected = true;
            return this;
        }
        public PropertyBuilder Internal()
        {
            IsInternal = true;
            return this;
        }

        public PropertyBuilder Getter(Action<PropertyGetterSetterBuilder> action)
        {
            Get = new PropertyGetterSetterBuilder();
            action(Get);
            return this;
        }
        public PropertyBuilder Setter(Action<PropertyGetterSetterBuilder> action)
        {
            Set=new PropertyGetterSetterBuilder();
            action(Set);
            return this;
        }

        public PropertyBuilder New()
        {
            IsNew = true;
            return this;
        }
        public PropertyBuilder Partial()
        {
            IsPartial = true;
            return this;
        }
        public PropertyBuilder Static()
        {
            IsStatic = true;
            return this;
        }
        public PropertyBuilder Sealed()
        {
            IsSealed = true;
            return this;
        }
        public PropertyBuilder Abstract()
        {
            IsAbstract = true;
            return this;
        }
        public PropertyBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            Attributes = Attributes ?? new List<AttributeBuilder>();
            var attribute = new AttributeBuilder();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }

    }
}