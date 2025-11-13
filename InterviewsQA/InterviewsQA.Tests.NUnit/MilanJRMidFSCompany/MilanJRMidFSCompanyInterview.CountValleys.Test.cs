using InterviewsQA.Core.MilanJRMidFSCompany;

namespace InterviewsQA.Tests.NUnit.MilanJRMidFSCompany;

public partial class MilanJRMidFSCompanyInterviewTest
{
    [Test]
    public void CountValleys_WhenTarckIsEmpty_ThenReturns0()
    {
        string track = String.Empty;
        int expected = 0;

        var result = new MilanJRMidFSCompanyInterview.Answer().CountValleys(track);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountValleys_WhenTrackDoesntontainsValleys_ThenReturns0()
    {
        string track = "UUUUDDDD";
        int expected = 0;

        var result = new MilanJRMidFSCompanyInterview.Answer().CountValleys(track);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountValleys_WhenTrackContainsOnlySingleValleys_ThenReturns4()
    {
        string track = "DUDUDUDU";
        int expected = 4;

        var result = new MilanJRMidFSCompanyInterview.Answer().CountValleys(track);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountValleys_WhenTrackContainsOneValleyAndOneMountain_ThenReturns1()
    {
        string track = "DDUUUUDD";
        int expected = 1;

        var result = new MilanJRMidFSCompanyInterview.Answer().CountValleys(track);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountValleys_WhenTrackContainsComplexHike_ThenReturns2()
    {
        string track = "UDDDUDUUUUDDUDDDUDUDUUUUUDD";
        int expected = 2;

        var result = new MilanJRMidFSCompanyInterview.Answer().CountValleys(track);

        Assert.That(result, Is.EqualTo(expected));
    }
}