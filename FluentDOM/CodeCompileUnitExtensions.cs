using System.CodeDom;

namespace FluentDOM
{
    public static class CodeCompileUnitExtensions
    {
        public static CodeNamespace Namespace(this CodeCompileUnit codeCompileUnit,string name)
        {
            var nameSpace = new CodeNamespace(name);
            codeCompileUnit.Namespaces.Add(nameSpace);
            return nameSpace;
        }
       
    }
}