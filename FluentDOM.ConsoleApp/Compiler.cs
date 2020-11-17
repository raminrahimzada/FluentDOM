using System;
using System.CodeDom;
using System.Collections.Generic;
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
        public static CodeNamespace Compile(NamespaceBuilder b)
        {
            var codeNamespace = new CodeNamespace(b.NameSpaceName);
            
            foreach (var import in b.Imports)
            {
                codeNamespace.Imports.Add(new CodeNamespaceImport(import));
            }

            //classes
            foreach (ClassBuilder classBuilder in b.Classes)
            {
                var classType = new CodeTypeDeclaration(classBuilder.ClassName)
                {
                    IsClass = true, TypeAttributes = classBuilder.GetTypeAttributes()
                };

                foreach (var @interface in classBuilder.Interfaces)
                {
                    classType.BaseTypes.Add(new CodeTypeReference(@interface));
                }
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

        private static CodeAttributeDeclaration CompileAttribute(AttributeBuilder attributeBuilder)
        {
            var a = new CodeAttributeDeclaration(attributeBuilder.AttributeName);
            foreach (var attributeParameterBuilder in attributeBuilder.Parameters)
            {
                a.Arguments.Add(new CodeAttributeArgument(attributeParameterBuilder.ParameterName,
                    new CodePrimitiveExpression(attributeParameterBuilder.ParameterValue)));
            }

            return a;
        }

        private static CodeMemberMethod CompileMethod(MethodBuilder methodBuilder)
        {
            var method = new CodeMemberMethod
            {
                Name = methodBuilder.MethodName,
                ReturnType = methodBuilder.GetReturnTypeReference(),
                Attributes = methodBuilder.GetMemberAttribute()
            };
            foreach (var parameterBuilder in methodBuilder.Parameters)
            {
                var p = new CodeParameterDeclarationExpression(parameterBuilder.ParameterType,
                    parameterBuilder.ParameterName);
                p.CustomAttributes.AddRange(parameterBuilder.Attributes.Select(CompileAttribute).ToArray());
                p.Direction = parameterBuilder.GetDirection();
                method.Parameters.Add(p);
            }

            CodeStatement x = new CodeMethodReturnStatement(new CodePrimitiveExpression("xiyar"));
            method.Statements.Add(x);
            return method;
        }

        private static CodeMemberProperty CompileProperty(PropertyBuilder propertyBuilder)
        {
            var prop = new CodeMemberProperty();
            if (propertyBuilder.HasGet != null)
                prop.HasGet = propertyBuilder.HasGet.Value;

            if (propertyBuilder.HasSet != null)
                prop.HasSet = propertyBuilder.HasSet.Value;
            prop.Name = propertyBuilder.PropertyName;
            prop.Type = propertyBuilder.GetTypeReference();
            prop.Attributes = propertyBuilder.GetMemberAttribute();
            prop.CustomAttributes.AddRange(propertyBuilder.Attributes.Select(CompileAttribute).ToArray());

            // https://stackoverflow.com/questions/13679171/how-to-generate-empty-get-set-statements-using-codedom-in-c-sharp
            if (propertyBuilder.Get.IsDefault??false)
            {

            }
            
            return prop;
        }
    }
}