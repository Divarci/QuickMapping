using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;

namespace QuickMapping.Tests.Tests.DefaultOptions.SingleStartDepthOne;
public class DefaultMappingForExistingSSD1
{
    private readonly IQuickMapper _mapper;

    public DefaultMappingForExistingSSD1() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Single_Start_Mapping_Depth_1()
    {
        //Arrange

        var newName = new UserViewModel { Fullname = "Jack Wilson" };
        var michael = User.CreateSingleUser("Michael Jordon");

        //Act 

        var jack = _mapper.Map(newName, michael, 1);

        //Assert

        Assert.NotNull(jack);
        Assert.Equal(jack.Fullname, newName.Fullname);
        Assert.Same(michael, jack);
    }
}
