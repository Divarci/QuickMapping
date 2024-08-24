using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;

namespace QuickMapping.Tests.Tests.CaseSensitive.SingleStartDepthOne;
public class IsCaseSensitiveSSD1
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveSSD1() =>
         _mapper = new QuickMapper(new MappingOptions()
         {
             IsSensitiveCase = false
         });

    [Fact]
    public void Single_Start_Mapping_Depth_1_For_List()
    {
        //Arrange

        var michael = User.CreateSingleUser("Michael Jordon");

        //Act 

        var userVM = _mapper.Map<User, UserViewModelWithLowerCase>(michael, 1);

        //Assert

        Assert.NotNull(userVM);
        Assert.Equal(userVM.fullname, michael.Fullname);
    }

}
