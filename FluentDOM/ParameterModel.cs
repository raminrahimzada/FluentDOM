using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class ParameterModel
    {
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public bool? IsIn { get; set; }
        public bool? IsOut { get; set; }
        public bool? IsRef { get; set; }
        public List<AttributeModel> Attributes { get; set; }

        public ParameterModel Name(string name)
        {
            ParameterName = name;
            return this;
        }

        public ParameterModel Type(string type)
        {
            ParameterType = type;
            return this;
        }
        public ParameterModel Type<T>()
        {
            ParameterType = typeof(T).FullName;
            return this;
        }

        public ParameterModel In()
        {
            IsIn = true;
            return this;
        }
        public ParameterModel Out()
        {
            IsOut = true;
            return this;
        }
        public ParameterModel Ref()
        {
            IsRef = true;
            return this;
        }

        public ParameterModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
    }
}