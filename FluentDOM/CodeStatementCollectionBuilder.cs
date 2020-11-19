using System.CodeDom;

namespace FluentDOM
{
    public class CodeStatementCollectionBuilder
    {
        private readonly CodeStatementCollection _codeStatementCollection;

        public CodeStatementCollectionBuilder()
        {
            _codeStatementCollection=new CodeStatementCollection();
        }

        public CodeStatementCollection Build()
        {
            return _codeStatementCollection;
        }

        public void Return(CodeExpression b)
        {
            _codeStatementCollection.Add(new CodeMethodReturnStatement(b));
        }

        public CodeVariableReferenceExpression Variable(string varName)
        {
            return new CodeVariableReferenceExpression(varName);
        }

        public void Assign(CodeExpression left, CodeExpression right)
        {
            _codeStatementCollection.Add(new CodeAssignStatement(left, right));
        }
    }
}