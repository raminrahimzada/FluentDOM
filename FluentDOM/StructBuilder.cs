namespace FluentDOM
{
    public class StructBuilder
    {
        public string StructName { get; set; }
        public StructBuilder Name(string structName)
        {
            StructName = structName;
            return this;
        }
    }
}