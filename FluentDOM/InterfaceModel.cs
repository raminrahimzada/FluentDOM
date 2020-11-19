using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentDOM
{
    public class InterfaceModel
    {
        public string InterfaceName { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public List<AttributeModel> Attributes { get; set; } = new List<AttributeModel>();

        public InterfaceModel Name(string name)
        {
            InterfaceName = name;
            return this;
        }
        public InterfaceModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
        public InterfaceModel Public()
        {
            IsPublic = true;
            return this;
        }

        public InterfaceModel Partial()
        {
            IsPartial = true;
            return this;
        }

        public InterfaceModel Private()
        {
            IsPrivate = true;
            return this;
        }

        public InterfaceModel Protected()
        {
            IsProtected = true;
            return this;
        }

        public InterfaceModel Internal()
        {
            IsInternal = true;
            return this;
        }
    }
}