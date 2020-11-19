using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeMemberMethodExtensions
    {
        public static CodeMemberMethod AddParameter(this CodeMemberMethod method, Action<CodeParameterDeclarationExpression> func)
        {
            CodeParameterDeclarationExpression p = new CodeParameterDeclarationExpression();
            func(p);
            method.Parameters.Add(p);
            return method;
        }
        public static CodeMemberMethod Name(this CodeMemberMethod method, string name)
        {
            method.Name = name;
            return method;
        }
        public static CodeMemberMethod Attributes(this CodeMemberMethod method, MemberAttributes attribute)
        {
            method.Attributes = attribute;
            return method;
        }
        public static CodeMemberMethod AddStatement(this CodeMemberMethod method, Action<CodeStatementBuilder> action)
        {
            var s = new CodeStatementBuilder();
            action(s);
            method.Statements.Add(s.Build());
            return method;
        }

    }
}