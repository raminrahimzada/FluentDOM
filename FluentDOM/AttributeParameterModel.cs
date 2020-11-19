namespace FluentDOM
{
    public class AttributeParameterModel
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public AttributeParameterModel Name(string name)
        {
            ParameterName = name;
            return this;
        }
        public AttributeParameterModel Value(string value)
        {
            ParameterValue = value;
            return this;
        }
    }
}