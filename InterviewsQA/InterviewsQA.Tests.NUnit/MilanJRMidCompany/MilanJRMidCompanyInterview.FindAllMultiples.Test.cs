using InterviewsQA.Core.MilanJRMidCompany;

namespace InterviewsQA.Tests.NUnit.MilanJRMidCompany;

public partial class MilanJRMidCompanyInterviewTest
{
    [Test]
    public void FindAllMultiples_WhenEmptySerieIsPassed_ThenReturnsEmptyCollections()
    {
        IEnumerable<int> input = [];
        IEnumerable<int> expectedMulOf4 = [];
        IEnumerable<int> expectedMulOf9 = [];
        IEnumerable<int> expectedMulOf4And9 = [];
        var (mulOf4, mulOf9, mulOf4And9) = new MilanJRMidCompanyInterview.Answer().FindAllMultiples(input);
        Assert.Multiple(() =>
        {
            Assert.That(mulOf4.SequenceEqual(expectedMulOf4), Is.True);
            Assert.That(mulOf9.SequenceEqual(expectedMulOf9), Is.True);
            Assert.That(mulOf4And9.SequenceEqual(expectedMulOf4And9), Is.True);
        });
    }

    [Test]
    public void FindAllMultiples_WhenMulOf4OnlyArePassed_ThenReturnsOnlyMulOf4()
    {
        IEnumerable<int> input = [4,8,16];
        IEnumerable<int> expectedMulOf4 = [4,8,16];
        IEnumerable<int> expectedMulOf9 = [];
        IEnumerable<int> expectedMulOf4And9 = [];
        var (mulOf4, mulOf9, mulOf4And9) = new MilanJRMidCompanyInterview.Answer().FindAllMultiples(input);
        Assert.Multiple(() =>
        {
            Assert.That(mulOf4.SequenceEqual(expectedMulOf4), Is.True);
            Assert.That(mulOf9.SequenceEqual(expectedMulOf9), Is.True);
            Assert.That(mulOf4And9.SequenceEqual(expectedMulOf4And9), Is.True);
        });
    }

    [Test]
    public void FindAllMultiples_WhenMulOf9OnlyArePassed_ThenReturnsOnlyMulOf9()
    {
        IEnumerable<int> input = [9,18];
        IEnumerable<int> expectedMulOf4 = [];
        IEnumerable<int> expectedMulOf9 = [9,18];
        IEnumerable<int> expectedMulOf4And9 = [];
        var (mulOf4, mulOf9, mulOf4And9) = new MilanJRMidCompanyInterview.Answer().FindAllMultiples(input);
        Assert.Multiple(() =>
        {
            Assert.That(mulOf4.SequenceEqual(expectedMulOf4), Is.True);
            Assert.That(mulOf9.SequenceEqual(expectedMulOf9), Is.True);
            Assert.That(mulOf4And9.SequenceEqual(expectedMulOf4And9), Is.True);
        });
    }

    [Test]
    public void FindAllMultiples_WhenMulOf4And9ArePassed_ThenReturns4And9()
    {
        IEnumerable<int> input = [36,72];
        IEnumerable<int> expectedMulOf4 = [36,72];
        IEnumerable<int> expectedMulOf9 = [36,72];
        IEnumerable<int> expectedMulOf4And9 = [36,72];
        var (mulOf4, mulOf9, mulOf4And9) = new MilanJRMidCompanyInterview.Answer().FindAllMultiples(input);
        Assert.Multiple(() =>
        {
            Assert.That(mulOf4.SequenceEqual(expectedMulOf4), Is.True);
            Assert.That(mulOf9.SequenceEqual(expectedMulOf9), Is.True);
            Assert.That(mulOf4And9.SequenceEqual(expectedMulOf4And9), Is.True);
        });
    }

    [Test]
    public void FindAllMultiples_WhenNotMulAndMulArePassed_ThenReturnsTheValuesSorted()
    {
        IEnumerable<int> input = [1,32,5,7,72,40,90];
        IEnumerable<int> expectedMulOf4 = [32,72,40];
        IEnumerable<int> expectedMulOf9 = [72,90];
        IEnumerable<int> expectedMulOf4And9 = [72];
        var (mulOf4, mulOf9, mulOf4And9) = new MilanJRMidCompanyInterview.Answer().FindAllMultiples(input);
        Assert.Multiple(() =>
        {
            Assert.That(mulOf4.SequenceEqual(expectedMulOf4), Is.True);
            Assert.That(mulOf9.SequenceEqual(expectedMulOf9), Is.True);
            Assert.That(mulOf4And9.SequenceEqual(expectedMulOf4And9), Is.True);
        });
    }

}