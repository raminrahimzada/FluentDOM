using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class ClassBuilder
    {
        public string ClassName { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public bool? IsAbstract { get; set; }
        public bool? IsSealed { get; set; }
        public bool? IsStatic { get; set; }
        public string BaseClass { get; set; }


        public List<MethodBuilder> Methods { get; set; }
        public List<ConstructorBuilder> Constructors { get; set; }
        public List<DelegateBuilder> Delegates { get; set; }
        public List<EventBuilder> Events { get; set; }
        public List<PropertyBuilder> Properties { get; set; }
        public List<FieldBuilder> Fields { get; set; }
        public List<string> Interfaces { get; set; }


        public ClassBuilder Name(string className)
        {
            ClassName = className;
            return this;
        }

        public ClassBuilder Public()
        {
            IsPublic = true;
            return this;
        }


        public ClassBuilder Static()
        {
            IsStatic = true;
            return this;
        }

        public ClassBuilder Sealed()
        {
            IsSealed = true;
            return this;
        }

        public ClassBuilder Abstract()
        {
            IsAbstract = true;
            return this;
        }


        public ClassBuilder Partial()
        {
            IsPartial = true;
            return this;
        }

        public ClassBuilder AddMethod(Action<MethodBuilder> func)
        {
            Methods = Methods ?? new List<MethodBuilder>();
            var method = new MethodBuilder();
            func(method);
            Methods.Add(method);
            return this;
        }

        public ClassBuilder Private()
        {
            IsPrivate = true;
            return this;
        }

        public ClassBuilder Protected()
        {
            IsProtected = true;
            return this;
        }
        public ClassBuilder Internal()
        {
            IsInternal = true;
            return this;
        }

        public ClassBuilder AddProperty(Action<PropertyBuilder> func)
        {
            Properties = Properties ?? new List<PropertyBuilder>();
            var property = new PropertyBuilder();
            func(property);
            Properties.Add(property);
            return this;
        }


        public ClassBuilder AddField(Action<FieldBuilder> func)
        {
            Fields = Fields ?? new List<FieldBuilder>();
            var field = new FieldBuilder();
            func(field);
            Fields.Add(field);
            return this;
        }

        public ClassBuilder Inherits(string baseClass)
        {
            BaseClass = baseClass;
            return this;
        }


        public ClassBuilder Implements(string interfaceName)
        {
            Interfaces = Interfaces ?? new List<string>();
            Interfaces.Add(interfaceName);
            return this;
        }


        public ClassBuilder AddDelegate(Action<DelegateBuilder> func)
        {
            Delegates = Delegates ?? new List<DelegateBuilder>();
            var Delegate = new DelegateBuilder();
            func(Delegate);
            Delegates.Add(Delegate);
            return this;
        }


        public ClassBuilder AddConstructor(Action<ConstructorBuilder> func)
        {
            Constructors = Constructors ?? new List<ConstructorBuilder>();
            var constructor = new ConstructorBuilder();
            func(constructor);
            Constructors.Add(constructor);
            return this;
        }


        public ClassBuilder AddEvent(Action<EventBuilder> func)
        {
            Events = Events ?? new List<EventBuilder>();
            var Event = new EventBuilder();
            func(Event);
            Events.Add(Event);
            return this;
        }

    }
}