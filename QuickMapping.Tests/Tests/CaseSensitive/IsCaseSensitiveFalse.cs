using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.CaseSensitive.Models;

namespace QuickMapping.Tests.Tests.CaseSensitive;
public class IsCaseSensitiveFalse
{
    private readonly IQuickMapper _mapper;

    public IsCaseSensitiveFalse() =>
        _mapper = new QuickMapper(new MappingOptions()
        {
            IsSensitiveCase = false
        });

    [Fact]
    public void Single_To_Single_Mapping_Depth_1_OptionCaseSensitive_False()
    {
        //Arrange

        var michael = new User(1, "Michael Jordon", 38);

        //Act 

        var userVM = _mapper.Map<User, UserViewModelWithLowerCase>(michael, 1);

        //Assert

        Assert.NotNull(userVM);
        Assert.Equal(userVM.fullname, michael.Fullname);
    }
}
