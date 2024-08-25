using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Entities;
public class User
{
    public int Id { get; set; }
    public string Fullname { get; set; } = null!;
    public int Age { get; set; }

    public User(int id, string fullname, int age)
    {
        Id = id;
        Fullname = fullname;
        Age = age;
    }

    public User() { }

    public static User CreateSingleUser(string fullname) =>
        new(Random.Shared.Next(1,20),fullname,Random.Shared.Next(30,50));

    public static List<User> CreateMultiUserWith_List() =>    
        [CreateSingleUser("John Wick"), 
         CreateSingleUser("Michael Wheel"), 
         CreateSingleUser("Jennifer Jane")];

    public static Collection<User> CreateMultiUserWith_Collection() =>
        [CreateSingleUser("John Wick"),
         CreateSingleUser("Michael Wheel"),
         CreateSingleUser("Jennifer Jane")];

    public static IList<User> CreateMultiUserWith_IList() =>
        CreateMultiUserWith_List();

    public static ICollection<User> CreateMultiUserWith_ICollection() =>
       CreateMultiUserWith_List();

    public static IEnumerable<User> CreateMultiUserWith_IEnumerable() =>
       CreateMultiUserWith_List();

    public static IReadOnlyCollection<User> CreateMultiUserWith_IReadonlyCollection() =>
       CreateMultiUserWith_List().AsReadOnly();

    public static IReadOnlyList<User> CreateMultiUserWith_IReadonlyList() =>
       CreateMultiUserWith_List().AsReadOnly();

    public static ReadOnlyCollection<User> CreateMultiUserWith_ReadonlyCollection() =>
       CreateMultiUserWith_List().AsReadOnly();
}
