using System.CodeDom;

namespace FluentDOM
{
    public static class CodeMemberFieldExtensions
    {
        public static CodeMemberField Name(this CodeMemberField field, string name)
        {
            field.Name = name;
            return field;
        }
        public static CodeMemberField OfType<T>(this CodeMemberField field)
        {
            field.Type = new CodeTypeReference(typeof(T));
            return field;
        }
        public static CodeMemberField Attributes(this CodeMemberField field, MemberAttributes attributes)
        {
            field.Attributes = attributes;
            return field;
        }
        public static CodeMemberField AddComment(this CodeMemberField field, string comment)
        {
            field.Comments.Add(new CodeCommentStatement(comment));
            return field;
        }
    }
}