using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class ParameterBuilder
    {
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public bool? IsIn { get; set; }
        public bool? IsOut { get; set; }
        public bool? IsRef { get; set; }
        public List<AttributeBuilder> Attributes { get; set; }

        public ParameterBuilder Name(string name)
        {
            ParameterName = name;
            return this;
        }

        public ParameterBuilder Type(string type)
        {
            ParameterType = type;
            return this;
        }

        public ParameterBuilder In()
        {
            IsIn = true;
            return this;
        }
        public ParameterBuilder Out()
        {
            IsOut = true;
            return this;
        }
        public ParameterBuilder Ref()
        {
            IsRef = true;
            return this;
        }

        public ParameterBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            Attributes = Attributes ?? new List<AttributeBuilder>();
            var attribute = new AttributeBuilder();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
    }
}