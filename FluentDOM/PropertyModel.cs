using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class PropertyModel
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
        public List<AttributeModel> Attributes { get; set; } = new List<AttributeModel>();
        public PropertyGetterSetterModel Get { get; set; } = new PropertyGetterSetterModel();
        public PropertyGetterSetterModel Set { get; set; } = new PropertyGetterSetterModel();
        public bool? HasGet { get; set; }
        public bool? HasSet { get; set; }
        public bool? IsOverride { get; set; }


        public PropertyModel HasGetMethod()
        {
            HasGet = true;
            return this;
        }
        public PropertyModel HasSetMethod()
        {
            HasSet = true;
            return this;
        }
        public PropertyModel Name(string name)
        {
            PropertyName = name;
            return this;
        }

        public PropertyModel Type(string type)
        {
            PropertyType = type;
            return this;
        }
        public PropertyModel Type<T>()
        {
            PropertyType = typeof(T).FullName;
            return this;
        }

        public PropertyModel Public()
        {
            IsPublic = true;
            return this;
        }
        public PropertyModel Override()
        {
            IsOverride = true;
            return this;
        }
        public PropertyModel Private()
        {
            IsPrivate = true;
            return this;
        }
        public PropertyModel Protected()
        {
            IsProtected = true;
            return this;
        }
        public PropertyModel Internal()
        {
            IsInternal = true;
            return this;
        }

        public PropertyModel Getter(Action<PropertyGetterSetterModel> action)
        {
            Get = new PropertyGetterSetterModel();
            action(Get);
            return this;
        }
        public PropertyModel Setter(Action<PropertyGetterSetterModel> action)
        {
            Set=new PropertyGetterSetterModel();
            action(Set);
            return this;
        }

        public PropertyModel New()
        {
            IsNew = true;
            return this;
        }
        public PropertyModel Partial()
        {
            IsPartial = true;
            return this;
        }
        public PropertyModel Static()
        {
            IsStatic = true;
            return this;
        }
        public PropertyModel Sealed()
        {
            IsSealed = true;
            return this;
        }
        public PropertyModel Abstract()
        {
            IsAbstract = true;
            return this;
        }
        public PropertyModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }

    }
}