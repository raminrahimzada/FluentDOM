using System;
using FluentDOM.ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentDOM.Tests
{
    [TestClass]
    public class UnitTestAll
    {
        [TestMethod]
        public void Test_NameSpace()
        {
            var lib = NamespaceModel
                .New("example1")
               ;
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 
{    
}
");
        }
        [TestMethod]
        public void Test_Empty_Class_Public()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Private()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Private()
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    private class Class1
    {
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Static()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .Static()
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/609fbe5e-305a-45bb-9626-af7fa2c79c6d/codetypedeclaration-a-static-class?forum=netfxbcl
            //seems nothing to do 
            source.ShouldBeLike(@"
namespace example1 {
    public sealed abstract class Class1
    {
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Single_Method()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .AddMethod(m=>m
                        .Name("DoSomething")
                    )
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
        void DoSomething()
        {

        }
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Single_Method_Public()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .AddMethod(m=>m
                        .Name("DoSomething")
                        .Public()
                    )
                );
            lib.Classes[0].Methods[0].IsOverride = false;
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
        public void DoSomething()
        {

        }
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Single_Method_Private()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .AddMethod(m=>m
                        .Name("DoSomething")
                        .Private()
                    )
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
        private void DoSomething()
        {

        }
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Single_Method_Override()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .AddMethod(m=>m
                        .Name("DoSomething")
                        .Override()
                    )
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
        override void DoSomething()
        {

        }
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Single_Method_Override_Public()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .AddMethod(m=>m
                        .Name("DoSomething")
                        .Public()
                        .Override()
                    )
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
        public override void DoSomething()
        {

        }
    }
}
");
        }
        [TestMethod]
        public void Test_EmptyClass_Single_Method_Public_Static()
        {
            var lib = NamespaceModel
                .New("example1")
                .AddClass(c => c
                    .Name("Class1")
                    .Public()
                    .AddMethod(m=>m
                        .Name("DoSomething")
                        .Public()
                        .Static()
                    )
                );
            var source = Compiler.Compile(lib).GenerateCSharpCode();
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/609fbe5e-305a-45bb-9626-af7fa2c79c6d/codetypedeclaration-a-static-class?forum=netfxbcl
            //seems nothing to do 
            source.ShouldBeLike(@"
namespace example1 {
    public class Class1
    {
        public static void DoSomething()
        {

        }
    }
}
");
        }
    }
}
