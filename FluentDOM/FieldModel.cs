using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class FieldModel
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
        public List<AttributeModel> Attributes { get; set; }


        public FieldModel Name(string name)
        {
            FieldName = name;
            return this;
        }

        public FieldModel Type(string type)
        {
            FieldType = type;
            return this;
        }

        public FieldModel Public()
        {
            IsPublic = true;
            return this;
        }
        public FieldModel Private()
        {
            IsPrivate = true;
            return this;
        }
        public FieldModel Protected()
        {
            IsProtected = true;
            return this;
        }
        public FieldModel Internal()
        {
            IsInternal = true;
            return this;
        }


        public FieldModel New()
        {
            IsNew = true;
            return this;
        }
        public FieldModel Partial()
        {
            IsPartial = true;
            return this;
        }
        public FieldModel Static()
        {
            IsStatic = true;
            return this;
        }
        public FieldModel Sealed()
        {
            IsSealed = true;
            return this;
        }
        public FieldModel Abstract()
        {
            IsAbstract = true;
            return this;
        }
        public FieldModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }

    }
}