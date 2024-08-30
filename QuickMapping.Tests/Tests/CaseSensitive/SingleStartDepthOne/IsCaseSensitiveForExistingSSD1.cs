using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;
using QuickMapping.Tests.Tests.DefaultOptions.Models;

namespace QuickMapping.Tests.Tests.CaseSensitive.SingleStartDepthOne;
public class IsCaseSensitiveForExistingSSD1
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveForExistingSSD1() =>
         _mapper = new QuickMapper(new MappingOptions()
         {
             IsSensitiveCase = false
         });

    [Fact]
    public void Single_Start_Mapping_Depth_1()
    {
        //Arrange

        var newName = new UserViewModelWithLowerCase { fullname = "Jack Wilson" };
        var michael = User.CreateSingleUser("Michael Jordon");

        //Act 

        var jack = _mapper.Map(newName, michael, 1);

        //Assert

        Assert.NotNull(jack);
        Assert.Equal(jack.Fullname, newName.fullname);
        Assert.Same(michael, jack);
    }
}
