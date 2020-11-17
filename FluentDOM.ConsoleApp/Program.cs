using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentDOM.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lib = NamespaceBuilder
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
                       .Protected()
                       .Internal()
                       .Static()
                       .Sealed()
                       .Abstract()
                       .Partial()
                       .Inherits("object")
                       .Implements("IDisposable")
                       .Implements("IRaminClass")

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

                       .AddProperty(p => p.Name("Value").Type("int")
                           .Public()
                           .New()
                           .Partial()
                           .Sealed()
                           .Abstract()
                           .Static()
                           .Private()
                           .Protected()
                           .Internal()
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
                                   .Type("double")
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
                                   .Type("int")
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
                                //TODO
                            })
                       );
               });
            ;
        }
    }
}
