using System.CodeDom;
using System.Reflection;

namespace FluentDOM.ConsoleApp
{
    public static class BuilderExtensions
    {
        public static TypeAttributes GetTypeAttributes(this ClassBuilder classBuilder)
        {
            TypeAttributes t = default;
            if (classBuilder.IsPublic.HasValue)
            {
                t |= TypeAttributes.Public;
            }
            if (classBuilder.IsAbstract.HasValue)
            {
                t |= TypeAttributes.Abstract;
            }
            if (classBuilder.IsSealed.HasValue)
            {
                t |= TypeAttributes.Sealed;
            }
            if (classBuilder.IsPrivate.HasValue)
            {
                t |= TypeAttributes.NestedPrivate;
            }

            return t;
        }
        public static FieldDirection GetDirection(this ParameterBuilder parameterBuilder)
        {
            FieldDirection f = default;
            if (parameterBuilder.IsIn ?? false)
            {
                f = FieldDirection.In;
            }
            if (parameterBuilder.IsOut ?? false)
            {
                f = FieldDirection.Out;
            }
            if (parameterBuilder.IsRef ?? false)
            {
                f = FieldDirection.Ref;
            }

            return f;
        }
        public static CodeTypeReference GetReturnTypeReference(this MethodBuilder methodBuilder)
        {
            if (string.IsNullOrWhiteSpace(methodBuilder.ReturnType))
                return null;
            return new CodeTypeReference(methodBuilder.ReturnType);
        }
        public static CodeTypeReference GetTypeReference(this PropertyBuilder propertyBuilder)
        {
            if (string.IsNullOrWhiteSpace(propertyBuilder.PropertyType))
                return null;
            return new CodeTypeReference(propertyBuilder.PropertyType);
        }

        public static MemberAttributes GetMemberAttribute(this MethodBuilder methodBuilder)
        {
            MemberAttributes x = default(MemberAttributes);
            if (methodBuilder.IsPublic.HasValue)
            {
                x |= MemberAttributes.Public;
            }
            if (methodBuilder.IsPrivate.HasValue)
            {
                x |= MemberAttributes.Private;
            }
            if (methodBuilder.IsStatic.HasValue)
            {
                x |= MemberAttributes.Static;
            }
            if (methodBuilder.IsAbstract.HasValue)
            {
                x |= MemberAttributes.Abstract;
            }
            if (methodBuilder.IsOverride.HasValue)
            {
                x |= MemberAttributes.Override;
            }
            if (methodBuilder.IsNew.HasValue)
            {
                x |= MemberAttributes.New;
            }

            return x;
        }
        public static MemberAttributes GetMemberAttribute(this PropertyBuilder propertyBuilder)
        {
            MemberAttributes x = default(MemberAttributes);
            if (propertyBuilder.IsPublic.HasValue)
            {
                x |= MemberAttributes.Public;
            }
            if (propertyBuilder.IsPrivate.HasValue)
            {
                x |= MemberAttributes.Private;
            }
            if (propertyBuilder.IsStatic.HasValue)
            {
                x |= MemberAttributes.Static;
            }
            if (propertyBuilder.IsAbstract.HasValue)
            {
                x |= MemberAttributes.Abstract;
            }
            if (propertyBuilder.IsOverride.HasValue)
            {
                x |= MemberAttributes.Override;
            }
            if (propertyBuilder.IsNew.HasValue)
            {
                x |= MemberAttributes.New;
            }

            return x;
        }
    }
}