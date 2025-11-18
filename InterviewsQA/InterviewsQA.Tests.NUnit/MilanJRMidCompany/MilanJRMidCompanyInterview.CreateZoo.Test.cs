using InterviewsQA.Core.MilanJRMidCompany;
using InterviewsQA.Core.Shared;
using static InterviewsQA.Core.MilanJRMidCompany.MilanJRMidCompanyInterview.Answer;

namespace InterviewsQA.Tests.NUnit.MilanJRMidCompany;

public partial class MilanJRMidCompanyInterviewTest
{
    private class MockDateTimeProvider : IDateTimeProvider
    {
        private Queue<DateTime> Queue { get; } = new(
        [
            new DateTime(2024, 1, 1, 0, 0, 0),
            new DateTime(2024, 1, 1, 1, 0, 0),
            new DateTime(2024, 1, 1, 2, 0, 0),
            new DateTime(2024, 1, 1, 3, 0, 0),
            new DateTime(2024, 1, 1, 4, 0, 0),
            new DateTime(2024, 1, 1, 5, 0, 0)
        ]);
        public DateTime Now => Queue.Dequeue();
    }

    private MockDateTimeProvider _mockedDateTimeProvider;
    [SetUp]
    public void Setup()
    {
        _mockedDateTimeProvider = new();
    }

    [Test]
    public void CreateZoo_WhenNoOperationsAreMade_ThenReturnEmptyCellsOnly()
    {
        const int capacity = 3;
        string expected = $"0: Empty{Environment.NewLine}1: Empty{Environment.NewLine}2: Empty{Environment.NewLine}";

        var zoo = new MilanJRMidCompanyInterview.Answer().CreateZoo(capacity, _mockedDateTimeProvider);
        var result = zoo.PrintState();

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void CreateZoo_WhenNegativeCapacity_ThenThrowArgumentException()
    {
        const int capacity = -1;
        Assert.Catch<ArgumentException>(() => new MilanJRMidCompanyInterview.Answer().CreateZoo(capacity, _mockedDateTimeProvider));

    }

    [Test]
    public void CreateZoo_WhenTooManyAssignAreDone_ThenThrowException()
    {
        const int capacity = 1;
        var zoo = new MilanJRMidCompanyInterview.Answer().CreateZoo(capacity, _mockedDateTimeProvider);
        zoo.Assign(new Giraffe());

        Assert.Catch<Exception>(() => zoo.Assign(new Tiger()));

    }

    [Test]
    public void CreateZoo_WhenNoAssignedCellIsTryingToBeFreed_ThenThrowArgumentException()
    {
        const int capacity = 1;
        var zoo = new MilanJRMidCompanyInterview.Answer().CreateZoo(capacity, _mockedDateTimeProvider);        

        Assert.Catch<ArgumentException>(() => zoo.Unassign(0));

    }

    [Test]
    public void CreateZoo_WhenComplexOperationsAreDone_ThenReturnsCorrectStatus()
    {
        const int capacity = 4;
        string expected = $"0: Giraffe, Arrival Time: 00:00:00{Environment.NewLine}1: Tiger, Arrival Time: 03:00:00{Environment.NewLine}2: Elephant, Arrival Time: 04:00:00{Environment.NewLine}3: Empty{Environment.NewLine}";
        
        var zoo = new MilanJRMidCompanyInterview.Answer().CreateZoo(capacity, _mockedDateTimeProvider);
        zoo.Assign(new Giraffe());
        zoo.Assign(new Elephant());
        zoo.Assign(new Tiger());
        zoo.Unassign(1);
        zoo.Assign(new Tiger());
        zoo.Unassign(2);
        zoo.Assign(new Elephant());

        string result = zoo.PrintState();

        Assert.That(result, Is.EqualTo(expected));

    }
}