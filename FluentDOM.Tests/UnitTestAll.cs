using System;
using System.CodeDom;
using FluentDOM.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentDOM.Tests
{
    [TestClass]
    public class UnitTestAll
    {
        [TestMethod]
        public void Test_Hello_World()
        {
            var unit = new CodeCompileUnit();
            unit
                .Namespace("example1")
                .Import("System")
                .Import("System.IO")
                .AddClass(c => c
                    .Name("Program")
                    .Attributes(MemberAttributes.Public | MemberAttributes.Static)
                    .AddMethod(m =>
                    {
                        m.Name("Main")
                            .Attributes(MemberAttributes.Public | MemberAttributes.Static)
                            .AddParameter(p => p
                                .Name("args")
                                .OfType<string[]>()
                                .Direction(FieldDirection.In)
                            )
                            .AddStatement(s => s
                                .Declare("name")
                                .OfType<string>()
                                .Init(ss => ss.Invoke(null, "Console.ReadLine"))
                            )
                            .AddStatement(s => s
                                .Invoke(null, "Console.WriteLine", s.Primitive("Hello - {0}"), s.Expression(e => e.Variable("name")))
                            )
                            .AddStatement(
                                s => s
                                    .Return(
                                        s.Primitive(0)
                                    )
                            );
                    })
                );
            unit.GenerateCSharpCode().ShouldBeLike(@"
namespace example1 {
    using System;
    using System.IO;
    
    
    public class Program {
        
        public static void Main(string[] args) {
            string name = Console.ReadLine();
            Console.WriteLine(""Hello - {0}"", name);
            return 0;
        }
    }
}

");
        }

        [TestMethod]
        public void Test_Property_WithBackingField()
        {
            var c = new CodeTypeDeclaration("TestClass")
                    .Name("TestClass")
                    .Attributes(MemberAttributes.Public | MemberAttributes.Static)
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
                ;
            c.GenerateCSharpCode().ShouldBeLike(@"
public class TestClass {

    private string _d3;

    [Range(-9223372036854775808, 9223372036854775807, ErrorMessage=""Out Of Range"")]
    private string d3
    {
        get
        {
            return _d3;
        }
        set
        {
            _d3 = value;
        }
    }
}
");
        }
    }
}
