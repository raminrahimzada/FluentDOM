using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class DelegateBuilder
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
        public List<ParameterBuilder> Parameters { get; set; }

        public List<AttributeBuilder> Attributes { get; set; }


        public DelegateBuilder Public()
        {
            IsPublic = true;
            return this;
        }
        public DelegateBuilder Private()
        {
            IsPrivate = true;
            return this;
        }
        public DelegateBuilder Partial()
        {
            IsPartial = true;
            return this;
        }
        public DelegateBuilder Protected()
        {
            IsProtected = true;
            return this;
        }
        public DelegateBuilder Internal()
        {
            IsInternal = true;
            return this;
        }
        public DelegateBuilder Abstract()
        {
            IsAbstract = true;
            return this;
        }

        public DelegateBuilder Name(string name)
        {
            DelegateName = name;
            return this;
        }
        
        public DelegateBuilder ReturnType(string returnType)
        {
            DelegateType = returnType;
            return this;
        }


        public DelegateBuilder New()
        {
            IsNew = true;
            return this;
        }

        

        public DelegateBuilder Parameter(Action<ParameterBuilder> func)
        {
            Parameters = Parameters ?? new List<ParameterBuilder>();
            var p = new ParameterBuilder();
            func(p);
            Parameters.Add(p);
            return this;
        }

        public DelegateBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            Attributes = Attributes ?? new List<AttributeBuilder>();
            var attribute = new AttributeBuilder();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }


        public DelegateBuilder Static()
        {
            IsStatic = true;
            return this;
        }

        public DelegateBuilder Sealed()
        {
            IsSealed = true;
            return this;
        }
    }
}