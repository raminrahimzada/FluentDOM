using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FluentDOM
{
    public class StatementsBuilder
    {
        public List<AbstractStatementBuilder> Statements { get; set; } = new List<AbstractStatementBuilder>();

        public EmptyReturnStatementBuilder Return()
        {
            Statements = Statements ?? new List<AbstractStatementBuilder>();
            var s = new EmptyReturnStatementBuilder();
            Statements.Add(s);
            return s;
        }
        public PrimitiveReturnStatementBuilder Return<T>(T t)
        {
            Statements = Statements ?? new List<AbstractStatementBuilder>();
            var s = new PrimitiveReturnStatementBuilder
            {
                Expression = t, 
                ExpressionType = typeof(T).FullName
            };
            Statements.Add(s);
            return s;
        }

        public ComplexReturnStatementBuilder Return(AbstractStatementBuilder statement)
        {
            Statements = Statements ?? new List<AbstractStatementBuilder>();
            var s = new ComplexReturnStatementBuilder
            {
                Statement = statement
            };
            Statements.Add(s);
            return s;
        }
    }
    public abstract class AbstractStatementBuilder
    {
        public string Type => this.GetType().Name;
    }

    public class EmptyReturnStatementBuilder : AbstractStatementBuilder
    {

    }
    public class PrimitiveReturnStatementBuilder : AbstractStatementBuilder
    {
        public object Expression { get; set; }
        public string ExpressionType { get; set; }
    }
    public class ComplexReturnStatementBuilder : AbstractStatementBuilder
    {
        public AbstractStatementBuilder Statement { get; set; }
    }
}