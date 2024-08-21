namespace QuickMapping.Tests.Entities;
public class User(int id, string fullname, int age)
{
    public int Id { get; set; } = id;
    public string Fullname { get; set; } = fullname;
    public int Age { get; set; } = age;
}
