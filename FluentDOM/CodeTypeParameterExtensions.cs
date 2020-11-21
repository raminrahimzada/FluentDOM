using System.CodeDom;

namespace FluentDOM
{
    public static class CodeTypeParameterExtensions
    {
        public static CodeTypeParameter Name(this CodeTypeParameter parameter, string name)
        {
            parameter.Name = name;
            return parameter;
        }
        public static CodeTypeParameter HasConstructorConstraint(this CodeTypeParameter parameter, bool hasConstructorConstraint)
        {
            parameter.HasConstructorConstraint= hasConstructorConstraint;
            return parameter;
        }
        public static CodeTypeParameter AddConstraint(this CodeTypeParameter parameter, string type)
        {
            parameter.Constraints.Add(type);
            return parameter;
        }
        public static CodeTypeParameter AddConstraint<T>(this CodeTypeParameter parameter)
        {
            parameter.Constraints.Add(typeof(T));
            return parameter;
        }
    }
}