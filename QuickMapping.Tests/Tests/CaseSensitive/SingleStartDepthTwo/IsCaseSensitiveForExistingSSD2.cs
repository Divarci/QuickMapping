using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.CaseSensitive.SingleStartDepthTwo;
public class IsCaseSensitiveForExistingSSD2
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveForExistingSSD2() =>
        _mapper = new QuickMapper(new MappingOptions()
        {
            IsSensitiveCase = false
        });

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_List()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<List<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<List<User>>.CreateSingleCompany("Future Ltd", ListType.List);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_Collection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<Collection<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IList()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<IList<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IList<User>>.CreateSingleCompany("Future Ltd", ListType.IList);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ICollection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<ICollection<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<ICollection<User>>.CreateSingleCompany("Future Ltd", ListType.ICollection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IEnumerable()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<IEnumerable<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IEnumerable<User>>.CreateSingleCompany("Future Ltd", ListType.IEnumerable);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyCollection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<IReadOnlyCollection<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyCollection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyList()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<IReadOnlyList<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = [new () { fullname = "Mel Gibson" },
                         new () { fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IReadOnlyList<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyList);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ReadonlyCollection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModelWithLowerCase<ReadOnlyCollection<UserViewModelWithLowerCase>>()
        {
            DESCRIPTION = "Future Software Ltd",
            director = new() { fullname = "Jackie Chan" },
            EmployeeS = new List<UserViewModelWithLowerCase> {
                new () { fullname = "Mel Gibson" },
                new () { fullname = "Denise Gilbert" } }
            .AsReadOnly()
        };

        var futureLtd = Company<ReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.ReadonlyCollection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.DESCRIPTION, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.director.fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }
}
