using System;
using System.CodeDom;
using System.Linq;

namespace FluentDOM.ConsoleApp
{
    public class Compiler
    {
        //public static NamespaceBuilder Decompile(CodeNamespace c)
        //{
        //    NamespaceBuilder b = NamespaceBuilder.New(c.Name);
        //    b.Imports = new List<string>();
        //    foreach (var import in c.Imports)
        //    {
        //        b.Imports.Add(import.ToString());
        //    }

        //    return b;
        //}
        public static CodeNamespace Compile(NamespaceModel b)
        {
            var codeNamespace = new CodeNamespace(b.NameSpaceName);
            
            foreach (var import in b.Imports)
            {
                codeNamespace.Imports.Add(new CodeNamespaceImport(import));
            }

            //classes
            foreach (ClassModel classBuilder in b.Classes)
            {
                var classType = new CodeTypeDeclaration(classBuilder.ClassName)
                {
                    IsClass = true, TypeAttributes = classBuilder.GetTypeAttributes()
                };
                foreach (var @interface in classBuilder.Interfaces)
                {
                    classType.BaseTypes.Add(new CodeTypeReference(@interface));
                }

                if (!string.IsNullOrWhiteSpace(classBuilder.BaseClass))
                    classType.BaseTypes.Add(new CodeTypeReference(classBuilder.BaseClass));

                if (classBuilder.IsPartial != null) classType.IsPartial = classBuilder.IsPartial.Value;

                //attributes
                classType.CustomAttributes.AddRange(classBuilder.Attributes.Select(CompileAttribute).ToArray());

                //properties
                foreach (var propertyBuilder in classBuilder.Properties)
                {
                    var prop = CompileProperty(propertyBuilder);
                    classType.Members.Add(prop);
                }

                //methods
                foreach (var methodBuilder in classBuilder.Methods)
                {
                    var method = CompileMethod(methodBuilder);
                    classType.Members.Add(method);
                }
                codeNamespace.Types.Add(classType);
            }

            //bunlari heleki bos ver
            foreach (var interfaceBuilder in b.Interfaces)
            {
                var classType = new CodeTypeDeclaration(interfaceBuilder.InterfaceName);
                classType.IsInterface = true;
                if (interfaceBuilder.IsPartial != null) classType.IsPartial = interfaceBuilder.IsPartial.Value;


                foreach (var attributeBuilder in interfaceBuilder.Attributes)
                {
                    var a = new CodeAttributeDeclaration(attributeBuilder.AttributeName);
                    foreach (var attributeParameterBuilder in attributeBuilder.Parameters)
                    {
                        a.Arguments.Add(new CodeAttributeArgument(attributeParameterBuilder.ParameterName,
                            new CodePrimitiveExpression(attributeParameterBuilder.ParameterValue)));
                    }
                    classType.CustomAttributes.Add(a);
                }
                codeNamespace.Types.Add(classType);
            }

            return codeNamespace;
        }

        private static CodeAttributeDeclaration CompileAttribute(AttributeModel attributeModel)
        {
            var a = new CodeAttributeDeclaration(attributeModel.AttributeName);
            foreach (var attributeParameterBuilder in attributeModel.Parameters)
            {
                a.Arguments.Add(new CodeAttributeArgument(attributeParameterBuilder.ParameterName,
                    new CodePrimitiveExpression(attributeParameterBuilder.ParameterValue)));
            }

            return a;
        }

        private static CodeMemberMethod CompileMethod(MethodModel methodModel)
        {
            var method = new CodeMemberMethod
            {
                Name = methodModel.MethodName,
                ReturnType = methodModel.GetReturnTypeReference(),
                Attributes = methodModel.GetMemberAttribute()
            };
            foreach (var parameterBuilder in methodModel.Parameters)
            {
                var p = new CodeParameterDeclarationExpression(parameterBuilder.ParameterType,
                    parameterBuilder.ParameterName);
                p.CustomAttributes.AddRange(parameterBuilder.Attributes.Select(CompileAttribute).ToArray());
                p.Direction = parameterBuilder.GetDirection();
                method.Parameters.Add(p);
            }

            foreach (var abstractStatementBuilder in methodModel.MethodBody.Statements)
            {
                CodeStatement expression=CompileStatement(abstractStatementBuilder);
                method.Statements.Add(expression);
            }
            
            return method;
        }
        //todo think about that :)
        private static CodeStatement CompileStatement(AbstractStatementModel abstractStatementModel)
        {
            switch (abstractStatementModel)
            {
                case EmptyReturnStatementModel e: return CompileStatement(e);
                case PrimitiveReturnStatementModel e: return CompileStatement(e);
                case ComplexReturnStatementModel e: return CompileStatement(e);
            }

            throw new NotImplementedException("This Builder is not implemented");
        }
        private static CodeStatement CompileStatement(EmptyReturnStatementModel _)
        {
            return new CodeMethodReturnStatement();
        }
        private static CodeStatement CompileStatement(PrimitiveReturnStatementModel statement)
        {
            return new CodeMethodReturnStatement(new CodePrimitiveExpression(statement.GetValue()));
        }
        private static CodeStatement CompileStatement(ComplexReturnStatementModel statement)
        {
            return new CodeMethodReturnStatement(CompileExpression(statement.Expression));
        }

        private static CodeExpression CompileExpression(PrimitiveCodeExpressionModel expression)
        {
            return new CodePrimitiveExpression(expression.GetValue());
        }
        private static CodeExpression CompileExpression(VariableExpressionModel expression)
        {
            return new CodeVariableReferenceExpression(expression.VariableName);
        }
        private static CodeExpression CompileExpression(BinaryOperationExpressionModel expression)
        {
            var left = CompileExpression(expression.Left);
            var right = CompileExpression(expression.Right);
            return new CodeBinaryOperatorExpression(left, expression.ExpressionType, right);
        }
        
        private static CodeExpression CompileExpression(AbstractCodeExpressionModel expression)
        {
            switch (expression)
            {
                case PrimitiveCodeExpressionModel e: return CompileExpression(e);
                case VariableExpressionModel e: return CompileExpression(e);
                case BinaryOperationExpressionModel e: return CompileExpression(e);
            }

            throw new NotImplementedException();
        }

        private static CodeMemberProperty CompileProperty(PropertyModel propertyModel)
        {
            var prop = new CodeMemberProperty();
            if (propertyModel.HasGet != null)
                prop.HasGet = propertyModel.HasGet.Value;

            if (propertyModel.HasSet != null)
                prop.HasSet = propertyModel.HasSet.Value;
            prop.Name = propertyModel.PropertyName;
            prop.Type = propertyModel.GetTypeReference();
            prop.Attributes = propertyModel.GetMemberAttribute();
            prop.CustomAttributes.AddRange(propertyModel.Attributes.Select(CompileAttribute).ToArray());

            // https://stackoverflow.com/questions/13679171/how-to-generate-empty-get-set-statements-using-codedom-in-c-sharp
            if (propertyModel.Get.IsDefault??false)
            {

            }
            
            return prop;
        }
    }
}