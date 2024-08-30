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
  
}
