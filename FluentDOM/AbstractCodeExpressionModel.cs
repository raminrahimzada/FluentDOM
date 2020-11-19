using System.CodeDom;

namespace FluentDOM
{
    public abstract class AbstractCodeExpressionModel
    {
        #region Self

        public static BinaryOperationExpressionModel operator +(AbstractCodeExpressionModel left,
           AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.Add,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator -(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.Subtract,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator *(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.Multiply,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator /(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.Divide,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator &(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.BitwiseAnd,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator |(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.BitwiseOr,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator %(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.Modulus,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator ==(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.IdentityEquality,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator !=(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.IdentityInequality,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator >(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.GreaterThan,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator <(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.LessThan,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator >=(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.GreaterThanOrEqual,
                Left = left,
                Right = right
            };
        }
        public static BinaryOperationExpressionModel operator <=(AbstractCodeExpressionModel left,
            AbstractCodeExpressionModel right)
        {
            return new BinaryOperationExpressionModel()
            {
                ExpressionType = CodeBinaryOperatorType.LessThanOrEqual,
                Left = left,
                Right = right
            };
        }
        #endregion

    }
}