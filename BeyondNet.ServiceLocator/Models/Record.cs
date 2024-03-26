namespace BeyondNet.ServiceLocator.Models
{
    public class Record
    {
        public Type Component { get; set; }

        public object Implementation { get; set; }
        public string Name { get; set; }

        public Record(Type component, object implementation, string name)
        {
            Component = component;
            Implementation = implementation;
            Name = name;
        }
    }
}
