using System;
using System.CodeDom;
using System.Reflection;
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
                    .AddMethod(m => m.Name("Main")
                        .Attributes(MemberAttributes.Public | MemberAttributes.Static)
                        .AddParameter(p => p
                            .Name("args")
                            .OfType<string[]>()
                            .Direction(FieldDirection.In)
                        )
                        .AddStatement(s => s
                            .Declare("name")
                            .OfType<string>()
                            .Init(_.Invoke(null, "Console.ReadLine"))
                        )
                        .AddStatement(s => s
                            .Invoke(null, "Console.WriteLine", _.Primitive("Hello - {0}"), _.Variable("name"))
                        )
                        .AddStatement(
                            s => s
                                .Return(_.Primitive(0))
                        ))
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
                    .AddProperty(p => p
                        .Name("d3")
                        .OfType<string>()
                        .AddAttribute(attr => attr
                            .OfType("Range")
                            .AddArgument(a => a.Value(_.Primitive(long.MinValue)))
                            .AddArgument(a => a.Value(_.Primitive(long.MaxValue)))
                            .AddArgument(a => a.Name("ErrorMessage").Value(_.Primitive("Out Of Range")))
                        )
                        .Get(s => s.Return(_.Variable("_d3")))
                        .Set(s => s.Assign(_.Variable("_d3"), _.Variable("value"))))
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


        /// <summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/how-to-create-a-class-using-codedom"/>
        /// </summary>
        [TestMethod]
        public void Test_Microsoft_Example()
        {
            var unit = new CodeNamespace("CodeDOMSample")
                .Import("System")
                //class
                .AddClass(c => c
                    .Name("CodeDOMCreatedClass")
                    .TypeAttributes(TypeAttributes.Public | TypeAttributes.Sealed)
                    //fields
                    .AddField(f => f.Name("widthValue").OfType<double>().Attributes(MemberAttributes.Private)
                        .AddComment("The width of the object."))
                    .AddField(f => f.Name("heightValue").OfType<double>().Attributes(MemberAttributes.Private)
                        .AddComment("The height of the object."))
                    //property 1
                    .AddProperty(p => p
                        .Name("Width")
                        .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                        .OfType<double>()
                        .AddComment("The Width property for the object.")
                        .Get(s => s.Return(_.Field(_.This(), "widthValue")))
                        .Set(null))
                    //property 2
                    .AddProperty(p => p
                        .Name("Height")
                        .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                        .OfType<double>()
                        .AddComment("The Height property for the object.")
                        .Get(g => g.Return(_.Field(_.This(), "heightValue")))
                        .Set(null))
                    //property 3
                    .AddProperty(p => p
                        .Name("Area")
                        .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                        .OfType<double>()
                        .AddComment("The Area property for the object.")
                        .Get(g =>
                        {
                            var w = _.Field(_.This(), "widthValue");
                            var h = _.Field(_.This(), "heightValue");
                            g.Return(_.Binary(w, CodeBinaryOperatorType.Multiply, h));
                        })
                        .Set(null))

                    //method 1
                    .AddMethod(m => m
                        .Name("ToString")
                        .Returns<string>()
                        .Attributes(MemberAttributes.Public | MemberAttributes.Override)
                        .AddStatement(s =>
                    {
                        var w = _.Field(_.This(), "widthValue");
                        var h = _.Field(_.This(), "heightValue");
                        var formattedOutput = "The object:" + Environment.NewLine +
                                              " width = {0}," + Environment.NewLine +
                                              " height = {1}," + Environment.NewLine +
                                              " area = {2}";
                        var returnEx = _.Invoke(
                            _.Type<string>(),
                            nameof(string.Format),
                            _.Primitive(formattedOutput),
                            w, h
                        );
                        s.Return(returnEx);
                    }))

                    //constructor
                    .AddConstructor(ctor => ctor
                        .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                        .AddParameter(p => p.Name("width").OfType<double>())
                        .AddParameter(p => p.Name("height").OfType<double>())
                        .AddStatement(s =>
                        {
                            var thisW = _.Field(_.This(), "widthValue");
                            var w = _.Variable("width");
                            s.Assign(thisW, w);
                        })
                        .AddStatement(s =>
                        {
                            var thisH = _.Field(_.This(), "heightValue");
                            var h = _.Variable("height");
                            s.Assign(thisH, h);
                        }))

                    //entry point
                    .AddEntryPoint(m =>
                    {
                        var create = _.Create("CodeDOMCreatedClass", _.Primitive(5.3), _.Primitive(6.9));
                        m.AddStatement(_.Declare("testClass").OfType("CodeDOMCreatedClass").Init(create));
                        var toStringInvoke = _.Invoke(_.Variable("testClass"), "ToString");
                        m.AddStatement(_.Invoke(_.Type("System.Console"), "WriteLine", toStringInvoke));
                    })
                );
            unit.GenerateCSharpCode().ShouldBeLike(@"
public sealed class CodeDOMCreatedClass {
    
    // The width of the object.
    private double widthValue;
    
    // The height of the object.
    private double heightValue;
    
    public CodeDOMCreatedClass(double width, double height) {
        this.widthValue = width;
        this.heightValue = height;
    }
    
    // The Width property for the object.
    public double Width {
        get {
            return this.widthValue;
        }
    }
    
    // The Height property for the object.
    public double Height {
        get {
            return this.heightValue;
        }
    }
    
    // The Area property for the object.
    public double Area {
        get {
            return (this.widthValue * this.heightValue);
        }
    }
    
    private string ToString() {
        return string.Format(""The object:\r\n width = {0},\r\n height = {1},\r\n area = {2}"", this.widthValue, this.heightValue);
    }
    
    public static void Main() {
        CodeDOMCreatedClass testClass = new CodeDOMCreatedClass(5.3D, 6.9D);
        System.Console.WriteLine(testClass.ToString());
    }
}

");
        }
    }
}
