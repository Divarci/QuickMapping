using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Extensions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.DefaultOptions.CollectionStartDepthTwo;
public class DefaultMappingCSD2
{
    private readonly IQuickMapper _mapper;

    public DefaultMappingCSD2() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_List()
    {
        //Arrange

        var europeCompanies = Company<List<User>>.CreateMultiCompanyWith_List();

        //Act

        var companyVM = _mapper.Map<List<Company<List<User>>>, List<CompanyViewModel<List<UserViewModel>>>>(europeCompanies, 2);

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

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_Collection()
    {
        //Arrange

        var europeCompanies = Company<Collection<User>>.CreateMultiCompanyWith_Collection();

        //Act

        var companyVM = _mapper.Map<Collection<Company<Collection<User>>>, Collection<CompanyViewModel<Collection<UserViewModel>>>>(europeCompanies, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

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

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_IList()
    {
        //Arrange

        var europeCompanies = Company<IList<User>>.CreateMultiCompanyWith_IList();

        //Act

        var companyVM = _mapper.Map<IList<Company<IList<User>>>, IList<CompanyViewModel<IList<UserViewModel>>>>(europeCompanies, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

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

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_ICollection()
    {
        //Arrange

        var europeCompanies = Company<ICollection<User>>.CreateMultiCompanyWith_ICollection();

        //Act

        var companyVM = _mapper.Map<ICollection<Company<ICollection<User>>>, ICollection<CompanyViewModel<ICollection<UserViewModel>>>>(europeCompanies, 2);

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
                Assert.Equal(companyVMItem.Description, europeCompany.Description);
                Assert.NotNull(companyVMItem.Director);
                Assert.Equal(companyVMItem.Director.Fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.Employees);
                Assert.Equal(companyVMItem.Employees.Count, europeCompany.Employees.Count);

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.Employees.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.Fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_IEnumerable()
    {
        //Arrange

        var europeCompanies = Company<IEnumerable<User>>.CreateMultiCompanyWith_IEnumerable();

        //Act

        var companyVM = _mapper.Map<IEnumerable<Company<IEnumerable<User>>>, IEnumerable<CompanyViewModel<IEnumerable<UserViewModel>>>>(europeCompanies, 2);

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
                Assert.Equal(companyVMItem.Description, europeCompany.Description);
                Assert.NotNull(companyVMItem.Director);
                Assert.Equal(companyVMItem.Director.Fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.Employees);
                Assert.Equal(companyVMItem.Employees.Count(), europeCompany.Employees.Count());

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.Employees.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.Fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_IReadonlyCollection()
    {
        //Arrange

        var europeCompanies = Company<IReadOnlyCollection<User>>.CreateMultiCompanyWith_IReadOnlyCollection();

        //Act

        var companyVM = _mapper.Map<IReadOnlyCollection<Company<IReadOnlyCollection<User>>>, IReadOnlyCollection<CompanyViewModel<IReadOnlyCollection<UserViewModel>>>>(europeCompanies, 2);

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
                Assert.Equal(companyVMItem.Description, europeCompany.Description);
                Assert.NotNull(companyVMItem.Director);
                Assert.Equal(companyVMItem.Director.Fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.Employees);
                Assert.Equal(companyVMItem.Employees.Count, europeCompany.Employees.Count);

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.Employees.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.Fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_IReadonlyList()
    {
        //Arrange

        var europeCompanies = Company<IReadOnlyList<User>>.CreateMultiCompanyWith_IReadOnlyList();

        //Act

        var companyVM = _mapper.Map<IReadOnlyList<Company<IReadOnlyList<User>>>, IReadOnlyList<CompanyViewModel<IReadOnlyList<UserViewModel>>>>(europeCompanies, 2);

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
                Assert.Equal(companyVMItem.Description, europeCompany.Description);
                Assert.NotNull(companyVMItem.Director);
                Assert.Equal(companyVMItem.Director.Fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.Employees);
                Assert.Equal(companyVMItem.Employees.Count, europeCompany.Employees.Count);

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.Employees.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.Fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_ReadonlyCollection()
    {
        //Arrange

        var europeCompanies = Company<ReadOnlyCollection<User>>.CreateMultiCompanyWith_ReadOnlyCollection();

        //Act

        var companyVM = _mapper.Map<ReadOnlyCollection<Company<ReadOnlyCollection<User>>>, ReadOnlyCollection<CompanyViewModel<ReadOnlyCollection<UserViewModel>>>>(europeCompanies, 2);

        //Assert

        Assert.NotNull(companyVM);
        Assert.Equal(companyVM.Count, europeCompanies.Count);

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

    [Fact]
    public void Collection_Start_Mapping_Depth_2_For_IQueryable()
    {
        //Arrange

        var europeCompanies = Company<IQueryable<User>>.CreateMultiCompanyWith_IQueryable();

        //Act

        var companyVM = _mapper.Map<IQueryable<Company<IQueryable<User>>>, IQueryable<CompanyViewModel<IQueryable<UserViewModel>>>>(europeCompanies, 2);

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
                Assert.Equal(companyVMItem.Description, europeCompany.Description);
                Assert.NotNull(companyVMItem.Director);
                Assert.Equal(companyVMItem.Director.Fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.Employees);
                Assert.Equal(companyVMItem.Employees.Count(), europeCompany.Employees.Count());

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.Employees.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.Fullname, europeEmployee.Fullname);
                    }
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2_Array()
    {
        //Arrange      
        var complexArrayWithCollection = new[] {
            Company<List<User>>.CreateMultiCompanyWith_List(),
            Company<List<User>>.CreateMultiCompanyWith_List() };

        //Act       
        var complexMapperWithCollection = _mapper.Map<List<Company<List<User>>>[], List<CompanyViewModel<List<UserViewModel>>>[]>
            (complexArrayWithCollection, 2);

        //Assert
        //
        Assert.NotNull(complexMapperWithCollection);
        for (int i = 0; i < complexMapperWithCollection.Length; i++)
        {
            Assert.Equal(complexMapperWithCollection[i].Count, complexArrayWithCollection[i].Count);
            for (int y = 0; y < complexMapperWithCollection[i].Count; y++)
            {
                Assert.Equal(complexMapperWithCollection[i][y].Description, complexArrayWithCollection[i][y].Description);
                Assert.NotNull(complexMapperWithCollection[i][y].Director);
                Assert.Equal(
                    complexMapperWithCollection[i][y].Director.Fullname,
                    complexArrayWithCollection[i][y].Director.Fullname);

                Assert.NotNull(complexMapperWithCollection[i][y].Employees);
                Assert.Equal(
                    complexMapperWithCollection[i][y].Employees.Count,
                    complexMapperWithCollection[i][y].Employees.Count);

                for (int j = 0; j < complexMapperWithCollection[i][y].Employees.Count; j++)
                {
                    Assert.Equal(
                        complexMapperWithCollection[i][y].Employees[j].Fullname,
                        complexArrayWithCollection[i][y].Employees[j].Fullname);
                }
            }
        }
    }

    [Fact]
    public void Collection_Start_Mapping_Depth_2_IQueryable_Extension()
    {
        //Arrange
        var europeCompanies = Company<IQueryable<User>>.CreateMultiCompanyWith_IQueryable();
        
        //Act
        var companyVM = europeCompanies.MapTo<CompanyViewModel<IQueryable<UserViewModel>>>(2, null);
        var newQuery = companyVM.FirstOrDefault(x => x.Director.Fullname == "Mason Berry");
        var secondQuery = companyVM
            .SelectMany(x => x.Employees)
            .Select(x => new
            {
                Greeting = $"{x.Fullname.First()}{x.Fullname.Last()}"
            });
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
                Assert.Equal(companyVMItem.Description, europeCompany.Description);
                Assert.NotNull(companyVMItem.Director);
                Assert.Equal(companyVMItem.Director.Fullname, europeCompany.Director.Fullname);
                Assert.NotNull(companyVMItem.Employees);
                Assert.Equal(companyVMItem.Employees.Count(), europeCompany.Employees.Count());

                using (var europeEmployeesEnumerator = europeCompany.Employees.GetEnumerator())
                using (var companyVMEmployeesEnumerator = companyVMItem.Employees.GetEnumerator())
                {
                    while (europeEmployeesEnumerator.MoveNext() && companyVMEmployeesEnumerator.MoveNext())
                    {
                        var europeEmployee = europeEmployeesEnumerator.Current;
                        var companyVMEmployee = companyVMEmployeesEnumerator.Current;

                        Assert.Equal(companyVMEmployee.Fullname, europeEmployee.Fullname);
                    }
                }
            }
        }

        Assert.Equal(companyVM.Count(), europeCompanies.Count());
        Assert.NotNull(newQuery);
        Assert.True(secondQuery.Any(x => x.Greeting == "Je"));
    }

}
