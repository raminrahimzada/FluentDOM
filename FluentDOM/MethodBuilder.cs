using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentDOM
{
    public class MethodBuilder
    {
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public bool? IsAbstract { get; set; }
        public bool? IsSealed { get; set; }
        public bool? IsOverride { get; set; }
        public bool? IsStatic { get; set; }
        public string MethodName { get; set; }
        public bool? IsNew { get; set; }
        public string ReturnType { get; set; }

        public List<ParameterBuilder> Parameters { get; set; }
        public StatementsBuilder MethodBody { get; set; }


        public MethodBuilder Name(string methodName)
        {
            MethodName = methodName;
            return this;
        }

        public MethodBuilder Public()
        {
            IsPublic = true;
            return this;
        }
        public MethodBuilder Private()
        {
            IsPrivate = true;
            return this;
        }
        public MethodBuilder Internal()
        {
            IsInternal = true;
            return this;
        }
        public MethodBuilder Static()
        {
            IsStatic = true;
            return this;
        }
        public MethodBuilder Override()
        {
            IsOverride = true;
            return this;
        }
        public MethodBuilder Protected()
        {
            IsProtected = true;
            return this;
        }
        public MethodBuilder Sealed()
        {
            IsSealed = true;
            return this;
        }
        public MethodBuilder Abstract()
        {
            IsAbstract = true;
            return this;
        }
        public MethodBuilder Partial()
        {
            IsPartial = true;
            return this;
        }

        public MethodBuilder AddParameter(Action<ParameterBuilder> func)
        {
            Parameters = Parameters ?? new List<ParameterBuilder>();
            var p = new ParameterBuilder();
            func(p);
            Parameters.Add(p);
            return this;
        }

        public MethodBuilder Body(Action<StatementsBuilder> action)
        {
            MethodBody = new StatementsBuilder();
            action(MethodBody);
            return this;
        }

        public MethodBuilder New()
        {
            IsNew= true;
            return this;
        }

        
        public MethodBuilder Returns(string returnType)
        {
            ReturnType = returnType;
            return this;
        }
        public MethodBuilder Returns<T>()
        {
            ReturnType = typeof(T).FullName;
            return this;
        }
        
        public MethodBuilder ReturnsVoid()
        {
            Returns(null);
            return this;
        }
    }
}