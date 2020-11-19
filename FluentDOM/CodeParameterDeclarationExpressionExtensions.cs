using System.CodeDom;

namespace FluentDOM
{
    public static class CodeParameterDeclarationExpressionExtensions
    {
        public static CodeParameterDeclarationExpression Name(this CodeParameterDeclarationExpression parameter, string name)
        {
            parameter.Name = name;
            return parameter;
        }
        public static CodeParameterDeclarationExpression OfType<T>(this CodeParameterDeclarationExpression parameter)
        {
            parameter.Type = new CodeTypeReference(typeof(T));
            return parameter;
        }

        public static CodeParameterDeclarationExpression Direction(this CodeParameterDeclarationExpression parameter, FieldDirection direction)
        {
            parameter.Direction = direction;
            return parameter;
        }
        public static CodeParameterDeclarationExpression AddAttribute(this CodeParameterDeclarationExpression parameter, FieldDirection direction)
        {
            parameter.Direction = direction;
            return parameter;
        }
    }
}