namespace QuickMapping.Tests.Entities;
public class Company(int id, string description, List<User> employees)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;

    public List<User> Employees { get; set; } = employees;
}
