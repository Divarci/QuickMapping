namespace QuickMapping.Tests.Tests.DefaultOptions.Models;
public class CompanyViewModel<T>
{
    public string Description { get; set; } = null!;

    public UserViewModel Director { get; set; } = null!;
    public T Employees { get; set; } = default!;

}
