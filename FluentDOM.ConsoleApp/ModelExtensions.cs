using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CSharp;

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
        public static string GenerateCSharpCode(this CodeTypeDeclaration compileUnit)
        {
            var provider = new CSharpCodeProvider();
            var sb = new StringBuilder();
            IndentedTextWriter tw = new IndentedTextWriter(new StringWriter(sb));
            tw = new IndentedTextWriter(tw, "    ");
            provider.GenerateCodeFromType(compileUnit, tw,
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
    }
}