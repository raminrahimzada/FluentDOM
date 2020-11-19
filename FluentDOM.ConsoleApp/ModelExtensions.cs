using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using Newtonsoft.Json;

namespace FluentDOM.ConsoleApp
{
    public static class ModelExtensions
    {
        public static string GenerateCSharpCode(this CodeCompileUnit compileUnit)
        {
            var provider = new CSharpCodeProvider();
            var sb = new StringBuilder();
            IndentedTextWriter tw = new IndentedTextWriter(new StringWriter(sb));
            tw = new IndentedTextWriter(tw, "    ");
            provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                new CodeGeneratorOptions()
                {
                    
                });
            tw.Close();
            return sb.ToString();
        }
        public static string GenerateCSharpCode(this CodeNamespace nameSpace)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            unit.Namespaces.Add(nameSpace);
            return GenerateCSharpCode(unit);
        }
        public static object GetValue(this PrimitiveCodeExpressionModel expression)
        {
            if (expression.ExpressionType == typeof(string).FullName)
            {
                return expression.Expression;
            }else 
            if (expression.ExpressionType == typeof(int).FullName)
            {
                return int.Parse(expression.Expression);
            }else 
            if (expression.ExpressionType == typeof(double).FullName)
            {
                return double.Parse(expression.Expression);
            }

            throw new NotImplementedException();
        }
        public static object GetValue(this PrimitiveReturnStatementModel statement)
        {
            if (long.TryParse(statement.Expression, out var l)) return l;
            if (double.TryParse(statement.Expression, out var d)) return d;

            throw new NotImplementedException();
        }
        public static TypeAttributes GetTypeAttributes(this ClassModel classModel)
        {
            TypeAttributes t = default;
            if (classModel.IsPublic??false)
            {
                t |= TypeAttributes.Public;
            }
            if (classModel.IsAbstract??false)
            {
                t |= TypeAttributes.Abstract;
            }
            if (classModel.IsSealed??false)
            {
                t |= TypeAttributes.Sealed;
            }
            if (classModel.IsPrivate??false)
            {
                t |= TypeAttributes.NestedPrivate;
            }
            if (classModel.IsStatic??false)
            {
                t |= TypeAttributes.Abstract;
                t |= TypeAttributes.Sealed;
            }

            return t;
        }
        public static FieldDirection GetDirection(this ParameterModel parameterModel)
        {
            FieldDirection f = default;
            if (parameterModel.IsIn ?? false)
            {
                f = FieldDirection.In;
            }
            if (parameterModel.IsOut ?? false)
            {
                f = FieldDirection.Out;
            }
            if (parameterModel.IsRef ?? false)
            {
                f = FieldDirection.Ref;
            }

            return f;
        }
        public static CodeTypeReference GetReturnTypeReference(this MethodModel methodModel)
        {
            if (string.IsNullOrWhiteSpace(methodModel.ReturnType))
                return null;
            return new CodeTypeReference(methodModel.ReturnType);
        }
        public static CodeTypeReference GetTypeReference(this PropertyModel propertyModel)
        {
            if (string.IsNullOrWhiteSpace(propertyModel.PropertyType))
                return null;
            return new CodeTypeReference(propertyModel.PropertyType);
        }

        public static MemberAttributes GetMemberAttribute(this MethodModel methodModel)
        {
            MemberAttributes x = default(MemberAttributes);
            if (methodModel.IsPublic??false)
            {
                x |= MemberAttributes.Public;
            }
            if (methodModel.IsPrivate??false)
            {
                x |= MemberAttributes.Private;
            }
            if (methodModel.IsStatic??false)
            {
                x |= MemberAttributes.Static;
            }
            if (methodModel.IsAbstract??false)
            {
                x |= MemberAttributes.Abstract;
            }
            if (methodModel.IsOverride??false)
            {
                x |= MemberAttributes.Override;
            }
            else
            {
                x |= MemberAttributes.Final;
            }
            if (methodModel.IsNew??false)
            {
                x |= MemberAttributes.New;
            }

            return x;
        }
        public static MemberAttributes GetMemberAttribute(this PropertyModel propertyModel)
        {
            MemberAttributes x = default(MemberAttributes);
            if (propertyModel.IsPublic??false)
            {
                x |= MemberAttributes.Public;
            }
            if (propertyModel.IsPrivate??false)
            {
                x |= MemberAttributes.Private;
            }
            if (propertyModel.IsStatic??false)
            {
                x |= MemberAttributes.Static;
            }
            if (propertyModel.IsAbstract??false)
            {
                x |= MemberAttributes.Abstract;
            }
            if (propertyModel.IsOverride??false)
            {
                x |= MemberAttributes.Override;
            }
            if (propertyModel.IsNew??false)
            {
                x |= MemberAttributes.New;
            }

            return x;
        }
    }
}