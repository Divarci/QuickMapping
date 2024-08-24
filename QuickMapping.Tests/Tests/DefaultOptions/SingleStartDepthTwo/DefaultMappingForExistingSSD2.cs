using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.DefaultOptions.SingleStartDepthOne;
public class DefaultMappingForExistingSSD2
{
    private readonly IQuickMapper _mapper;

    public DefaultMappingForExistingSSD2() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_List()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<List<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<List<User>>.CreateSingleCompany("Future Ltd", ListType.List);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_Collection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<Collection<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IList()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<IList<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IList<User>>.CreateSingleCompany("Future Ltd", ListType.IList);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ICollection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<ICollection<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<ICollection<User>>.CreateSingleCompany("Future Ltd", ListType.ICollection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count, futureLtd.Employees.Count);

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IEnumerable()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<IEnumerable<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IEnumerable<User>>.CreateSingleCompany("Future Ltd", ListType.IEnumerable);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyCollection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<IReadOnlyCollection<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyCollection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyList()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<IReadOnlyList<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = [new () { Fullname = "Mel Gibson" },
                         new () { Fullname = "Denise Gilbert" }]
        };

        var futureLtd = Company<IReadOnlyList<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyList);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ReadonlyCollection()
    {
        //Arrange

        var newFutureLtd = new CompanyViewModel<ReadOnlyCollection<UserViewModel>>()
        {
            Description = "Future Software Ltd",
            Director = new() { Fullname = "Jackie Chan" },
            Employees = new List<UserViewModel>() {
                new () { Fullname = "Mel Gibson" },
                new () { Fullname = "Denise Gilbert" } }
            .AsReadOnly()
        };

        var futureLtd = Company<ReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.ReadonlyCollection);

        //Act 

        var company = _mapper.Map(newFutureLtd, futureLtd, 2);

        //Assert

        Assert.NotNull(company);
        Assert.Same(company, futureLtd);
        Assert.Equal(newFutureLtd.Description, futureLtd.Description);
        Assert.Same(company.Director, futureLtd.Director);
        Assert.Equal(newFutureLtd.Director.Fullname, futureLtd.Director.Fullname);
        Assert.Equal(newFutureLtd.Employees.Count(), futureLtd.Employees.Count());

        foreach (var employee in futureLtd.Employees)
            Assert.Null(employee);
    }
}
