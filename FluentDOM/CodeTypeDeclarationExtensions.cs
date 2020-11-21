using System;
using System.CodeDom;
using System.Reflection;

namespace FluentDOM
{
    public static class CodeTypeDeclarationExtensions
    {
        public static CodeTypeDeclaration TypeAttributes(this CodeTypeDeclaration classType, TypeAttributes attribute)
        {
            classType.TypeAttributes = attribute;
            return classType;
        }
        public static CodeTypeDeclaration Attributes(this CodeTypeDeclaration classType, MemberAttributes attribute)
        {
            classType.Attributes = attribute;
            return classType;
        }
        public static CodeTypeDeclaration Name(this CodeTypeDeclaration classType, string name)
        {
            classType.Name = name;
            return classType;
        }
        public static CodeTypeDeclaration Extends(this CodeTypeDeclaration classType, string typeName)
        {
            classType.BaseTypes.Add(new CodeTypeReference(typeName));
            return classType;
        }
        public static CodeTypeDeclaration ExtendsGeneric(this CodeTypeDeclaration classType, string typeName,params string[] typeArgs)
        {
            var type = new CodeTypeReference(typeName);
            foreach (var typeArg in typeArgs)
            {
                type.TypeArguments.Add(new CodeTypeReference(typeArg));
            }

            classType.BaseTypes.Add(type);
            return classType;
        }
        public static CodeTypeDeclaration ExtendsGeneric(this CodeTypeDeclaration classType, CodeTypeReference type)
        {
            classType.BaseTypes.Add(type);
            return classType;
        }
        public static CodeTypeDeclaration AddTypeParameter(this CodeTypeDeclaration classType, Action<CodeTypeParameter> action)
        {
            var p = new CodeTypeParameter();
            action(p);
            classType.TypeParameters.Add(p);
            return classType;
        }
        public static CodeTypeDeclaration AddMethod(this CodeTypeDeclaration classType, Action<CodeMemberMethod> func)
        {
            var m = new CodeMemberMethod();
            func(m);
            classType.Members.Add(m);
            return classType;
        }
        public static CodeTypeDeclaration AddEntryPoint(this CodeTypeDeclaration classType, Action<CodeEntryPointMethod> func)
        {
            var m = new CodeEntryPointMethod();
            func(m);
            classType.Members.Add(m);
            return classType;
        }
        public static CodeTypeDeclaration AddConstructor(this CodeTypeDeclaration classType, Action<CodeConstructor> func)
        {
            var m = new CodeConstructor();
            func(m);
            classType.Members.Add(m);
            return classType;
        }
        public static CodeTypeDeclaration AddField(this CodeTypeDeclaration classType, Action<CodeMemberField> func)
        {
            var f = new CodeMemberField();
            func(f);
            classType.Members.Add(f);
            return classType;
        }
        public static CodeTypeDeclaration AddProperty(this CodeTypeDeclaration classType, Action<CodeMemberProperty> func)
        {
            var p = new CodeMemberProperty();
            func(p);
            classType.Members.Add(p);
            return classType;
        }


        public static CodeTypeDeclaration Extends(this CodeTypeDeclaration classType, CodeTypeReference typeReference)
        {
            classType.BaseTypes.Add(typeReference);
            return classType;
        }
    }
}