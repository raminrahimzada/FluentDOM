using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;
using Newtonsoft.Json;

namespace FluentDOM.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
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
                        .AddMethod(m => m.Name("ToString").Returns<string>().AddStatement(s =>
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
                    )
                ;
            File.WriteAllText("lib.cs", unit.GenerateCSharpCode());
        }
    }
}
