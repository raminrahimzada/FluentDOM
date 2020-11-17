namespace FluentDOM
{
    public class AttributeParameterBuilder
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public AttributeParameterBuilder Name(string name)
        {
            ParameterName = name;
            return this;
        }
        public AttributeParameterBuilder Value(string value)
        {
            ParameterValue = value;
            return this;
        }
    }
}