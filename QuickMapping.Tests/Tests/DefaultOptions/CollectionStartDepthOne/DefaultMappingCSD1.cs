using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Extensions;
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

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].Fullname, users[i].Fullname);
        }

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

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].Fullname, users[i].Fullname);
        }

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

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].Fullname, users[i].Fullname);
        }

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

        using (var usersEnumerator = users.GetEnumerator())
        using (var usersVMEnumerator = usersVM.GetEnumerator())
        {
            while (usersEnumerator.MoveNext() && usersVMEnumerator.MoveNext())
            {
                var user = usersEnumerator.Current;
                var userVM = usersVMEnumerator.Current;

                Assert.NotNull(user);
                Assert.Equal(user.Fullname, userVM.Fullname);
            }
        }

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

        using (var usersEnumerator = users.GetEnumerator())
        using (var usersVMEnumerator = usersVM.GetEnumerator())
        {
            while (usersEnumerator.MoveNext() && usersVMEnumerator.MoveNext())
            {
                var user = usersEnumerator.Current;
                var userVM = usersVMEnumerator.Current;

                Assert.NotNull(user);
                Assert.Equal(user.Fullname, userVM.Fullname);
            }
        }

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

        using (var usersEnumerator = users.GetEnumerator())
        using (var usersVMEnumerator = usersVM.GetEnumerator())
        {
            while (usersEnumerator.MoveNext() && usersVMEnumerator.MoveNext())
            {
                var user = usersEnumerator.Current;
                var userVM = usersVMEnumerator.Current;

                Assert.NotNull(user);
                Assert.Equal(user.Fullname, userVM.Fullname);
            }
        }

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

        using (var usersEnumerator = users.GetEnumerator())
        using (var usersVMEnumerator = usersVM.GetEnumerator())
        {
            while (usersEnumerator.MoveNext() && usersVMEnumerator.MoveNext())
            {
                var user = usersEnumerator.Current;
                var userVM = usersVMEnumerator.Current;

                Assert.NotNull(user);
                Assert.Equal(user.Fullname, userVM.Fullname);
            }
        }

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

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].Fullname, users[i].Fullname);
        }

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

        using (var usersEnumerator = users.GetEnumerator())
        using (var usersVMEnumerator = usersVM.GetEnumerator())
        {
            while (usersEnumerator.MoveNext() && usersVMEnumerator.MoveNext())
            {
                var user = usersEnumerator.Current;
                var userVM = usersVMEnumerator.Current;

                Assert.NotNull(user);
                Assert.Equal(user.Fullname, userVM.Fullname);
            }
        }

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

    [Fact]
    public void Collection_Start_Mapping_Depth_1_Array()
    {
        //Arrange
        var primitiveArrayInt = new[] { 1, 2, 3 };
        var complexArray = new[] { User.CreateSingleUser("Michael Jenkins"), User.CreateSingleUser("Demi John") };
        var complexArrayWithCollection = new[] {
            Company<List<User>>.CreateMultiCompanyWith_List(),
            Company<List<User>>.CreateMultiCompanyWith_List() };

        //Act
        var intMapper = _mapper.Map<int[], int[]>(primitiveArrayInt, 1);
        var complexMapper = _mapper.Map<User[], UserViewModel[]>(complexArray, 1);
        var complexMapperWithCollection = _mapper.Map<List<Company<List<User>>>[], List<CompanyViewModel<List<UserViewModel>>>[]>
            (complexArrayWithCollection, 1);

        //Assert
        Assert.NotNull(intMapper);
        Assert.Equal(primitiveArrayInt.Length, intMapper.Length);

        Assert.NotNull(complexMapper);
        for (int i = 0; i < complexMapper.Length; i++)
        {
            Assert.NotNull(complexMapper[i]);
            Assert.Equal(complexMapper[i].Fullname, complexArray[i].Fullname);
        }

        Assert.NotNull(complexMapperWithCollection);
        for (int i = 0; i < complexMapperWithCollection.Length; i++)
        {
            Assert.Equal(complexMapperWithCollection[i].Count, complexArrayWithCollection[i].Count);
            for (int y = 0; y < complexMapperWithCollection[i].Count; y++)
            {
                Assert.Equal(complexMapperWithCollection[i][y].Description, complexArrayWithCollection[i][y].Description);
                Assert.Null(complexMapperWithCollection[i][y].Director);
                Assert.Null(complexMapperWithCollection[i][y].Employees);
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_IQueryable_Extension()
    {
        //Arrange
        var users = User.CreateMultiUserWith_IQueryable();

        //Act
        var usersVM = users.MapTo<UserViewModel>(1,null);
        var newQuery = usersVM.Where(x => x.Fullname.StartsWith('J'));
        var secondQuery = newQuery.Select(x => new
        {
            Greeting = $"{x.Fullname.First()}{x.Fullname.Last()}"
        });

        //Assert

        Assert.NotNull(usersVM);

        using (var usersEnumerator = users.GetEnumerator())
        using (var usersVMEnumerator = usersVM.GetEnumerator())
        {
            while (usersEnumerator.MoveNext() && usersVMEnumerator.MoveNext())
            {
                var user = usersEnumerator.Current;
                var userVM = usersVMEnumerator.Current;

                Assert.NotNull(user);
                Assert.Equal(user.Fullname, userVM.Fullname);
            }
        }

        Assert.Equal(usersVM.Count(), users.Count());
        Assert.NotNull(newQuery);       
        Assert.Equal(2,newQuery.Count());
        Assert.True(secondQuery.Any(x => x.Greeting == "Je"));
    }
}
