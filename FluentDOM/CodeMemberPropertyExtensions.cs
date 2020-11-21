using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeMemberPropertyExtensions
    {
        public static CodeMemberProperty Attributes(this CodeMemberProperty property, MemberAttributes attributes)
        {
            property.Attributes = attributes;
            return property;
        }
        public static CodeMemberProperty Name(this CodeMemberProperty property, string name)
        {
            property.Name = name;
            return property;
        }
        public static CodeMemberProperty Name<T>(this CodeMemberProperty property, string name)
        {
            return property.Name(name).OfType<T>();
        }
        public static CodeMemberProperty OfType<T>(this CodeMemberProperty property)
        {
            property.Type = new CodeTypeReference(typeof(T));
            return property;
        }
        public static CodeMemberProperty AddComment(this CodeMemberProperty property,string comment)
        {
            property.Comments.Add(new CodeCommentStatement(comment));
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
            if (action == null)
            {
                property.HasGet = false;
                return property;
            }
            var a = new CodeStatementCollectionBuilder();
            action(a);
            property.GetStatements.AddRange(a.Build());
            return property;
        }
        public static CodeMemberProperty Set(this CodeMemberProperty property,Action<CodeStatementCollectionBuilder> action)
        {
            if (action == null)
            {
                property.HasSet = false;
                return property;
            }
            var a = new CodeStatementCollectionBuilder();
            action(a);
            property.SetStatements.AddRange(a.Build());
            return property;
        }
    }
}