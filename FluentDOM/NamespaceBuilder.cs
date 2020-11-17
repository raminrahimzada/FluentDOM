using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class NamespaceBuilder
    {
        public string NameSpaceName { get; set; }
        public List<string> Imports { get; set; }
        public List<ClassBuilder> Classes { get; set; }
        public List<AttributeBuilder> Attributes { get; set; }
        public List<StructBuilder> Structs { get; set; }
        public List<InterfaceBuilder> Interfaces { get; set; }

        private NamespaceBuilder(string nameSpaceName)
        {
            NameSpaceName = nameSpaceName;
        }
        public NamespaceBuilder AddAttribute(Action<AttributeBuilder> func)
        {
            Attributes = Attributes ?? new List<AttributeBuilder>();
            var attribute = new AttributeBuilder();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
        public NamespaceBuilder AddInterface(Action<InterfaceBuilder> func)
        {
            Interfaces = Interfaces ?? new List<InterfaceBuilder>();
            var Interface = new InterfaceBuilder();
            func(Interface);
            Interfaces.Add(Interface);
            return this;
        }
        public NamespaceBuilder AddStruct(Action<StructBuilder> func)
        {
            Structs = Structs ?? new List<StructBuilder>();
            var Struct = new StructBuilder();
            func(Struct);
            Structs.Add(Struct);
            return this;
        }
        public static NamespaceBuilder New(string nameSpace)
        {
            return new NamespaceBuilder(nameSpace);
        }

        public NamespaceBuilder AddUsing(string nameSpace)
        {
            Imports = Imports ?? new List<string>();
            Imports.Add(nameSpace);
            return this;
        }

        public NamespaceBuilder AddClass(Action<ClassBuilder> func)
        {
            Classes = Classes ?? new List<ClassBuilder>();
            var @class = new ClassBuilder();
            func(@class);
            Classes.Add(@class);
            return this;
        }
    }
}