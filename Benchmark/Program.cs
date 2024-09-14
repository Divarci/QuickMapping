using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;

BenchmarkSwitcher
    .FromAssembly(typeof(Program).Assembly)
    .Run(args);

[MemoryDiagnoser]
public class MyBenchmark
{
    private IQuickMapper _qMapper;
    private List<User> singleList;
    private IList<Company<IList<User>>> multiList;
    private List<User> massive_singleList = new();
    private List<Company<IList<User>>> massive_multiList = new List<Company<IList<User>>>();

    [GlobalSetup]
    public void Setup()
    {
        
        singleList = User.CreateMultiUserWith_List();

        multiList = Company<IList<User>>.CreateMultiCompanyWith_IList();

        for (int i = 0; i < 1000; i++)        
            massive_singleList.Add(User.CreateSingleUser("Test"));

        for (int i = 0; i < 1000; i++)
            massive_multiList.Add(Company<IList<User>>.CreateSingleCompany("Test",ListType.IList));
        massive_multiList.AsReadOnly();
        _qMapper = new QuickMapper();
    }


    [Benchmark]
    public void SingleList() =>
       _qMapper.Map<List<User>, List<UserViewModel>>(singleList, 3);

    [Benchmark]
    public void MultiList() =>
        _qMapper.Map<IList<Company<IList<User>>>, IList<UserViewModel>>(multiList, 3);

    [Benchmark]
    public void Massive_SingleList() =>
        _qMapper.Map<List<User>, List<UserViewModel>>(massive_singleList, 3);

    [Benchmark]
    public void Massive_MultiList() =>
        _qMapper.Map<IList<Company<IList<User>>>, IList<UserViewModel>>(massive_multiList, 3);

   

}

