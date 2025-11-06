using InterviewsQA.Core.AmericanCompany;

namespace InterviewsQA.Tests.NUnit.AmericanCompany;

internal partial class AmericanCompanyInterviewTest
{
    /**
     * [][]
     * [][]
     * [][]
     * [][]
     * [][]
     * */
    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereIsNoOccupiedDesks_ThenReturns10()
    {
        int[] arr = [10];
        const long expected = 10;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }

    /**
     * [][]
     * [][X]
     * [][]
     * [][]
     * [][]
     * */

    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereIsOneBusyDeskOnRight_ThenReturns8()
    {
        int[] arr = [10, 4];
        const long expected = 8;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }

    /**
     * [][]
     * [X][]
     * [][]
     * [][]
     * [][]
     * */
    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereIsOneBusyDeskOnLeft_ThenReturns8()
    {
        int[] arr = [10, 3];
        const long expected = 8;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }

    /**
     * [][]
     * [X][X]
     * [][]
     * [][]
     * [][]
     * */
    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereAreMultipleBusyDesktopsOnSameLine_ThenReturns8()
    {
        int[] arr = [10, 3, 4];
        const long expected = 8;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }

    /**
     * [][]
     * [X][]
     * [][X]
     * [X][]
     * [][]
     * */
    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereAreMultipleBusyDesktopsOnMultipleContigousLines_ThenReturns4()
    {
        int[] arr = [10, 3, 6, 7];
        const long expected = 4;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }

    /**
     * [][]
     * [X][]
     * [X][X]
     * [][X]
     * [X][]
     * [][]
     * [][X]
     * */
    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereIsAComplexScheme_ThenReturns4()
    {
        int[] arr = [14, 3, 5, 6, 8, 9, 14];
        const long expected = 4;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }

    /**
     * [][]
     * [X][]
     * [][]
     * [][X]
     * [][]
     * */
    [Test]
    public void OptimizedAnswer_SeatingStudents_WhenThereAreMultipleBusyDesktopsOnMultipleNonContigousLines_ThenReturns8()
    {
        int[] arr = [10, 3, 8];
        const long expected = 6;

        var answer = new AmericanCompanyInterview.OptimizedAnswer();
        long result = answer.SeatingStudents(arr);

        Assert.That(result, Is.EqualTo(expected));


    }



}

