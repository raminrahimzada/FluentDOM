using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FluentDOM
{
    public class StatementCollectionModel
    {
        public List<AbstractStatementModel> Statements { get; set; } = new List<AbstractStatementModel>();

        public EmptyReturnStatementModel Return()
        {
            Statements = Statements ?? new List<AbstractStatementModel>();
            var s = new EmptyReturnStatementModel();
            Statements.Add(s);
            return s;
        }
        public PrimitiveReturnStatementModel ReturnPrimitive<T>(T t)
        {
            Statements = Statements ?? new List<AbstractStatementModel>();
            var s = new PrimitiveReturnStatementModel
            {
                Expression = t.ToString(), 
                ExpressionType = typeof(T).FullName
            };
            Statements.Add(s);
            return s;
        }

        public ComplexReturnStatementModel Return(AbstractCodeExpressionModel statement)
        {
            Statements = Statements ?? new List<AbstractStatementModel>();
            var s = new ComplexReturnStatementModel
            {
                Expression = statement
            };
            Statements.Add(s);
            return s;
        }

        public VariableExpressionModel Variable(string variableName)
        {
            return new VariableExpressionModel()
            {
                VariableName = variableName
            };
        }
    }
    public abstract class AbstractStatementModel
    {
        public string Type => this.GetType().Name;
    }

    public class EmptyReturnStatementModel : AbstractStatementModel
    {

    }
    public class PrimitiveReturnStatementModel : AbstractStatementModel
    {
        public string Expression { get; set; }
        public string ExpressionType { get; set; }
    }

    public class VariableExpressionModel : AbstractCodeExpressionModel
    {
        public string VariableName { get; set; }

    }

    public class BinaryOperationExpressionModel : AbstractCodeExpressionModel
    {
        public CodeBinaryOperatorType ExpressionType { get; set; }
        public AbstractCodeExpressionModel Left { get; set; }
        public AbstractCodeExpressionModel Right { get; set; }
    }
    public class PrimitiveCodeExpressionModel: AbstractCodeExpressionModel
    {
        public string Expression { get; set; }
        public string ExpressionType { get; set; }

      
    }
    public class ComplexReturnStatementModel : AbstractStatementModel
    {
        public AbstractCodeExpressionModel Expression { get; set; }
    }
}