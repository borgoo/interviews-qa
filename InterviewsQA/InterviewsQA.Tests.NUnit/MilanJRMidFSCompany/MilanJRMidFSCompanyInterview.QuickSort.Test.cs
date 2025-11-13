using InterviewsQA.Core.MilanJRMidFSCompany;

namespace InterviewsQA.Tests.NUnit.MilanJRMidFSCompany;

public partial class MilanJRMidFSCompanyInterviewTest
{
    [Test]
    public void QuickSort_WhenEmptyArrayIsPassed_ThenReturnsEmptyArray()
    {
        int[] input = [];
        int[] expected = [];

        var result = new MilanJRMidFSCompanyInterview.Answer().QuickSort(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }

    [Test]
    public void QuickSort_WhenArrayWithDuplicateValuesIsPassed_ThenReturnsSortedArray()
    {
        int[] input = [1,2,3,4,1,2,3,4];
        int[] expected = [1,1,2,2,3,3,4,4];

        var result = new MilanJRMidFSCompanyInterview.Answer().QuickSort(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }


    [Test]
    public void QuickSort_WhenAnArrayWithOneSingleValueIsPassed_ThenReturnsSortedArray()
    {
        int[] input = [100];
        int[] expected = [100];

        var result = new MilanJRMidFSCompanyInterview.Answer().QuickSort(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }

    [Test]
    public void QuickSort_WhenAlreadySortedArrayIsPassed_ThenReturnsSortedArray()
    {
        int[] input = [1,2,3,4,5,6,7];
        int[] expected = [1,2,3,4,5,6,7];

        var result = new MilanJRMidFSCompanyInterview.Answer().QuickSort(input);

        Assert.That(result.SequenceEqual(expected), Is.True);
    }

    [TestCase(new int[] { 8,100,200,1,2 }, new int[] { 1,2,8,100,200 })]
    [TestCase(new int[] { 7, 5, 4, 2, 6, 8, 8 }, new int[] { 2,4,5,6,7,8,8 })]
    public void QuickSort_WhenNotAlreadySortedArrayIsPassed_ThenReturnsSortedArray(int[] input, int[] expected) {
        
        var result = new MilanJRMidFSCompanyInterview.Answer().QuickSort(input);

        Assert.That(result.SequenceEqual(expected), Is.True);

    }

 
}