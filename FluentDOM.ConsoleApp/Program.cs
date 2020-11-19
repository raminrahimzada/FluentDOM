using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CSharp;
using Newtonsoft.Json;

namespace FluentDOM.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lib = NamespaceModel
               .New("Ramin")
               .AddUsing("System")
               .AddUsing("System.ComponentModel.DataAnnotations")
               .AddAttribute(a=>a.Name("AssemblyVersion").AddParameter(p=>p.Name("version").Value("1.0.0")))
               .AddStruct(s=>s.Name("ValueObject"))
               .AddInterface(i => i.Name("IRaminClass")
                   .Public()
                   .Private()
                   .Protected()
                   .Internal()
                   .Partial()
               )
               .AddClass(c =>
               {
                   c.Name("RaminClass")
                       .Public()
                       .Private()
                       .Internal()
                       .Static()
                       .Sealed()
                       .Abstract()
                       .Partial()
                       .Inherits<object>()
                       .Implements("IDisposable")
                       .Implements("IRaminClass")
                       
                       .AddAttribute(a=>a.Name("DatabaseModel").AddParameter(p=>p.Name("version").Value("1.5")))

                       .AddEvent(e => e.Name("Badimcan").Type("Function")
                           .Public()
                           .Private()
                           .Partial()
                           .Protected()
                           .Internal()
                           .Static()
                           .Sealed()
                           .Abstract()
                       )
                       .AddConstructor(ct => ct
                           .AddParameter(
                               ctp => ctp.Name("value").Type("")
                                   .AddAttribute(ctpa => ctpa.Name("Display").AddParameter(_p => _p.Name("Name").Value("Zirt")))
                       ))

                       .AddProperty(p => p.Name("Value").Type<int>()
                           .Public()
                           .Override()
                           .New()
                           .Partial()
                           .Sealed()
                           .Abstract()
                           .Static()
                           .Private()
                           .Protected()
                           .Internal()
                           .AddAttribute(a=>a.Name("Required"))
                           .HasGetMethod()
                           .HasSetMethod()
                           .Getter(g =>
                           {
                               g.Default();
                                //TODO
                            })
                           .Setter(g =>
                           {
                               g.Default();
                                //TODO
                            })
                       )
                       .AddField(p => p.Name("Value").Type("int")
                           .Public()
                           .New()
                           .Partial()
                           .Static()
                           .Sealed()
                           .Private()
                           .Protected()
                           .Internal()
                           .Abstract()
                           .AddAttribute(da => da
                               .Name("FromBody")
                               .AddParameter(ap => ap.Name("Name").Value("first parameter of Delegate"))
                           )
                       )
                       .AddDelegate(d => d
                           .Name("Value")
                           .ReturnType("double")
                           .Public()
                           .New()
                           .Private()
                           .Partial()
                           .Static()
                           .Sealed()
                           .Protected()
                           .Internal()
                           .Abstract()
                           .AddAttribute(da => da
                               .Name("Display")
                               .AddParameter(ap => ap.Name("Name").Value("this is delegate"))
                           )
                           .Parameter(
                               p => p
                                   .Name("xx")
                                   .Type<double>()
                                   .In()
                                   .Out()
                                   .Ref()
                                   .AddAttribute(a => a
                                       .Name("FromBody")
                                       .AddParameter(ap => ap.Name("Name").Value("first parameter of Delegate"))
                                   )
                           )
                       )
                       .AddMethod(m => m.Name("Square")
                           .Public()
                           .New()
                           .Private()
                           .Protected()
                           .Internal()
                           .Static()
                           .Override()
                           .Sealed()
                           .Abstract()
                           .Partial()
                           .Returns("int")
                           .ReturnsVoid()
                           .AddParameter(
                               p => p
                                   .Name("x")
                                   .Type<int>()
                                   .In()
                                   .Out()
                                   .Ref()
                                   .AddAttribute(a => a
                                       .Name("FromBody")
                                       .AddParameter(ap => ap.Name("Name").Value("first parameter"))
                                   )
                           )
                           .Body(b =>
                           {
                               b.Return();
                               b.ReturnPrimitive<short>(41);
                               var x = b.Variable("x");
                               b.Return(x + x);
                               b.Return(x - x);
                               b.Return(x * x);
                               b.Return(x / x);
                               b.Return(x % x);
                               b.Return(x > x);
                               b.Return(x < x);
                               b.Return(x >= x);
                               b.Return(x <= x);
                               b.Return(x == x);
                               b.Return(x != x);
                           })
                       );
               });
            ;
            var provider = new CSharpCodeProvider();
            string source = @"
using System;
namespace SomeNamespace 
{
  public class Class0
  {     
//xiyar
  }
}";
            ////var u = provider.Parse(new StringReader(source));
            //;
            //SyntaxTree tree = Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseSyntaxTree(SourceText.From(source));
            //var root = tree.GetCompilationUnitRoot();
            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};
            //var json = JsonConvert.SerializeObject(root,settings);

            //;
            CodeCompileUnit unit=new CodeCompileUnit();
            CodeNamespace nameSpace1 = Compiler.Compile(lib);
            unit.Namespaces.Add(nameSpace1);
            File.WriteAllText(@"lib.json", JsonConvert.SerializeObject(lib));
            File.WriteAllText(@"lib.cs", nameSpace1.GenerateCSharpCode());
        }
    }
}
