using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CSharp;

namespace FluentDOM
{
    public static class Extensions
    {
        public static void WriteToFile(this string content, string file)
        {
            File.WriteAllText(file, content);
        }
        public static string FirstToLower(this string content)
        {
            if (string.IsNullOrEmpty(content)) return content;
            if (content.Length == 1) return content.ToLower();
            return char.ToLowerInvariant(content[0]) + content.Substring(1);
        }
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