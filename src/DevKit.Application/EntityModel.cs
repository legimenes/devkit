namespace DevKit.Application;
public class EntityModel(
    string name,
    ICollection<EntityProperty> properties)
{
    public string Name { get => name; }
    public ICollection<EntityProperty> Properties { get => properties; }

    public static EntityModel Create(string name)
    {
        return new(name, []);
    }

    public void AddProperty(EntityProperty property)
    {
        if (!Properties.Any(p => p.Name == property.Name))
            Properties.Add(property);
    }
}