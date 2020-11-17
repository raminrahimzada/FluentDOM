using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDOM
{
    public class StructBuilder
    {

    }

    public class DelegateBuilder
    {
        public bool IsPublic { get; set; }
        public bool IsPartial { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsInternal { get; set; }
        public bool IsProtected { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public bool IsStatic { get; set; }

        public DelegateBuilder Public()
        {
            throw new NotImplementedException();
        }
        public DelegateBuilder Private()
        {
            throw new NotImplementedException();
        }
        public DelegateBuilder Protected()
        {
            throw new NotImplementedException();
        }
        public DelegateBuilder Internal()
        {
            throw new NotImplementedException();
        }

        public DelegateBuilder Name(string name)
        {
            throw new NotImplementedException();
        }

        public DelegateBuilder ReturnType(string returnType)
        {
            throw new NotImplementedException();
        }

        public DelegateBuilder New()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Parameter(Action<ParameterBuilder> func)
        {
            throw new NotImplementedException();
        }

        public MethodBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            throw new NotImplementedException();
        }

        public DelegateBuilder Static()
        {
            throw new NotImplementedException();
        }

        public DelegateBuilder Sealed()
        {
            throw new NotImplementedException();
        }
    }
    public class PropertyBuilder
    {
        public bool IsPublic { get; set; }
        public bool IsPartial { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsInternal { get; set; }
        public bool IsProtected { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public bool IsStatic { get; set; }
        public PropertyBuilder Name(string name)
        {
            throw new NotImplementedException();
        }

        public PropertyBuilder Type(string type)
        {
            throw new NotImplementedException();
        }

        public PropertyBuilder Public()
        {
            throw new NotImplementedException();
        }
        public PropertyBuilder Private()
        {
            throw new NotImplementedException();
        }
        public PropertyBuilder Protected()
        {
            throw new NotImplementedException();
        }
        public PropertyBuilder Internal()
        {
            throw new NotImplementedException();
        }

        public PropertyBuilder Getter(Action<PropertyGetterSetterBuilder> action)
        {
            throw new NotImplementedException();
        }
        public PropertyBuilder Setter(Action<PropertyGetterSetterBuilder> action)
        {
            throw new NotImplementedException();
        }

        public PropertyBuilder New()
        {
            throw new NotImplementedException();
        }
    }
    public class FieldBuilder
    {
        public bool IsPublic { get; set; }
        public bool IsPartial { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsInternal { get; set; }
        public bool IsProtected { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public bool IsStatic { get; set; }
        public FieldBuilder Name(string name)
        {
            throw new NotImplementedException();
        }

        public FieldBuilder Type(string type)
        {
            throw new NotImplementedException();
        }

        public FieldBuilder Public()
        {
            throw new NotImplementedException();
        }
        public FieldBuilder Private()
        {
            throw new NotImplementedException();
        }
        public FieldBuilder Protected()
        {
            throw new NotImplementedException();
        }
        public FieldBuilder Internal()
        {
            throw new NotImplementedException();
        }

        public FieldBuilder New()
        {
            throw new NotImplementedException();
        }

        public FieldBuilder Attributes(Action<AttributeBuilder> func)
        {
            throw new NotImplementedException();
        }
    }

    public class PropertyGetterSetterBuilder
    {
        public PropertyGetterSetterBuilder Default()
        {
            throw new NotImplementedException();
        }
    }
    public class MethodBuilder
    {
        public bool IsPublic { get; set; }
        public bool IsPartial { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsInternal { get; set; }
        public bool IsProtected { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public bool IsStatic { get; set; }
        public MethodBuilder Name(string methodName)
        {
            throw new NotImplementedException();
        }

        public MethodBuilder Public()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Private()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Internal()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Static()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Override()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Protected()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Sealed()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Abstract()
        {
            throw new NotImplementedException();
        }
        public MethodBuilder Partial()
        {
            throw new NotImplementedException();
        }

        public MethodBuilder Parameter(Action<ParameterBuilder> func)
        {
            throw new NotImplementedException();
        }

        public MethodBuilder Body(Action<StatementBuilder> action)
        {
            throw new NotImplementedException();
        }

        public MethodBuilder New()
        {
            throw new NotImplementedException();
        }

        public MethodBuilder Returns(string returnType)
        {
            throw new NotImplementedException();
        }
        public MethodBuilder ReturnsVoid()
        {
            throw new NotImplementedException();
        }
    }

    public class ParameterBuilder
    {
        public ParameterBuilder Name(string name)
        {
            throw new NotImplementedException();
        }

        public ParameterBuilder Type(string type)
        {
            throw new NotImplementedException();
        }

        public ParameterBuilder In()
        {
            throw new NotImplementedException();
        }
        public ParameterBuilder Out()
        {
            throw new NotImplementedException();
        }
        public ParameterBuilder Ref()
        {
            throw new NotImplementedException();
        }

        public ParameterBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            throw new NotImplementedException();
        }
    }

    public class AttributeBuilder
    {
        public AttributeBuilder Name(string name)
        {
            throw new NotImplementedException();
        }

        public AttributeBuilder Parameters(Action<AttributeParameterBuilder> func)
        {
            throw new NotImplementedException();
        }
    }

    public class AttributeParameterBuilder
    {
        public AttributeParameterBuilder Name(string name)
        {
            throw new NotImplementedException();
        }
        public AttributeParameterBuilder Value(string value)
        {
            throw new NotImplementedException();
        }
    }

    public class StatementBuilder
    {

    }
}
