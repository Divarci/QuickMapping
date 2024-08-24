using QuickMapping.Exceptions;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Entities;
public class Company<T>(int id, string description, T employees, User director)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;

    public User Director { get; set; } = director;
    public T Employees { get; set; } = employees;

    public static Company<T> CreateSingleCompany(string description, ListType listType)
    {
        var userList = listType switch
        {
            ListType.List => User.CreateMultiUserWith_List(),
            ListType.Collection => User.CreateMultiUserWith_Collection(),
            ListType.IList => User.CreateMultiUserWith_IList(),
            ListType.ICollection => User.CreateMultiUserWith_ICollection(),
            ListType.IEnumerable => User.CreateMultiUserWith_IEnumerable(),
            ListType.IReadonlyCollection => User.CreateMultiUserWith_IReadonlyCollection(),
            ListType.IReadonlyList => User.CreateMultiUserWith_IReadonlyList(),
            ListType.ReadonlyCollection => User.CreateMultiUserWith_ReadonlyCollection(),
            _ => throw new MapperException("User List not exist")
        };

        var company = new Company<T>(
            Random.Shared.Next(1, 20),
            description,
            (T)userList,
            User.CreateSingleUser("Mason Berry"));

        return company;
    }

    public static List<Company<List<User>>> CreateMultiCompanyWith_List() =>
        [Company<List<User>>.CreateSingleCompany("Future Ltd", ListType.List),
         Company<List<User>>.CreateSingleCompany("Vision Ltd", ListType.List)];

    public static Collection<Company<Collection<User>>> CreateMultiCompanyWith_Collection() =>
        [Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection),
         Company<Collection<User>>.CreateSingleCompany("Vision Ltd", ListType.Collection)];

    public static IList<Company<IList<User>>> CreateMultiCompanyWith_IList() =>
        [Company<IList<User>>.CreateSingleCompany("Future Ltd", ListType.IList),
         Company<IList<User>>.CreateSingleCompany("Vision Ltd", ListType.IList)];

    public static ICollection<Company<ICollection<User>>> CreateMultiCompanyWith_ICollection() =>
        [Company<ICollection<User>>.CreateSingleCompany("Future Ltd", ListType.ICollection),
         Company<ICollection<User>>.CreateSingleCompany("Vision Ltd", ListType.ICollection)];

    public static IEnumerable<Company<IEnumerable<User>>> CreateMultiCompanyWith_IEnumerable() =>
        [Company<IEnumerable<User>>.CreateSingleCompany("Future Ltd", ListType.IEnumerable),
         Company<IEnumerable<User>>.CreateSingleCompany("Vision Ltd", ListType.IEnumerable)];

    public static IReadOnlyCollection<Company<IReadOnlyCollection<User>>> CreateMultiCompanyWith_IReadOnlyCollection() =>
        [Company<IReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyCollection),
         Company<IReadOnlyCollection<User>>.CreateSingleCompany("Vision Ltd", ListType.IReadonlyCollection)];

    public static IReadOnlyList<Company<IReadOnlyList<User>>> CreateMultiCompanyWith_IReadOnlyList() =>
        [Company<IReadOnlyList<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyList),
         Company<IReadOnlyList<User>>.CreateSingleCompany("Vision Ltd", ListType.IReadonlyList)];

    public static ReadOnlyCollection<Company<ReadOnlyCollection<User>>> CreateMultiCompanyWith_ReadOnlyCollection() =>
        new([Company<ReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.ReadonlyCollection),
         Company<ReadOnlyCollection<User>>.CreateSingleCompany("Vision Ltd", ListType.ReadonlyCollection)]);
}
