namespace QuickMapping.Tests.Tests.DefaultOptions.Models;
public class CompanyViewModel
{
    public string Description { get; set; } = null!;

    public UserViewModel Director { get; set; } = null!;
    public List<UserViewModel> Employees { get; set; } = null!;

}
