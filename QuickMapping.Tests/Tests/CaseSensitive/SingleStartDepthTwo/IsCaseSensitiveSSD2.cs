using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.CaseSensitive.SingleStartDepthTwo;
public class IsCaseSensitiveSSD2
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveSSD2() =>
         _mapper = new QuickMapper(new MappingOptions()
         {
             IsSensitiveCase = false
         });

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_List()
    {
        //Arrange

        var futureLtd = Company<List<User>>.CreateSingleCompany("Future Ltd", ListType.List);

        //Act 

        var companyVM = _mapper.Map<Company<List<User>>, CompanyViewModelWithLowerCase<List<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_Collection()
    {
        //Arrange

        var futureLtd = Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection);

        //Act 

        var companyVM = _mapper.Map<Company<Collection<User>>, CompanyViewModelWithLowerCase<Collection<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IList()
    {
        //Arrange

        var futureLtd = Company<IList<User>>.CreateSingleCompany("Future Ltd", ListType.IList);

        //Act 

        var companyVM = _mapper.Map<Company<IList<User>>, CompanyViewModelWithLowerCase<IList<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ICollection()
    {
        //Arrange

        var futureLtd = Company<ICollection<User>>.CreateSingleCompany("Future Ltd", ListType.ICollection);

        //Act 

        var companyVM = _mapper.Map<Company<ICollection<User>>, CompanyViewModelWithLowerCase<ICollection<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IEnumerable()
    {
        //Arrange

        var futureLtd = Company<IEnumerable<User>>.CreateSingleCompany("Future Ltd", ListType.IEnumerable);

        //Act 

        var companyVM = _mapper.Map<Company<IEnumerable<User>>, CompanyViewModelWithLowerCase<IEnumerable<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyCollection()
    {
        //Arrange

        var futureLtd = Company<IReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyCollection);

        //Act 

        var companyVM = _mapper.Map<Company<IReadOnlyCollection<User>>, CompanyViewModelWithLowerCase<IReadOnlyCollection<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyList()
    {
        //Arrange

        var futureLtd = Company<IReadOnlyList<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyList);

        //Act 

        var companyVM = _mapper.Map<Company<IReadOnlyList<User>>, CompanyViewModelWithLowerCase<IReadOnlyList<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ReadonlyCollection()
    {
        //Arrange

        var futureLtd = Company<ReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.ReadonlyCollection);

        //Act 

        var companyVM = _mapper.Map<Company<ReadOnlyCollection<User>>, CompanyViewModelWithLowerCase<ReadOnlyCollection<UserViewModelWithLowerCase>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        foreach (var employee in companyVM.EmployeeS)
            Assert.Null(employee);
    }
}
