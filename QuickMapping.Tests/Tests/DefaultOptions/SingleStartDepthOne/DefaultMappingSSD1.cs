using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;

namespace QuickMapping.Tests.Tests.DefaultOptions.SingleStartDepthOne;
public class DefaultMappingSSD1
{
    private readonly IQuickMapper _mapper;

    public DefaultMappingSSD1() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Single_Start_Mapping_Depth_1()
    {
        //Arrange

        var michael = User.CreateSingleUser("Michael Jordon");

        //Act 

        var userVM = _mapper.Map<User, UserViewModel>(michael, 1);

        //Assert

        Assert.NotNull(userVM);
        Assert.Equal(userVM.Fullname, michael.Fullname);
    }
}
