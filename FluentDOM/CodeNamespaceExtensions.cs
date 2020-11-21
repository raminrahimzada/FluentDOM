using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeNamespaceExtensions
    {
        public static CodeNamespace Import(this CodeNamespace codeNamespace, string name)
        {
            codeNamespace.Imports.Add(new CodeNamespaceImport(name));
            return codeNamespace;
        }
        public static CodeNamespace AddClass(this CodeNamespace codeNamespace, Action<CodeTypeDeclaration> func)
        {
            var classType = new CodeTypeDeclaration();
            classType.IsClass = true;
            func(classType);
            codeNamespace.Types.Add(classType);
            return codeNamespace;
        }
        public static CodeNamespace AddInterface(this CodeNamespace codeNamespace, Action<CodeTypeDeclaration> func)
        {
            var @interface = new CodeTypeDeclaration();
            @interface.IsInterface = true;
            func(@interface);
            codeNamespace.Types.Add(@interface);
            return codeNamespace;
        }
    }
}