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
            int[] testArray2 = [5, 6, 7, 8];
            int[] testArray3 = [9, 0, 1, 2];

            List<int[]> arrayList = [testArray, testArray2, testArray3];

            //Act

            var mappedObject = _mapper.Map<List<int[]>, List<int[]>>(arrayList, 1);
        }

    }
}
