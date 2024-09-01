using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.DefaultOptions.SingleStartDepthTwo;
public class DefaultMappingSSD2
{
    private readonly IQuickMapper _mapper;

    public DefaultMappingSSD2() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_List()
    {
        //Arrange

        var futureLtd = Company<List<User>>.CreateSingleCompany("Future Ltd", ListType.List);

        //Act 

        var companyVM = _mapper.Map<Company<List<User>>, CompanyViewModel<List<UserViewModel>>>(futureLtd, 2);

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
    public void Single_Start_Mapping_Depth_2_For_Collection()
    {
        //Arrange

        var futureLtd = Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection);

        //Act 

        var companyVM = _mapper.Map<Company<Collection<User>>, CompanyViewModel<Collection<UserViewModel>>>(futureLtd, 2);

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
    public void Single_Start_Mapping_Depth_2_For_IList()
    {
        //Arrange

        var futureLtd = Company<IList<User>>.CreateSingleCompany("Future Ltd", ListType.IList);

        //Act 

        var companyVM = _mapper.Map<Company<IList<User>>, CompanyViewModel<IList<UserViewModel>>>(futureLtd, 2);

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
    public void Single_Start_Mapping_Depth_2_For_ICollection()
    {
        //Arrange

        var futureLtd = Company<ICollection<User>>.CreateSingleCompany("Future Ltd", ListType.ICollection);

        //Act 

        var companyVM = _mapper.Map<Company<ICollection<User>>, CompanyViewModel<ICollection<UserViewModel>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);
        Assert.Equal(companyVM.Director.Fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.Employees.Count, futureLtd.Employees.Count);

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.Employees.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.Fullname, futureLtdEmployee.Fullname);
            }
        }
    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IEnumerable()
    {
        //Arrange

        var futureLtd = Company<IEnumerable<User>>.CreateSingleCompany("Future Ltd", ListType.IEnumerable);

        //Act 

        var companyVM = _mapper.Map<Company<IEnumerable<User>>, CompanyViewModel<IEnumerable<UserViewModel>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);
        Assert.Equal(companyVM.Director.Fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.Employees.Count(), futureLtd.Employees.Count());

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.Employees.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.Fullname, futureLtdEmployee.Fullname);
            }
        }

    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyCollection()
    {
        //Arrange

        var futureLtd = Company<IReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyCollection);

        //Act 

        var companyVM = _mapper.Map<Company<IReadOnlyCollection<User>>, CompanyViewModel<IReadOnlyCollection<UserViewModel>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);
        Assert.Equal(companyVM.Director.Fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.Employees.Count(), futureLtd.Employees.Count());

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.Employees.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.Fullname, futureLtdEmployee.Fullname);
            }
        }

    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_IReadonlyList()
    {
        //Arrange

        var futureLtd = Company<IReadOnlyList<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyList);

        //Act 

        var companyVM = _mapper.Map<Company<IReadOnlyList<User>>, CompanyViewModel<IReadOnlyList<UserViewModel>>>(futureLtd, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Description, futureLtd.Description);
        Assert.Equal(companyVM.Director.Fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.Employees.Count(), futureLtd.Employees.Count());

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.Employees.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.Fullname, futureLtdEmployee.Fullname);
            }
        }

    }

    [Fact]
    public void Single_Start_Mapping_Depth_2_For_ReadonlyCollection()
    {
        //Arrange

        var futureLtd = Company<ReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.ReadonlyCollection);

        //Act 

        var companyVM = _mapper.Map<Company<ReadOnlyCollection<User>>, CompanyViewModel<ReadOnlyCollection<UserViewModel>>>(futureLtd, 2);

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

}
