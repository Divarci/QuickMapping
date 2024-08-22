using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.DefaultOptions;
public class DefaultOption
{
    private readonly IQuickMapper _mapper;

    public DefaultOption() =>
        _mapper = new QuickMapper();

    [Fact]
    public void Single_Start_Mapping_Depth_1()
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
    public void Single_Start_Mapping_Depth_2()
    {
        //Arrange
        var director = new User(1, "Gary Wheel", 37);

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var employees = new List<User>() { michael, john, chuck };

        var futureLtd = new Company(1, "Future Ltd", employees, director);

        //Act 

        var companyVM = _mapper.Map<Company, CompanyViewModel>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);
        Assert.Equal(companyVM.Director.Fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.Employees.Count, futureLtd.Employees.Count);

        foreach (var employee in companyVM.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_3()
    {
        //Arrange
        var director = new User(1, "Gary Wheel", 37);

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var employees = new List<User>() { michael, john, chuck };

        var futureLtd = new Company(1, "Future Ltd", employees, director);

        //Act 

        var companyVM = _mapper.Map<Company, CompanyViewModel>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);
        Assert.Equal(companyVM.Director.Fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.Employees.Count, futureLtd.Employees.Count);

        for (int i = 0; i < companyVM.Employees.Count; i++)
        {
            Assert.NotNull(companyVM.Employees[i]);
            Assert.Equal(companyVM.Employees[i].Fullname, futureLtd.Employees[i].Fullname);
        }
            
    }

    [Fact]
    public void Destination_Connections_Throws_Exception()
    {
        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var users = new List<User>() { michael, john, chuck };

        Assert.Throws<MapperException>(() =>
        {
            var ICollectionError = _mapper.Map<List<User>, ICollection<UserViewModel>>(users, 1);
            var IEnumerableError = _mapper.Map<List<User>, IEnumerable<UserViewModel>>(users, 1);
            var IListError = _mapper.Map<List<User>, IList<UserViewModel>>(users, 1);
            var IReadOnlyCollectionError = _mapper.Map<List<User>, IReadOnlyCollection<UserViewModel>>(users, 1);
            var IReadOnlyListError = _mapper.Map<List<User>, IReadOnlyList<UserViewModel>>(users, 1);
            var CollectionError = _mapper.Map<List<User>, Collection<UserViewModel>>(users, 1);
            var ReadOnlyCollectionError = _mapper.Map<List<User>, ReadOnlyCollection<UserViewModel>>(users, 1);
        });
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_1()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var users = new List<User>() { michael, john, chuck };
        var members = users.AsEnumerable();

        //Act

        var usersVM = _mapper.Map<List<User>, List<UserViewModel>>(users, 1);
        var memberVM = _mapper.Map<IEnumerable<User>, List<UserViewModel>>(members, 1);
       
        //Assert

        Assert.NotNull(usersVM);
        Assert.NotNull(memberVM);             

        foreach (var user in usersVM)
            Assert.Null(user);

        foreach (var member in memberVM)
            Assert.Null(member);

        Assert.Equal(usersVM.Count, users.Count);
        Assert.Equal(memberVM.Count, members.Count());

    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var employees = new List<User>() { michael, john };
        var labours = new List<User>() { chuck, john };

        var director = new User(1, "Gary Wheel", 37);

        var futureLtd = new Company(1, "Future Ltd", employees, director);
        var visionLtd = new Company(2, "Vision Ltd", labours, director);

        var europeCompanies = new List<Company>() { futureLtd, visionLtd };

        //Act

        var companyVM = _mapper.Map<List<Company>, List<CompanyViewModel>>(europeCompanies,2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count());

        for (int i = 0; i < companyVM.Count; i++)
        {
            Assert.NotNull(companyVM[i]);
            Assert.Equal(companyVM[i].Description, europeCompanies[i].Description);
            Assert.NotNull(companyVM[i].Director);
            Assert.Equal(companyVM[i].Director.Fullname, europeCompanies[i].Director.Fullname);
            Assert.NotNull(companyVM[i].Employees);
            Assert.Equal(companyVM[i].Employees.Count, europeCompanies[i].Employees.Count);

            for (int y = 0; y < companyVM[i].Employees.Count; y++)            
                Assert.Null(companyVM[i].Employees[y]);   
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_3()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);
        var john = new User(2, "John Wick", 42);
        var chuck = new User(3, "Chuck Bartowski", 33);

        var employees = new List<User>() { michael, john };
        var labours = new List<User>() { chuck, john };

        var director = new User(1, "Gary Wheel", 37);

        var futureLtd = new Company(1, "Future Ltd", employees, director);
        var visionLtd = new Company(2, "Vision Ltd", labours, director);

        var europeCompanies = new List<Company>() { futureLtd, visionLtd };

        //Act

        var companyVM = _mapper.Map<List<Company>, List<CompanyViewModel>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count());

        for (int i = 0; i < companyVM.Count; i++)
        {
            Assert.NotNull(companyVM[i]);
            Assert.Equal(companyVM[i].Description, europeCompanies[i].Description);
            Assert.NotNull(companyVM[i].Director);
            Assert.Equal(companyVM[i].Director.Fullname, europeCompanies[i].Director.Fullname);
            Assert.NotNull(companyVM[i].Employees);
            Assert.Equal(companyVM[i].Employees.Count, europeCompanies[i].Employees.Count);

            for (int y = 0; y < companyVM[i].Employees.Count; y++)
                Assert.Equal(companyVM[i].Employees[y].Fullname, europeCompanies[i].Employees[y].Fullname);
        }
    }   
}
