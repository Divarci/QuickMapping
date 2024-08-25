using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.CaseSensitive.CollectionStartDepthThree;
public class IsCaseSensitiveCSD3
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveCSD3() =>
        _mapper = new QuickMapper(new MappingOptions()
        {
            IsSensitiveCase = false
        });

    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_List()
    {
        //Arrange

        var europeCompanies = Company<List<User>>.CreateMultiCompanyWith_List();

        //Act

        var companyVM = _mapper.Map<List<Company<List<User>>>, List<CompanyViewModelWithLowerCase<List<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

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

    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_Collection()
    {
        //Arrange

        var europeCompanies = Company<Collection<User>>.CreateMultiCompanyWith_Collection();

        //Act

        var companyVM = _mapper.Map<Collection<Company<Collection<User>>>, Collection<CompanyViewModelWithLowerCase<Collection<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

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
    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_IList()
    {
        //Arrange

        var europeCompanies = Company<IList<User>>.CreateMultiCompanyWith_IList();

        //Act

        var companyVM = _mapper.Map<IList<Company<IList<User>>>, IList<CompanyViewModelWithLowerCase<IList<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

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

    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_ICollection()
    {
        //Arrange

        var europeCompanies = Company<ICollection<User>>.CreateMultiCompanyWith_ICollection();

        //Act

        var companyVM = _mapper.Map<ICollection<Company<ICollection<User>>>, ICollection<CompanyViewModelWithLowerCase<ICollection<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

        using (var europeCompaniesEnumerator = europeCompanies.GetEnumerator())
        using (var companyVMEnumerator = companyVM.GetEnumerator())
        {
            while (europeCompaniesEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var europeCompany = europeCompaniesEnumerator.Current;
                var companyVMItem = companyVMEnumerator.Current;

                Assert.NotNull(companyVMItem);
                Assert.Equal(companyVMItem.DESCRIPTION, europeCompany.Description);
                Assert.NotNull(companyVMItem.director);
                Assert.Equal(companyVMItem.director.fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.EmployeeS);
                Assert.Equal(companyVMItem.EmployeeS.Count, europeCompany.Employees.Count);

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.EmployeeS.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }
    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_IEnumerable()
    {
        //Arrange

        var europeCompanies = Company<ICollection<User>>.CreateMultiCompanyWith_IEnumerable();

        //Act

        var companyVM = _mapper.Map<IEnumerable<Company<IEnumerable<User>>>, IEnumerable<CompanyViewModelWithLowerCase<IEnumerable<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count(), europeCompanies.Count());

        using (var europeCompaniesEnumerator = europeCompanies.GetEnumerator())
        using (var companyVMEnumerator = companyVM.GetEnumerator())
        {
            while (europeCompaniesEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var europeCompany = europeCompaniesEnumerator.Current;
                var companyVMItem = companyVMEnumerator.Current;

                Assert.NotNull(companyVMItem);
                Assert.Equal(companyVMItem.DESCRIPTION, europeCompany.Description);
                Assert.NotNull(companyVMItem.director);
                Assert.Equal(companyVMItem.director.fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.EmployeeS);
                Assert.Equal(companyVMItem.EmployeeS.Count(), europeCompany.Employees.Count());

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.EmployeeS.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_IReadonlyCollection()
    {
        //Arrange

        var europeCompanies = Company<IReadOnlyCollection<User>>.CreateMultiCompanyWith_IReadOnlyCollection();

        //Act

        var companyVM = _mapper.Map<IReadOnlyCollection<Company<IReadOnlyCollection<User>>>, IReadOnlyCollection<CompanyViewModelWithLowerCase<IReadOnlyCollection<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

        using (var europeCompaniesEnumerator = europeCompanies.GetEnumerator())
        using (var companyVMEnumerator = companyVM.GetEnumerator())
        {
            while (europeCompaniesEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var europeCompany = europeCompaniesEnumerator.Current;
                var companyVMItem = companyVMEnumerator.Current;

                Assert.NotNull(companyVMItem);
                Assert.Equal(companyVMItem.DESCRIPTION, europeCompany.Description);
                Assert.NotNull(companyVMItem.director);
                Assert.Equal(companyVMItem.director.fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.EmployeeS);
                Assert.Equal(companyVMItem.EmployeeS.Count, europeCompany.Employees.Count);

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.EmployeeS.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_IReadonlyList()
    {
        //Arrange

        var europeCompanies = Company<IReadOnlyList<User>>.CreateMultiCompanyWith_IReadOnlyList();

        //Act

        var companyVM = _mapper.Map<IReadOnlyList<Company<IReadOnlyList<User>>>, IReadOnlyList<CompanyViewModelWithLowerCase<IReadOnlyList<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

        using (var europeCompaniesEnumerator = europeCompanies.GetEnumerator())
        using (var companyVMEnumerator = companyVM.GetEnumerator())
        {
            while (europeCompaniesEnumerator.MoveNext() && companyVMEnumerator.MoveNext())
            {
                var europeCompany = europeCompaniesEnumerator.Current;
                var companyVMItem = companyVMEnumerator.Current;

                Assert.NotNull(companyVMItem);
                Assert.Equal(companyVMItem.DESCRIPTION, europeCompany.Description);
                Assert.NotNull(companyVMItem.director);
                Assert.Equal(companyVMItem.director.fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.EmployeeS);
                Assert.Equal(companyVMItem.EmployeeS.Count, europeCompany.Employees.Count);
                
                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.EmployeeS.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_3_For_ReadonlyCollection()
    {
        //Arrange

        var europeCompanies = Company<ReadOnlyCollection<User>>.CreateMultiCompanyWith_ReadOnlyCollection();

        //Act

        var companyVM = _mapper.Map<ReadOnlyCollection<Company<ReadOnlyCollection<User>>>, ReadOnlyCollection<CompanyViewModelWithLowerCase<ReadOnlyCollection<UserViewModelWithLowerCase>>>>(europeCompanies, 3);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

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
