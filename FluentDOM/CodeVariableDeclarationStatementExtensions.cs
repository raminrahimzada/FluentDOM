using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeVariableDeclarationStatementExtensions
    {
        public static CodeVariableDeclarationStatement OfType<T>(this CodeVariableDeclarationStatement statement)
        {
            statement.Type = new CodeTypeReference(typeof(T));
            return statement;
        }
        public static CodeVariableDeclarationStatement Init(this CodeVariableDeclarationStatement statement,Action<CodeExpressionBuilder> action)
        {
            var ss=new CodeExpressionBuilder();
            action(ss);
            statement.InitExpression = ss.Build();
            return statement;
        }
    }
}