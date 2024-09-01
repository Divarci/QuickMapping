using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Extensions;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.CaseSensitive.CollectionStartDepthOne;
public class IsCaseSensitiveCSD1
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveCSD1() =>
        _mapper = new QuickMapper(new MappingOptions()
        {
            IsSensitiveCase = false
        });

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_List()
    {
        //Arrange

        var users = User.CreateMultiUserWith_List();

        //Act

        var usersVM = _mapper.Map<List<User>, List<UserViewModelWithLowerCase>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].fullname, users[i].Fullname);
        }

        Assert.Equal(usersVM.Count, users.Count);

    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_Collection()
    {
        //Arrange

        var users = User.CreateMultiUserWith_Collection();

        //Act

        var usersVM = _mapper.Map<Collection<User>, Collection<UserViewModelWithLowerCase>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].fullname, users[i].Fullname);
        }

        Assert.Equal(usersVM.Count, users.Count);
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IList()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IList();

        //Act

        var usersVM = _mapper.Map<IList<User>, IList<UserViewModelWithLowerCase>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].fullname, users[i].Fullname);
        }

        Assert.Equal(usersVM.Count, users.Count);
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_ICollection()
    {
        //Arrange

        var users = User.CreateMultiUserWith_ICollection();

        //Act

        var usersVM = _mapper.Map<ICollection<User>, ICollection<UserViewModelWithLowerCase>>(users, 1);

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
                Assert.Equal(user.Fullname, userVM.fullname);
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

        var usersVM = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModelWithLowerCase>>(users, 1);

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
                Assert.Equal(user.Fullname, userVM.fullname);
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

        var usersVM = _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<UserViewModelWithLowerCase>>(users, 1);

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
                Assert.Equal(user.Fullname, userVM.fullname);
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

        var usersVM = _mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserViewModelWithLowerCase>>(users, 1);

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
                Assert.Equal(user.Fullname, userVM.fullname);
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

        var usersVM = _mapper.Map<ReadOnlyCollection<User>, ReadOnlyCollection<UserViewModelWithLowerCase>>(users, 1);

        //Assert

        Assert.NotNull(usersVM);

        for (int i = 0; i < usersVM.Count; i++)
        {
            Assert.NotNull(usersVM[i]);
            Assert.Equal(usersVM[i].fullname, users[i].Fullname);
        }

        Assert.Equal(usersVM.Count(), users.Count());
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_For_IQueryable()
    {
        //Arrange

        var users = User.CreateMultiUserWith_IQueryable();

        //Act

        var usersVM = _mapper.Map<IQueryable<User>, IQueryable<UserViewModelWithLowerCase>>(users, 1);


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
                Assert.Equal(user.Fullname, userVM.fullname);
            }
        }

        Assert.Equal(usersVM.Count(), users.Count());
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
        var complexMapper = _mapper.Map<User[], UserViewModelWithLowerCase[]>(complexArray, 1);
        var complexMapperWithCollection = _mapper.Map<List<Company<List<User>>>[], List<CompanyViewModelWithLowerCase<List<UserViewModelWithLowerCase>>>[]>
            (complexArrayWithCollection, 1);

        //Assert
        Assert.NotNull(intMapper);
        Assert.Equal(primitiveArrayInt.Length, intMapper.Length);

        Assert.NotNull(complexMapper);
        for (int i = 0; i < complexMapper.Length; i++)
        {
            Assert.NotNull(complexMapper[i]);
            Assert.Equal(complexMapper[i].fullname, complexArray[i].Fullname);
        }

        Assert.NotNull(complexMapperWithCollection);
        for (int i = 0; i < complexMapperWithCollection.Length; i++)
        {
            Assert.Equal(complexMapperWithCollection[i].Count, complexArrayWithCollection[i].Count);
            for (int y = 0; y < complexMapperWithCollection[i].Count; y++)
            {
                Assert.Equal(complexMapperWithCollection[i][y].DESCRIPTION, complexArrayWithCollection[i][y].Description);
                Assert.Null(complexMapperWithCollection[i][y].director);
                Assert.Null(complexMapperWithCollection[i][y].EmployeeS);
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1_IQueryable_Extension()
    {
        //Arrange
        var users = User.CreateMultiUserWith_IQueryable();

        //Act
        var usersVM = users.MapTo<UserViewModelWithLowerCase>(1, _mapper.configurations);
        var newQuery = usersVM.Where(x => x.fullname.StartsWith('J'));
        var secondQuery = newQuery.Select(x => new
        {
            Greeting = $"{x.fullname.First()}{x.fullname.Last()}"
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
                Assert.Equal(user.Fullname, userVM.fullname);
            }
        }

        Assert.Equal(usersVM.Count(), users.Count());
        Assert.NotNull(newQuery);
        Assert.Equal(2, newQuery.Count());
        Assert.True(secondQuery.Any(x => x.Greeting == "Je"));
    }
}
