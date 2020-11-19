using System;
using System.CodeDom;

namespace FluentDOM
{
    public class CodeStatementBuilder
    {
        private CodeStatement _statement;
        public CodeStatement Build()
        {
            return _statement;
        }
        public void Return(CodeExpression expression)
        {
            _statement = new CodeMethodReturnStatement(expression);
        }
        public CodeMethodInvokeExpression Invoke(CodeMethodReferenceExpression targetObject,params  CodeExpression[] parameters)
        {
            var expression = new CodeMethodInvokeExpression(targetObject, parameters);
            _statement = new CodeExpressionStatement(expression);
            return expression;
        }
        public CodeMethodInvokeExpression Invoke(CodeExpression targetObject,string methodName, params CodeExpression[] parameters)
        {
            var expression = new CodeMethodInvokeExpression(targetObject, methodName, parameters);
            _statement = new CodeExpressionStatement(expression);
            return expression;
        }

        public CodeVariableDeclarationStatement Declare(string name)
        {
            var statement=new CodeVariableDeclarationStatement();
            statement.Name = name;
            _statement=statement;
            return statement;
        }

        public void Assign(CodeExpression left, CodeExpression right)
        {
            var a = new CodeAssignStatement(left, right);
            _statement = a;
        }
    }
}