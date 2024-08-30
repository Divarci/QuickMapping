using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Extensions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests
{
    public class Experimental
    {
        private readonly IQuickMapper _mapper;

        public Experimental() =>
            _mapper = new QuickMapper();

        [Fact]
        public void PrirmitiveCollectonMap()
        {
            //Arrange
            int[] testArray = [1, 2, 3, 4];
            User[] testARray2 = [User.CreateSingleUser("Cenk"), User.CreateSingleUser("Mahir")];
            User[] testARray3 = [User.CreateSingleUser("maho"), User.CreateSingleUser("cano")];
            List<User[]> hobaa = [testARray2, testARray3];
            

            //List<int[]> arrayList = [testArray, testArray2, testArray3];

            //Act

            //var mappedObject = _mapper.Map<List<int[]>, List<int[]>>(arrayList, 1);

            var test1 = _mapper.Map<int[], int[]>(testArray, 2);
            var test2 = _mapper.Map<User[], UserViewModel[]>(testARray2, 2);
            var test3 = _mapper.Map<List<User[]>, List<UserViewModel[]>>(hobaa, 3);


        }

    }
}
