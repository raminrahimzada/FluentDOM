using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class DelegateModel
    {
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public bool? IsAbstract { get; set; }
        public bool? IsSealed { get; set; }
        public bool? IsStatic { get; set; }
        public string DelegateName { get; set; }
        public string DelegateType { get; set; }
        public bool? IsNew { get; set; }
        public List<ParameterModel> Parameters { get; set; }

        public List<AttributeModel> Attributes { get; set; }


        public DelegateModel Public()
        {
            IsPublic = true;
            return this;
        }
        public DelegateModel Private()
        {
            IsPrivate = true;
            return this;
        }
        public DelegateModel Partial()
        {
            IsPartial = true;
            return this;
        }
        public DelegateModel Protected()
        {
            IsProtected = true;
            return this;
        }
        public DelegateModel Internal()
        {
            IsInternal = true;
            return this;
        }
        public DelegateModel Abstract()
        {
            IsAbstract = true;
            return this;
        }

        public DelegateModel Name(string name)
        {
            DelegateName = name;
            return this;
        }
        
        public DelegateModel ReturnType(string returnType)
        {
            DelegateType = returnType;
            return this;
        }


        public DelegateModel New()
        {
            IsNew = true;
            return this;
        }

        

        public DelegateModel Parameter(Action<ParameterModel> func)
        {
            Parameters = Parameters ?? new List<ParameterModel>();
            var p = new ParameterModel();
            func(p);
            Parameters.Add(p);
            return this;
        }

        public DelegateModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }


        public DelegateModel Static()
        {
            IsStatic = true;
            return this;
        }

        public DelegateModel Sealed()
        {
            IsSealed = true;
            return this;
        }
    }
}