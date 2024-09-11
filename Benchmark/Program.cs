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
    private List<Company<List<User>>> multiList;
    private List<User> massive_singleList = new();
    private List<Company<List<User>>> massive_multiList = new();

    [GlobalSetup]
    public void Setup()
    {
        
        singleList = User.CreateMultiUserWith_List();

        multiList = Company<List<User>>.CreateMultiCompanyWith_List();

        for (int i = 0; i < 1000; i++)        
            massive_singleList.Add(User.CreateSingleUser("Test"));

        for (int i = 0; i < 1000; i++)
            massive_multiList.Add(Company<List<User>>.CreateSingleCompany("Test",ListType.List));

        _qMapper = new QuickMapper();
    }


    [Benchmark]
    public void SingleList() =>
       _qMapper.Map<List<User>, List<UserViewModel>>(singleList, 3);

    [Benchmark]
    public void MultiList() =>
        _qMapper.Map<List<Company<List<User>>>, List<UserViewModel>>(multiList, 3);

    [Benchmark]
    public void Massive_SingleList() =>
        _qMapper.Map<List<User>, List<UserViewModel>>(massive_singleList, 3);

    [Benchmark]
    public void Massive_MultiList() =>
        _qMapper.Map<List<Company<List<User>>>, List<UserViewModel>>(massive_multiList, 3);

   

}

