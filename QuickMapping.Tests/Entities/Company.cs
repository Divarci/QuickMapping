using System.IO;

namespace QuickMapping.Tests.Entities;
public class Company
{
    public Company(int id, string description, List<User> employees, User director)
    {
        Id = id;
        Description = description;
        Employees = employees;
        Director = director;

    }

    public int Id { get; set; }
    public string Description { get; set; }

    public User Director { get; set; }
    public List<User> Employees { get; set; }

    
}
