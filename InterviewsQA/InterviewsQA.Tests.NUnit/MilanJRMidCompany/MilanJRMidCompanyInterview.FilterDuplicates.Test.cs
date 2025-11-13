using InterviewsQA.Core.MilanJRMidCompany;

namespace InterviewsQA.Tests.NUnit.MilanJRMidCompany;

public partial class MilanJRMidCompanyInterviewTest
{
    [Test]
    public void FilterDuplicates_WhenEmptyArrayIsPassed_ThenReturnsEmptyArray()
    {
        int[] input = [];
        int[] expected = [];

        var result = new MilanJRMidCompanyInterview.Answer().FilterDuplicates(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }

    [Test]
    public void FilterDuplicates_WhenSimpleArrayIsPassed_ThenReturnsSortedArray()
    {
        int[] input = [1,2,3,4,1,2,3,4];
        int[] expected = [1,2,3,4];

        var result = new MilanJRMidCompanyInterview.Answer().FilterDuplicates(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }


    [Test]
    public void FilterDuplicates_WhenAnArrayWithMultipleDuplicatesIsPassed_ThenReturnsSortedArray()
    {
        int[] input = [5,5,5,5,5,5,5,5,5,1,2,5,6,3,2,2,6,8,3,3,33,1];
        int[] expected = [5,1,2,6,3,8,33];

        var result = new MilanJRMidCompanyInterview.Answer().FilterDuplicates(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }
}