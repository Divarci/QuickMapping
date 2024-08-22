namespace QuickMapping.Tests.Tests.CaseSensitive.Models;
public class CompanyViewModelWithLowerCase
{
    public string DESCRIPTION { get; set; } = null!;

    public UserViewModelWithLowerCase director { get; set; } = null!;
    public List<UserViewModelWithLowerCase> EmployeeS { get; set; } = null!;
}
