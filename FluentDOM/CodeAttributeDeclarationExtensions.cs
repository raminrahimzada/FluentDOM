using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeAttributeDeclarationExtensions
    {
        public static CodeAttributeDeclaration OfType<T>(this CodeAttributeDeclaration attribute)
        {
            attribute.Name = typeof(T).FullName;
            return attribute;
        }
        public static CodeAttributeDeclaration OfType(this CodeAttributeDeclaration attribute,string name)
        {
            attribute.Name = name;
            return attribute;
        }
        public static CodeAttributeDeclaration AddArgument(this CodeAttributeDeclaration attribute,Action<CodeAttributeArgument> action)
        {
            var a = new CodeAttributeArgument();
            attribute.Arguments.Add(a);
            action(a);
            return attribute;
        }
    }
}