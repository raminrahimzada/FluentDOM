using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class ConstructorModel
    {
        public List<ParameterModel> Parameters { get; set; }
        public ConstructorModel AddParameter(Action<ParameterModel> func)
        {
            Parameters = Parameters ?? new List<ParameterModel>();
            var p=new ParameterModel();
            func(p);
            Parameters.Add(p);
            return this;
        }
    }
}