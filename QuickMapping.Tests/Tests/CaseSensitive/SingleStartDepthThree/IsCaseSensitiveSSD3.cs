using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.CaseSensitive.SingleStartDepthThree;
public class IsCaseSensitiveSSD3
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveSSD3() =>
         _mapper = new QuickMapper(new MappingOptions()
         {
             IsSensitiveCase = false
         });

    [Fact]
    public void Single_Start_Mapping_Depth_3_For_List()
    {
        //Arrange

        var futureLtd = Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection);

        //Act 

        var companyVM = _mapper.Map<Company<Collection<User>>, CompanyViewModelWithLowerCase<Collection<UserViewModelWithLowerCase>>>(futureLtd, 3);

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
    public void Single_Start_Mapping_Depth_3_For_Collection()
    {
        //Arrange

        var futureLtd = Company<Collection<User>>.CreateSingleCompany("Future Ltd", ListType.Collection);

        //Act 

        var companyVM = _mapper.Map<Company<Collection<User>>, CompanyViewModelWithLowerCase<Collection<UserViewModelWithLowerCase>>>(futureLtd, 3);

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
    public void Single_Start_Mapping_Depth_3_For_IList()
    {
        //Arrange

        var futureLtd = Company<IList<User>>.CreateSingleCompany("Future Ltd", ListType.IList);

        //Act 

        var companyVM = _mapper.Map<Company<IList<User>>, CompanyViewModelWithLowerCase<IList<UserViewModelWithLowerCase>>>(futureLtd, 3);

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
    public void Single_Start_Mapping_Depth_3_For_ICollection()
    {
        //Arrange

        var futureLtd = Company<ICollection<User>>.CreateSingleCompany("Future Ltd", ListType.ICollection);

        //Act 

        var companyVM = _mapper.Map<Company<ICollection<User>>, CompanyViewModelWithLowerCase<ICollection<UserViewModelWithLowerCase>>>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count, futureLtd.Employees.Count);

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.EmployeeS.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.fullname, futureLtdEmployee.Fullname);
            }
        }
    }

    [Fact]
    public void Single_Start_Mapping_Depth_3_For_IEnumerable()
    {
        //Arrange

        var futureLtd = Company<IEnumerable<User>>.CreateSingleCompany("Future Ltd", ListType.IEnumerable);

        //Act 

        var companyVM = _mapper.Map<Company<IEnumerable<User>>, CompanyViewModelWithLowerCase<IEnumerable<UserViewModelWithLowerCase>>>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.EmployeeS.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.fullname, futureLtdEmployee.Fullname);
            }
        }

    }

    [Fact]
    public void Single_Start_Mapping_Depth_3_For_IReadonlyCollection()
    {
        //Arrange

        var futureLtd = Company<IReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyCollection);

        //Act 

        var companyVM = _mapper.Map<Company<IReadOnlyCollection<User>>, CompanyViewModelWithLowerCase<IReadOnlyCollection<UserViewModelWithLowerCase>>>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.EmployeeS.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.fullname, futureLtdEmployee.Fullname);
            }
        }

    }

    [Fact]
    public void Single_Start_Mapping_Depth_3_For_IReadonlyList()
    {
        //Arrange

        var futureLtd = Company<IReadOnlyList<User>>.CreateSingleCompany("Future Ltd", ListType.IReadonlyList);

        //Act 

        var companyVM = _mapper.Map<Company<IReadOnlyList<User>>, CompanyViewModelWithLowerCase<IReadOnlyList<UserViewModelWithLowerCase>>>(futureLtd, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.DESCRIPTION, futureLtd.Description);
        Assert.Equal(companyVM.director.fullname, futureLtd.Director!.Fullname);
        Assert.Equal(companyVM.EmployeeS.Count(), futureLtd.Employees.Count());

        using (var futureLtdEnumerator = futureLtd.Employees.GetEnumerator())
        using (var companyVMEnumerator = companyVM.EmployeeS.GetEnumerator())
        {
            while (futureLtdEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var futureLtdEmployee = futureLtdEnumerator.Current;
                var companyVMEmployee = companyVMEnumerator.Current;

                Assert.NotNull(companyVMEmployee);
                Assert.Equal(companyVMEmployee.fullname, futureLtdEmployee.Fullname);
            }
        }

    }

    [Fact]
    public void Single_Start_Mapping_Depth_3_For_ReadonlyCollection()
    {
        //Arrange

        var futureLtd = Company<ReadOnlyCollection<User>>.CreateSingleCompany("Future Ltd", ListType.ReadonlyCollection);

        //Act 

        var companyVM = _mapper.Map<Company<ReadOnlyCollection<User>>, CompanyViewModelWithLowerCase<ReadOnlyCollection<UserViewModelWithLowerCase>>>(futureLtd, 3);

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
}
