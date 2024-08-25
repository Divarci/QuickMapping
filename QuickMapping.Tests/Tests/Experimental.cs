using k8s.KubeConfigModels;
using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests
{
    public class Experimental
    {
        private readonly IQuickMapper _mapper;

        public Experimental()=>        
            _mapper = new QuickMapper();

        [Fact]
        public void PrirmitiveCollectonMap()
        {
            //Arrange
            var student = new Student()
            {
                Name = "Ali",
                Surname = "Yildiz",
                Number = 14,
                Lessons = ["Matematik", "Edebiyat"],
                Numbers = new List<int>() { 1, 3, 5 }.AsReadOnly(),
                Friends = [new() { Fullname ="Cenk"}, new() { Fullname="Berk"}]

            };

            //Act

            var dto = _mapper.Map<Student, StudentDto>(student, 3);
            var test = dto.Lessons.GetType().Name;
        }
        
        class Student
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Number { get; set; }
            public IReadOnlyCollection<string> Lessons { get; set; }
            public ReadOnlyCollection<int> Numbers { get; set; }
            public IList<UserViewModel> Friends { get; set; }
        }

        class StudentDto
        {
            public string Name { get; set; }
            public IReadOnlyCollection<string> Lessons { get; set; }
            public ReadOnlyCollection<int> Numbers { get; set; }
            public IList<UserViewModel> Friends { get; set; }
        }
    }
}
