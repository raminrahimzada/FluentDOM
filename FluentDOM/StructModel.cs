namespace FluentDOM
{
    public class StructModel
    {
        public string StructName { get; set; }
        public StructModel Name(string structName)
        {
            StructName = structName;
            return this;
        }
    }
}