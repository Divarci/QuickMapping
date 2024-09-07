
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
[ShortRunJob]
public class MyBenchmark
{
    private IQuickMapper _qMapper;
    private List<User> _members;

    [GlobalSetup]
    public void Setup()
    {
        _members = User.CreateMultiUserWith_List();
        _qMapper = new QuickMapper();
    }

    [Benchmark]
    public void Quickmapper()
    {
        var mappedObjectByQM = _qMapper.Map<List<User>, List<UserViewModel>>(_members, 2);
    }
}