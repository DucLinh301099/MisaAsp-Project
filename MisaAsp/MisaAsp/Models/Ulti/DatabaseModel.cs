namespace MisaAsp.Models.Ulti
{
    public class ProdParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ProdParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
