using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;

namespace QuickMapping.Tests.Tests.DefaultOptions;
public class DefaultOption
{
    private readonly IQuickMapper _mapper;

    public DefaultOption() =>
        _mapper = new QuickMapper();

    [Fact]
    public void Single_To_Single_Mapping_Depth_1()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);

        //Act 

        var userVM = _mapper.Map<User, UserViewModel>(michael, 1);

        //Assert

        Assert.NotNull(userVM);
        Assert.Equal(userVM.Fullname, michael.Fullname);
    }

    [Fact]
    public void Collection_To_Collection_Mapping_List_List_Depth_2()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var users = new List<User>() { michael, john, chuck };
        var members = users.AsEnumerable();

        //Act

        var usersVM = _mapper.Map<List<User>, List<UserViewModel>>(users, 2);
        var memberVM = _mapper.Map<IEnumerable<User>, List<UserViewModel>>(members, 2);

        //Act&Assert

        Assert.Throws<MapperException>(() =>
        {
            var usersVMError = _mapper.Map<List<User>, ICollection<UserViewModel>>(users, 2);
        });

        //Assert

        Assert.NotNull(usersVM);
        Assert.NotNull(memberVM);

        for (int i = 0; i < users.Count; i++)
            Assert.Equal(usersVM[i].Fullname, users[i].Fullname);

        for (int i = 0; i < members.Count(); i++)
            Assert.Equal(memberVM[i].Fullname, users[i].Fullname);

        Assert.Equal(usersVM.Count, users.Count);
        Assert.Equal(memberVM.Count, members.Count());

    }

    [Fact]
    public void Single_To_Single_With_Nested_Collection_Depth_3()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var futureLtd = new Company(1, "Future Ltd", [michael, john, chuck]);

        //Act

        var companyVM = _mapper.Map<Company, CompanyViewModel>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);

        for (int i = 0; i < companyVM.Employees.Count; i++)
            Assert.Equal(companyVM.Employees[i].Fullname, futureLtd.Employees[i].Fullname);

        Assert.Equal(companyVM.Employees.Count, futureLtd.Employees.Count);
    }
}
