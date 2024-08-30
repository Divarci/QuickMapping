using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.DefaultOptions.CollectionStartDepthOne;
public class DefaultMappingCSD1
{
    private readonly IQuickMapper _mapper;

    public DefaultMappingCSD1() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_List()
    {
        //Arrange

        var users = User.CreateMultiUserWith_List();

        //Act

        var usersVM = _mapper.Map<List<User>, List<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count, users.Count);

    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_Collection()
    {
        //Arrange

        var users = User.CreateMultiUserWith_Collection();

        //Act

        var usersVM = _mapper.Map<Collection<User>, Collection<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count, users.Count);
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IList()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IList();

        //Act

        var usersVM = _mapper.Map<IList<User>, IList<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count, users.Count);
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_ICollection()
    {
        //Arrange

        var users = User.CreateMultiUserWith_ICollection();

        //Act

        var usersVM = _mapper.Map<ICollection<User>, ICollection<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count, users.Count);
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IEnumerable()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IEnumerable();

        //Act

        var usersVM = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users, 1);

        //Act & Assert

        Assert.Throws<MapperException>(() => _mapper.Map<IEnumerable<User>, IList<UserViewModel>>(users, 1));

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count(), users.Count());
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IReadonlyCollection()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IReadonlyCollection();

        //Act

        var usersVM = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count(), users.Count());
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IReadonlyList()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IReadonlyList();

        //Act

        var usersVM = _mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count(), users.Count());
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_ReadonlyCollection()
    {
        //Arrange

        var users = User.CreateMultiUserWith_ReadonlyCollection();

        //Act

        var usersVM = _mapper.Map<ReadOnlyCollection<User>, ReadOnlyCollection<UserViewModel>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count(), users.Count());
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IQueryable()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IQueryable();

        //Act

        var usersVM = _mapper.Map<IQueryable<User>, IQueryable<UserViewModel>>(users, 1);
       

        //Assert

        Assert.NotNull(usersVM);

        foreach (var user in usersVM)
            Assert.Null(user);

        Assert.Equal(usersVM.Count(), users.Count());
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_Primitives()
    {
        //Arrange

        var integers = new List<int> { 1, 2, 3 };        
        var enumerables = integers.AsEnumerable();
        var queryables = integers.AsQueryable();
        var readonlyObjects = (IReadOnlyCollection<int>)integers.AsReadOnly();

        //Act

        var integerObjects = _mapper.Map<List<int>, List<int>>(integers, 1);
        var enumerableObjects = _mapper.Map<IEnumerable<int>, IEnumerable<int>>(enumerables, 1);
        var queryableObjects = _mapper.Map<IQueryable<int>, IQueryable<int>>(queryables, 1);
        var iReadonlyCollection = _mapper.Map<IReadOnlyCollection<int>, IReadOnlyCollection<int>>(readonlyObjects, 1);

        //Assert

        Assert.NotNull(integerObjects);
        Assert.NotNull(enumerableObjects);
        Assert.NotNull(queryableObjects);
        Assert.NotNull(readonlyObjects);

        using (var integersEnumerator = integers.GetEnumerator())
        using (var integerObjectsEnumerator = integerObjects.GetEnumerator())
        using (var enumerableObjectsEnumerator = enumerableObjects.GetEnumerator())
        using (var queryableObjectsEnumerator = queryableObjects.GetEnumerator())
        using (var iReadonlyCollectionEnumerator = iReadonlyCollection.GetEnumerator())
        {
            while (integersEnumerator.MoveNext() &&
                   integerObjectsEnumerator.MoveNext() &&
                   enumerableObjectsEnumerator.MoveNext() &&
                   queryableObjectsEnumerator.MoveNext() &&
                   iReadonlyCollectionEnumerator.MoveNext())
            {
                var integer = integersEnumerator.Current;
                var integerObject = integerObjectsEnumerator.Current;
                var enumerableObject = enumerableObjectsEnumerator.Current;
                var queryableObject = queryableObjectsEnumerator.Current;
                var readonlyObject = iReadonlyCollectionEnumerator.Current;

                Assert.Equal(integerObject, integer);
                Assert.Equal(enumerableObject, integer);
                Assert.Equal(queryableObject, integer);
                Assert.Equal(readonlyObject, integer);                
            }
        }

        Assert.Equal(integers.Count, integerObjects.Count);
        Assert.Equal(integers.Count, enumerableObjects.Count());
        Assert.Equal(integers.Count, queryableObjects.Count());
        Assert.Equal(integers.Count, iReadonlyCollection.Count);
    }  
  }
