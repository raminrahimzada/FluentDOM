using System;
using System.CodeDom;

namespace FluentDOM
{
    public static class CodeConditionStatementExtensions
    {
        public static CodeConditionStatement AddTrueStatement(this CodeConditionStatement condition,
            Action<CodeStatementBuilder> action)
        {
            var s = new CodeStatementBuilder();
            action(s);
            condition.TrueStatements.Add(s.Build());
            return condition;
        }
        public static CodeConditionStatement AddFalseStatement(this CodeConditionStatement condition,
            Action<CodeStatementBuilder> action)
        {
            var s = new CodeStatementBuilder();
            action(s);
            condition.FalseStatements.Add(s.Build());
            return condition;
        }

        public static CodeConditionStatement AddFalseStatement(this CodeConditionStatement condition, CodeStatement codeStatement)
        {
            condition.FalseStatements.Add(codeStatement);
            return condition;
        }
        public static CodeConditionStatement AddTrueStatement(this CodeConditionStatement condition, CodeStatement codeStatement)
        {
            condition.TrueStatements.Add(codeStatement);
            return condition;
        }
    }
    public static class CodeConstructorExtensions
    {
        public static CodeConstructor AddBaseConstructorArg(this CodeConstructor ctor, CodeExpression codeExpression)
        {
            ctor.BaseConstructorArgs.Add(codeExpression);
            return ctor;
        }
    }
}