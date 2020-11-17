using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class ConstructorBuilder
    {
        public List<ParameterBuilder> Parameters { get; set; }
        public ConstructorBuilder AddParameter(Action<ParameterBuilder> func)
        {
            Parameters = Parameters ?? new List<ParameterBuilder>();
            var p=new ParameterBuilder();
            func(p);
            Parameters.Add(p);
            return this;
        }
    }
}