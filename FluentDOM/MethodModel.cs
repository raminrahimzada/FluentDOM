using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentDOM
{
    public class MethodModel
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

        public List<ParameterModel> Parameters { get; set; }=new List<ParameterModel>();
        public StatementCollectionModel MethodBody { get; set; }=new StatementCollectionModel();


        public MethodModel Name(string methodName)
        {
            MethodName = methodName;
            return this;
        }

        public MethodModel Public()
        {
            IsPublic = true;
            return this;
        }
        public MethodModel Private()
        {
            IsPrivate = true;
            return this;
        }
        public MethodModel Internal()
        {
            IsInternal = true;
            return this;
        }
        public MethodModel Static()
        {
            IsStatic = true;
            return this;
        }
        public MethodModel Override()
        {
            IsOverride = true;
            return this;
        }
        public MethodModel Protected()
        {
            IsProtected = true;
            return this;
        }
        public MethodModel Sealed()
        {
            IsSealed = true;
            return this;
        }
        public MethodModel Abstract()
        {
            IsAbstract = true;
            return this;
        }
        public MethodModel Partial()
        {
            IsPartial = true;
            return this;
        }

        public MethodModel AddParameter(Action<ParameterModel> func)
        {
            Parameters = Parameters ?? new List<ParameterModel>();
            var p = new ParameterModel();
            func(p);
            Parameters.Add(p);
            return this;
        }

        public MethodModel Body(Action<StatementCollectionModel> action)
        {
            MethodBody = new StatementCollectionModel();
            action(MethodBody);
            return this;
        }

        public MethodModel New()
        {
            IsNew= true;
            return this;
        }

        
        public MethodModel Returns(string returnType)
        {
            ReturnType = returnType;
            return this;
        }
        public MethodModel Returns<T>()
        {
            ReturnType = typeof(T).FullName;
            return this;
        }
        
        public MethodModel ReturnsVoid()
        {
            Returns(null);
            return this;
        }
    }
}