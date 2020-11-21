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
        public static CodeMemberMethod Returns<T>(this CodeMemberMethod method)
        {
            method.ReturnType = new CodeTypeReference(typeof(T));
            return method;
        }
        public static CodeMemberMethod Returns(this CodeMemberMethod method,string type)
        {
            method.ReturnType = new CodeTypeReference(type);
            return method;
        }
        public static CodeMemberMethod ReturnsAsync(this CodeMemberMethod method,string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                type = "Task<" + type + ">";
            }
            else
            {
                type = "Task";
            }
            method.ReturnType = new CodeTypeReference(type);
            return method;
        }
        public static CodeMemberMethod ReturnsAsync<T>(this CodeMemberMethod method)
        {
            var type = typeof(T).FullName;
            if (!string.IsNullOrEmpty(type))
            {
                type = "Task<" + type + ">";
            }
            else
            {
                type = "Task";
            }
            method.ReturnType = new CodeTypeReference(type);
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

        public static CodeMemberMethod AddStatement(this CodeMemberMethod method, CodeStatement codeStatement)
        {
            method.Statements.Add(codeStatement);
            return method;
        }
        public static CodeMemberMethod AddStatement(this CodeMemberMethod method, CodeExpression expression)
        {
            method.Statements.Add(new CodeExpressionStatement(expression));
            return method;
        }
    }
}