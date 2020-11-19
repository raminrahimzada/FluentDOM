using System.CodeDom;

namespace FluentDOM
{
    public class CodeExpressionBuilder
    {
        private CodeExpression _codeExpression;

        public CodeExpression Build()
        {
            return _codeExpression;
        }

        public CodeMethodInvokeExpression Invoke(CodeExpression targetObject, string methodName, params CodeExpression[] parameters)
        {
            var codeExpression = new CodeMethodInvokeExpression(targetObject, methodName, parameters);
            _codeExpression = codeExpression;
            return codeExpression;
        }

        public CodeVariableReferenceExpression Variable(string name)
        {
            var codeExpression = new CodeVariableReferenceExpression(name);
            _codeExpression = codeExpression;
            return codeExpression;
        }
        public CodePrimitiveExpression Primitive(object value)
        {
            var codeExpression = new CodePrimitiveExpression(value);
            _codeExpression = codeExpression;
            return codeExpression;
        }
    }
}