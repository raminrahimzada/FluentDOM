using System;
using System.CodeDom;
using System.Reflection;
using FluentDOM;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var unit = new CodeNamespace("SampleProject")
                    .Import("System")
                    .Import("System.Threading.Tasks")
                    .AddClass(c=>c
                        .Name("ResponseModel")
                        .AddTypeParameter(t=>t.Name("T"))
                        .AddField(f=>f
                            .Name("Data")
                            .OfType("T")
                            .Attributes(MemberAttributes.Public)
                        )
                        .Attributes(MemberAttributes.Abstract | MemberAttributes.Public)
                        .AddMethod(m=>m
                            .Name("Success")
                            .ReturnsGeneric("ResponseModel","T")
                            .Attributes(MemberAttributes.Public|MemberAttributes.Static)
                            .AddParameter(p=>p
                                .Name("data")
                                .OfType("T")
                            )
                            .AddStatement(s=>s.Return(_.Create(_.Type("ResponseModel","T"))))

                        )
                    )
                    .AddClass(c=>c
                        .Name("AbstractCommand")
                        .AddTypeParameter(t=>t.Name("TResponse"))
                        .Attributes(MemberAttributes.Abstract|MemberAttributes.Public)
                        .AddField(f=>f
                            .Name("_id")
                            .OfType<Guid>()
                            .Attributes(MemberAttributes.Public)
                        )
                        .AddConstructor(ctor=>ctor
                            .Attributes(MemberAttributes.Public)
                            .AddParameter(a=>a.Name<Guid>("id"))
                            .AddStatement(s=>s
                                .Assign(_.Field(_.This(), "_id"),_.Variable("id")))
                        )
                        .AddProperty(p=>p
                            .Name<Guid>("Id")
                            .Set(null)
                            .Get(g=>g.Return(_.Field(_.This(),"_id")))
                        )
                    )
                    .AddInterface(i => i
                        .Name("ICommandHandler")
                        .AddTypeParameter(p => p
                            .Name("TCommand")
                            .AddConstraint(_.Type("AbstractCommand", "TResponse"))
                        )                        
                        .AddTypeParameter(p => p
                            .Name("TResponse")
                        )
                        .AddMethod(m => m
                            .Name("Handle")
                            .AddParameter(p => p.Name("command").OfType("TCommand"))
                            .ReturnsGeneric("ResponseModel", "TResponse")
                        )
                    )
                    
                    .AddClass(c => c
                        .Name("LoginCommandHandler")
                        .ExtendsGeneric(_.Type("ICommandHandler", "LoginCommand_1",typeof(string).FullName))
                        
                        .AddMethod(m => m
                            .Name("Handle")
                            .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                            .ReturnsGeneric("ResponseModel", typeof(string).FullName)
                            .AddParameter(p => p
                                .Name("command")
                                .OfType("LoginCommand_1")
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
                                var type = _.Type("ResponseModel", typeof(string).FullName);
                                var success = _.Invoke(type, "Success", _.Primitive("Welcome"));

                                s.If(condition)
                                    .AddTrueStatement(ss => ss.Return(success))
                                    .AddFalseStatement(_.Throw(_.Create<Exception>(_.Primitive("invalid username or password"))));
                            })
                        )
                    )
                ;
            for(var i=0;i<5;i++)
            {
                unit.AddClass(c => c
                    .Name("LoginCommand_" + i)
                    .Extends(_.Type("AbstractCommand", typeof(string).FullName))
                    .AddField(f => f.Name<string>("_username" + i).AddComment("backing field of _username" + i))
                    .AddField(f => f.Name<string>("_password" + i).AddComment("backing field of _password" + i))
                    .AddProperty(p => p
                        .Name<string>("Username")
                        .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                        .Get(g => { g.Return(_.Field(_.This(), "_username" + i)); })
                    )
                    .AddProperty(p => p
                        .Name<string>("Password")
                        .Attributes(MemberAttributes.Public | MemberAttributes.Final)
                        .Get(g => { g.Return(_.Field(_.This(), "_password" + i)); })
                    )
                    .AddConstructor(ctor => ctor
                        .AddBaseConstructorArg(_.Variable("id" + i))
                        .Attributes(MemberAttributes.Public)
                        .AddParameter(p => p.Name<Guid>("id" + i))
                        .AddParameter(p => p.Name<string>("username" + i))
                        .AddParameter(p => p.Name<string>("password" + i))
                        .AddStatement(action: s =>
                            s.Assign(_.Field(_.This(), "_username" + i), _.Variable("username" + i)))
                        .AddStatement(action: s =>
                            s.Assign(_.Field(_.This(), "_password" + i), _.Variable("password" + i)))
                    )
                );
            }
            unit.GenerateCSharpCode().WriteToFile(@"C:\PROJECTS\FluentDOM\SampleProject\AutoGenerated\source.cs");
        }
    }
}
