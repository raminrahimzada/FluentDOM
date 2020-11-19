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
        public static CodeVariableDeclarationStatement OfType(this CodeVariableDeclarationStatement statement,string type)
        {
            statement.Type = new CodeTypeReference(type);
            return statement;
        }
        public static CodeVariableDeclarationStatement Init(this CodeVariableDeclarationStatement statement,CodeExpression expression)
        {
            statement.InitExpression = expression;
            return statement;
        }
    }
}