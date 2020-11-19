using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeMemberPropertyExtensions
    {
        public static CodeMemberProperty Name(this CodeMemberProperty property, string name)
        {
            property.Name = name;
            return property;
        }
        public static CodeMemberProperty OfType<T>(this CodeMemberProperty property)
        {
            property.Type = new CodeTypeReference(typeof(T));
            return property;
        }
        public static CodeMemberProperty AddAttribute(this CodeMemberProperty property,Action<CodeAttributeDeclaration> action)
        {
            var a = new CodeAttributeDeclaration();
            action(a);
            property.CustomAttributes.Add(a);
            return property;
        }
        public static CodeMemberProperty Get(this CodeMemberProperty property,Action<CodeStatementCollectionBuilder> action)
        {
            var a = new CodeStatementCollectionBuilder();
            action(a);
            property.GetStatements.AddRange(a.Build());
            return property;
        }
        public static CodeMemberProperty Set(this CodeMemberProperty property,Action<CodeStatementCollectionBuilder> action)
        {
            var a = new CodeStatementCollectionBuilder();
            action(a);
            property.SetStatements.AddRange(a.Build());
            return property;
        }
    }
}