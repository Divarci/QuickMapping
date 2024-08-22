using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.CaseSensitive;
public class IsCaseSensitiveFalse
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveFalse() =>
        _mapper = new QuickMapper(new MappingOptions()
        {
            IsSensitiveCase = false
        });

    [Fact]
    public void Single_Start_Mapping_Depth_1()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);

        //Act 

        var userVM = _mapper.Map<User, UserViewModelWithLowerCase>(michael, 1);

        //Assert

        Assert.NotNull(userVM);
        Assert.Equal(userVM.fullname, michael.Fullname);
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

        var companyVM = _mapper.Map<Company, CompanyViewModelWithLowerCase>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in companyVM.EmployeeS)
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

        var companyVM = _mapper.Map<Company, CompanyViewModelWithLowerCase>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        for (int i = 0; i < companyVM.EmployeeS.Count; i++)
        {
            Assert.NotNull(companyVM.EmployeeS[i]);
            Assert.Equal(companyVM.EmployeeS[i].fullname, futureLtd.Employees[i].Fullname);
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
            var ICollectionError = _mapper.Map<List<User>, ICollection<UserViewModelWithLowerCase>>(users, 1);
            var IEnumerableError = _mapper.Map<List<User>, IEnumerable<UserViewModelWithLowerCase>>(users, 1);
            var IListError = _mapper.Map<List<User>, IList<UserViewModelWithLowerCase>>(users, 1);
            var IReadOnlyCollectionError = _mapper.Map<List<User>, IReadOnlyCollection<UserViewModelWithLowerCase>>(users, 1);
            var IReadOnlyListError = _mapper.Map<List<User>, IReadOnlyList<UserViewModelWithLowerCase>>(users, 1);
            var CollectionError = _mapper.Map<List<User>, Collection<UserViewModelWithLowerCase>>(users, 1);
            var ReadOnlyCollectionError = _mapper.Map<List<User>, ReadOnlyCollection<UserViewModelWithLowerCase>>(users, 1);
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

        var usersVM = _mapper.Map<List<User>, List<UserViewModelWithLowerCase>>(users, 1);
        var memberVM = _mapper.Map<IEnumerable<User>, List<UserViewModelWithLowerCase>>(members, 1);

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

        var companyVM = _mapper.Map<List<Company>, List<CompanyViewModelWithLowerCase>>(europeCompanies, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count());

        for (int i = 0; i < companyVM.Count; i++)
        {
            Assert.NotNull(companyVM[i]);
            Assert.Equal(companyVM[i].DESCRIPTION, europeCompanies[i].Description);
            Assert.NotNull(companyVM[i].director);
            Assert.Equal(companyVM[i].director.fullname, europeCompanies[i].Director.Fullname);
            Assert.NotNull(companyVM[i].EmployeeS);
            Assert.Equal(companyVM[i].EmployeeS.Count, europeCompanies[i].Employees.Count);

            for (int y = 0; y < companyVM[i].EmployeeS.Count; y++)
                Assert.Null(companyVM[i].EmployeeS[y]);
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

        var companyVM = _mapper.Map<List<Company>, List<CompanyViewModelWithLowerCase>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count());

        for (int i = 0; i < companyVM.Count; i++)
        {
            Assert.NotNull(companyVM[i]);
            Assert.Equal(companyVM[i].DESCRIPTION, europeCompanies[i].Description);
            Assert.NotNull(companyVM[i].director);
            Assert.Equal(companyVM[i].director.fullname, europeCompanies[i].Director.Fullname);
            Assert.NotNull(companyVM[i].EmployeeS);
            Assert.Equal(companyVM[i].EmployeeS.Count, europeCompanies[i].Employees.Count);

            for (int y = 0; y < companyVM[i].EmployeeS.Count; y++)
                Assert.Equal(companyVM[i].EmployeeS[y].fullname, europeCompanies[i].Employees[y].Fullname);
        }
    }
}
