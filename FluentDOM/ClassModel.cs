using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentDOM
{
    public class ClassModel
    {
        public string ClassName { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsAbstract { get; set; }
        public bool? IsSealed { get; set; }
        public bool? IsStatic { get; set; }
        public string BaseClass { get; set; }


        public List<MethodModel> Methods { get; set; }=new List<MethodModel>();
        public List<ConstructorModel> Constructors { get; set; }=new List<ConstructorModel>();
        public List<DelegateModel> Delegates { get; set; }=new List<DelegateModel>();
        public List<EventModel> Events { get; set; }=new List<EventModel>();
        public List<PropertyModel> Properties { get; set; }=new List<PropertyModel>();
        public List<FieldModel> Fields { get; set; }=new List<FieldModel>();
        public List<string> Interfaces { get; set; }=new List<string>();
        public List<AttributeModel> Attributes { get; set; }=new List<AttributeModel>();


        public ClassModel Name(string className)
        {
            ClassName = className;
            return this;
        }

        public ClassModel Public()
        {
            IsPublic = true;
            return this;
        }


        public ClassModel Static()
        {
            IsStatic = true;
            return this;
        }

        public ClassModel Sealed()
        {
            IsSealed = true;
            return this;
        }

        public ClassModel Abstract()
        {
            IsAbstract = true;
            return this;
        }


        public ClassModel Partial()
        {
            IsPartial = true;
            return this;
        }

        public ClassModel AddMethod(Action<MethodModel> func)
        {
            Methods = Methods ?? new List<MethodModel>();
            var method = new MethodModel();
            func(method);
            Methods.Add(method);
            return this;
        }

        public ClassModel Private()
        {
            IsPrivate = true;
            return this;
        }

        public ClassModel Internal()
        {
            IsInternal = true;
            return this;
        }

        public ClassModel AddProperty(Action<PropertyModel> func)
        {
            Properties = Properties ?? new List<PropertyModel>();
            var property = new PropertyModel();
            func(property);
            Properties.Add(property);
            return this;
        }


        public ClassModel AddField(Action<FieldModel> func)
        {
            Fields = Fields ?? new List<FieldModel>();
            var field = new FieldModel();
            func(field);
            Fields.Add(field);
            return this;
        }

        public ClassModel Inherits(string baseClass)
        {
            BaseClass = baseClass;
            return this;
        }
        public ClassModel Inherits<T>()
        {
            BaseClass = typeof(T).FullName;
            return this;
        }


        public ClassModel Implements(string interfaceName)
        {
            Interfaces = Interfaces ?? new List<string>();
            Interfaces.Add(interfaceName);
            return this;
        }


        public ClassModel AddDelegate(Action<DelegateModel> func)
        {
            Delegates = Delegates ?? new List<DelegateModel>();
            var Delegate = new DelegateModel();
            func(Delegate);
            Delegates.Add(Delegate);
            return this;
        }


        public ClassModel AddConstructor(Action<ConstructorModel> func)
        {
            Constructors = Constructors ?? new List<ConstructorModel>();
            var constructor = new ConstructorModel();
            func(constructor);
            Constructors.Add(constructor);
            return this;
        }


        public ClassModel AddEvent(Action<EventModel> func)
        {
            Events = Events ?? new List<EventModel>();
            var Event = new EventModel();
            func(Event);
            Events.Add(Event);
            return this;
        }
        public ClassModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
    }
}