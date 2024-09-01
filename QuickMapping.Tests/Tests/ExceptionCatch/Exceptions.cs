using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Exceptions;
using QuickMapping.Tests.Entities;
using QuickMapping.Tests.Tests.DefaultOptions.Models;
using System.Collections.ObjectModel;

namespace QuickMapping.Tests.Tests.ExceptionCatch;
public class Exceptions
{
    private readonly IQuickMapper _mapper;

    public Exceptions() =>
       _mapper = new QuickMapper();

    [Fact]
    public void Exception_Catch()
    {
        Assert.Throws<MapperException>(() =>
        _mapper.Map<List<User>, IList<UserViewModel>>(
            User.CreateMultiUserWith_List(), 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<IEnumerable<User>, IList<UserViewModel>>(
            User.CreateMultiUserWith_List(), 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<IEnumerable<User>, IList<UserViewModel>[]>(
            User.CreateMultiUserWith_List(), 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<Collection<User>, Collection<UserViewModel>[]>(
            User.CreateMultiUserWith_Collection(), 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<IList<User>[], IList<UserViewModel>>(
           [User.CreateMultiUserWith_IList(),
           User.CreateMultiUserWith_IList()], 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<IReadOnlyCollection<User>, IQueryable<UserViewModel>>(
            User.CreateMultiUserWith_List(), 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<int[], string[]>(
            [1, 2, 3], 2));

        Assert.Throws<MapperException>(() =>
        _mapper.Map<List<int[]>, List<string[]>>(
            [[1, 2, 3], [5, 6, 7]], 2));
    }
}
