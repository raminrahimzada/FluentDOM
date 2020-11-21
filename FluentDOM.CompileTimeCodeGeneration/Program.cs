using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
namespace FluentDOM.CompileTimeCodeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var unit = new CodeNamespace("CodeDOMSample")
                    .Import("System")
                    .Import("System.Threading.Tasks")
                    .AddInterface(i => i
                        .Name("ICommandHandler")
                        .AddTypeParameter(p => p
                            .Name("TCommand")
                            .HasConstructorConstraint(true)
                            .AddConstraint("AbstractCommand")
                        )
                        .AddMethod(m => m
                            .Name("Handle")
                            .AddParameter(p => p.Name("command").OfType("Command"))
                            .ReturnsAsync("ResponseModel")
                        )
                    )
                    .AddClass(c => c
                        .Name("LoginCommand")
                        .Extends("AbstractCommand")
                        .AddField(f => f.Name<string>("_username").AddComment("backing field of _username"))
                        .AddField(f => f.Name<string>("_password").AddComment("backing field of _password"))
                        .AddProperty(p => p
                            .Name<string>("Username")
                            .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                            .Get(g =>
                            {
                                g.Return(_.Field(_.This(), "_username"));
                            })
                        )
                        .AddProperty(p => p
                            .Name<string>("Password")
                            .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                            .Get(g =>
                            {
                                g.Return(_.Field(_.This(), "_password"));
                            })
                        )
                        .AddConstructor(ctor => ctor
                            .AddBaseConstructorArg(_.Variable("id"))
                            .Attributes(MemberAttributes.Public)
                            .AddParameter(p => p.Name<Guid>("id"))
                            .AddParameter(p => p.Name<string>("username"))
                            .AddParameter(p => p.Name<string>("password"))
                            .AddStatement(action: s => s.Assign(_.Field(_.This(), "username"), _.Variable("username")))
                            .AddStatement(action: s => s.Assign(_.Field(_.This(), "password"), _.Variable("password")))
                        )
                    )
                    .AddClass(c => c
                        .Name("LoginCommandHandler")
                        .ExtendsGeneric("ICommandHandler", "LoginCommand")
                        .AddMethod(m => m
                            .Name("Handle")
                            .Attributes(MemberAttributes.Public | MemberAttributes.Override)
                            .ReturnsAsync("ResponseModel")
                            .AddParameter(p => p
                                .Name("command")
                                .OfType("LoginCommand")
                            )
                            .AddStatement(s =>
                            {
                                var cc = _.Variable("command");
                                var condition = _.Binary(cc, CodeBinaryOperatorType.IdentityEquality, _.Null());
                                s.If(condition)
                                    .AddTrueStatement(_.Throw(_.Create<ArgumentNullException>(_.Primitive("command"))));
                            })
                            .AddStatement(s =>
                            {
                                var c1 = _.Binary(_.Variable("command.Username"),
                                    CodeBinaryOperatorType.IdentityEquality, _.Primitive("admin"));

                                var c2 = _.Binary(_.Variable("command.Password"),
                                    CodeBinaryOperatorType.IdentityEquality, _.Primitive("admin"));

                                var condition = _.Binary(c1, CodeBinaryOperatorType.BooleanAnd, c2);
                                var success = _.Invoke(_.Type("ResponseModel"), "Success", _.Primitive("Welcome"));

                                s.If(condition)
                                    .AddTrueStatement(ss => ss.Return(success))
                                    .AddFalseStatement(_.Throw(_.Create<Exception>(_.Primitive("invalid username or password"))));
                            })
                        )
                    )
                    //class Program
                    .AddClass(c => c
                        .Name("Program")
                        .TypeAttributes(TypeAttributes.Public)
                        .Attributes(MemberAttributes.New)
                        .AddMethod(m => m
                            .Name("Main")
                            .Attributes(MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static)
                            .AddParameter(p => p
                                .Name("args")
                                .OfType<string[]>()
                            )
                            .AddStatement(s => s
                                .Declare("command")
                                .OfType("LoginCommand")
                                .Init(_.Create("LoginCommand").AddParameters(_.Primitive("admin"), _.Primitive("123")))
                            )
                            .AddStatement(s => s
                                .Declare("handler")
                                .OfType("LoginCommandHandler")
                                .Init(_.Create("LoginCommandHandler"))
                            )
                            .AddStatement(s =>
                            {
                                var init = _.Invoke(_.Variable("handler"), "Handle", _.Variable("command"));
                                s
                                    .Declare("response")
                                    .OfType("ResponseModel")
                                    .Init(init);
                            })
                            .AddStatement(s => s
                                .Return(_.Primitive(0))
                            )

                        )
                    )
        }
    }
}
