using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class AttributeModel
    {
        public string AttributeName { get; set; }
        public List<AttributeParameterModel> Parameters { get; set; }=new List<AttributeParameterModel>();

        public AttributeModel Name(string name)
        {
            AttributeName = name;
            return this;
        }

        public AttributeModel AddParameter(Action<AttributeParameterModel> func)
        {
            Parameters = Parameters ?? new List<AttributeParameterModel>();
            var p = new AttributeParameterModel();
            func(p);
            Parameters.Add(p);
            return this;
        }
    }
}