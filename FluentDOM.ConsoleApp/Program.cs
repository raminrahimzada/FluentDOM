using System.CodeDom;
using System.IO;
using Microsoft.CSharp;
using Newtonsoft.Json;

namespace FluentDOM.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var unit = new CodeCompileUnit();
            unit
                .Namespace("example1")
                .Import("System")
                .Import("System.IO")
                .AddClass(c => c
                    .Name("TestClass")
                    .Attributes(MemberAttributes.Public|MemberAttributes.Static)
                    .AddField(f => f.Name("_d3").OfType<string>())
                    .AddProperty(p =>
                    {
                        p
                            .Name("d3")
                            .OfType<string>()
                            .AddAttribute(attr => attr
                                .OfType("Range")
                                .AddArgument(a => a.Value(w => w.Primitive(long.MinValue)))
                                .AddArgument(a => a.Value(w => w.Primitive(long.MaxValue)))
                                .AddArgument(a => a.Name("ErrorMessage").Value(w => w.Primitive("Out Of Range")))
                            )
                            .Get(s => s.Return(s.Variable("_d3")))
                            .Set(s => s.Assign(s.Variable("_d3"), s.Variable("value")));
                    })
                );
            File.WriteAllText("lib.cs", unit.GenerateCSharpCode());
        }
    }
}
