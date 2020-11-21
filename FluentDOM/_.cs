using System.CodeDom;
using System.Linq;

namespace FluentDOM
{
    public static class _
    {
        
        public static CodeThrowExceptionStatement Throw(CodeExpression toThrow)
        {
            return new CodeThrowExceptionStatement(toThrow);
        }
        public static CodePrimitiveExpression Primitive(object value)
        {
            return new CodePrimitiveExpression(value);
        }
        public static CodePrimitiveExpression Null()
        {
            return new CodePrimitiveExpression(null);
        }
       
        public static CodeObjectCreateExpression Create<T>(params CodeExpression[] parameters)
        {
            var s = new CodeObjectCreateExpression(typeof(T).FullName);
            s.Parameters.AddRange(parameters);
            return s;
        }
        public static CodeVariableReferenceExpression Variable(string varName)
        {
            return new CodeVariableReferenceExpression(varName);
        }
        public static CodeThisReferenceExpression This()
        {
            return new CodeThisReferenceExpression();
        }

        public static CodeFieldReferenceExpression Field(CodeExpression targetObject, string fieldName)
        {
            return new CodeFieldReferenceExpression(targetObject, fieldName);
        }

        public static CodeExpression Binary(CodeExpression left, CodeBinaryOperatorType op, CodeExpression right)
        {
            return new CodeBinaryOperatorExpression(left, op, right);
        }

        public static CodeMethodInvokeExpression Invoke(CodeTypeReference targetObject, string methodName,
            params CodeExpression[] parameters)
        {
            return Invoke(new CodeTypeReferenceExpression(targetObject), methodName, parameters);
        }
        public static CodeMethodInvokeExpression Invoke(CodeExpression targetObject, string methodName, params CodeExpression[] parameters)
        {
            return new CodeMethodInvokeExpression(targetObject, methodName, parameters);
        }

        public static CodeTypeReferenceExpression Type(string typeName)
        {
            return new CodeTypeReferenceExpression(typeName);
        }
        
        public static CodeTypeReference Type(string typeName,params  string[] genericTypeArgs)
        {
            var t = new CodeTypeReference(typeName);
            t.TypeArguments.AddRange(genericTypeArgs.Select(g => new CodeTypeReference(g)).ToArray());
            return t;
        }
        public static CodeTypeReferenceExpression Type<T>(params string[] genericTypeArgs)
        {
            var t = new CodeTypeReferenceExpression(typeof(T));
            t.Type.TypeArguments.AddRange(genericTypeArgs.Select(g => new CodeTypeReference(g)).ToArray());
            return t;
        }
        public static CodeTypeReferenceExpression Type<T>()
        {
            var t = new CodeTypeReferenceExpression(typeof(T));
            return t;
        }
        public static CodeTypeReferenceExpression TypeOf<T>()
        {
            return TypeOf(typeof(T).FullName);
        }
        public static CodeTypeReferenceExpression TypeOf(string type)
        {
            var expression = new CodeTypeReferenceExpression(new CodeTypeReference(type));
            return expression;
        }

        public static CodeObjectCreateExpression Create(string type,params CodeExpression[] parameters)
        {
            return new CodeObjectCreateExpression(type,parameters);
        }
            
        public static CodeObjectCreateExpression Create(CodeTypeReference type,params CodeExpression[] parameters)
        {
            return new CodeObjectCreateExpression(type,parameters);
        }
        public static CodeObjectCreateExpression Create(CodeTypeReferenceExpression type,params CodeExpression[] parameters)
        {
            return new CodeObjectCreateExpression(type.Type,parameters);
        }

        public static CodeVariableDeclarationStatement Declare(string varName)
        {
            return new CodeVariableDeclarationStatement() {Name = varName};
        }
        public static CodeVariableDeclarationStatement Declare<T>(string varName)
        {
            return new CodeVariableDeclarationStatement {Name = varName, Type = new CodeTypeReference(typeof(T))};
        }

        public static CodeExpression Create(CodeTypeReference type)
        {
            return new CodeObjectCreateExpression(type);
        }
    }
}