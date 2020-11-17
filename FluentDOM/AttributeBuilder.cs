using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class AttributeBuilder
    {
        public string AttributeName { get; set; }
        public List<AttributeParameterBuilder> Parameters { get; set; }

        public AttributeBuilder Name(string name)
        {
            AttributeName = name;
            return this;
        }

        public AttributeBuilder AddParameter(Action<AttributeParameterBuilder> func)
        {
            Parameters = Parameters ?? new List<AttributeParameterBuilder>();
            var p = new AttributeParameterBuilder();
            func(p);
            Parameters.Add(p);
            return this;
        }
    }
}