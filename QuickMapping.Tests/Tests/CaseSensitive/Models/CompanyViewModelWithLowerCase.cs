namespace QuickMapping.Tests.Tests.CaseSensitive.Models;
public class CompanyViewModelWithLowerCase<T>
{
    public string DESCRIPTION { get; set; } = null!;

    public UserViewModelWithLowerCase director { get; set; } = null!;
    public T EmployeeS { get; set; } = default!;
}
