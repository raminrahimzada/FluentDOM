using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeAttributeArgumentExtensions
    {
        public static CodeAttributeArgument Name(this CodeAttributeArgument property, string name)
        {
            property.Name = name;
            return property;
        }
        public static CodeAttributeArgument Value(this CodeAttributeArgument property, CodeExpression value)
        {
            property.Value = value;
            return property;
        }
        public static CodeAttributeArgument Value(this CodeAttributeArgument property, Action<CodeExpressionBuilder> action)
        {
            var ex = new CodeExpressionBuilder();
            action(ex);
            property.Value=ex.Build();
            return property;
        }
    }
}