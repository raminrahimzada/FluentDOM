using System;
using System.Collections.Generic;

namespace FluentDOM
{
    public class NamespaceModel
    {
        public string NameSpaceName { get; set; }
        public List<string> Imports { get; set; }=new List<string>();
        public List<ClassModel> Classes { get; set; }=new List<ClassModel>();
        public List<AttributeModel> Attributes { get; set; }=new List<AttributeModel>();
        public List<StructModel> Structs { get; set; }=new List<StructModel>();
        public List<InterfaceModel> Interfaces { get; set; }=new List<InterfaceModel>();

        private NamespaceModel(string nameSpaceName)
        {
            NameSpaceName = nameSpaceName;
        }
        public NamespaceModel AddAttribute(Action<AttributeModel> func)
        {
            Attributes = Attributes ?? new List<AttributeModel>();
            var attribute = new AttributeModel();
            func(attribute);
            Attributes.Add(attribute);
            return this;
        }
        public NamespaceModel AddInterface(Action<InterfaceModel> func)
        {
            Interfaces = Interfaces ?? new List<InterfaceModel>();
            var Interface = new InterfaceModel();
            func(Interface);
            Interfaces.Add(Interface);
            return this;
        }
        public NamespaceModel AddStruct(Action<StructModel> func)
        {
            Structs = Structs ?? new List<StructModel>();
            var Struct = new StructModel();
            func(Struct);
            Structs.Add(Struct);
            return this;
        }
        public static NamespaceModel New(string nameSpace)
        {
            return new NamespaceModel(nameSpace);
        }

        public NamespaceModel AddUsing(string nameSpace)
        {
            Imports = Imports ?? new List<string>();
            Imports.Add(nameSpace);
            return this;
        }

        public NamespaceModel AddClass(Action<ClassModel> func)
        {
            Classes = Classes ?? new List<ClassModel>();
            var @class = new ClassModel();
            func(@class);
            Classes.Add(@class);
            return this;
        }
    }
}