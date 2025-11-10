using InterviewsQA.Core.MilanJRMidCompany;

namespace InterviewsQA.Tests.NUnit.MilanJRMidCompany;

internal partial class MilanJRMidCompanyInterviewTest
{
    [Test]
    public void CountHappyDogs_WhenNotEvenMinStackesAreProvided_ThenReturns0()
    {
        int mockN = 10;
        int mockAvailableSteaks = 8;
        int expected = 0;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountHappyDogs_WhenBarelyJustMinStakesAreProvided_ThenReturns0()
    {
        int mockN = 10;
        int mockAvailableSteaks = 11;
        int expected = 0;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountHappyDogs_WhenExactlyPoisonCountExceedingStakesAreProvided_ThenReturns0()
    {
        int mockN = 10;
        int mockAvailableSteaks = 14;
        int expected = 0;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void CountHappyDogs_WhenExactlyPoisonCountStakesAreProvided_ThenReturns0()
    {
        int mockN = 10;
        int mockAvailableSteaks = 4;
        int expected = 0;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CountHappyDogs_WhenTooManyStakesAreProvided_ThenReturns10()
    {
        int mockN = 10;
        int mockAvailableSteaks =100;
        int expected = 10;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void CountHappyDogs_WhenReasonablyNumberOfStakesAreProvided_ThenReturns4()
    {
        int mockN = 10;
        int mockAvailableSteaks = 33;
        int expected = 3;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }



    [Test]
    public void CountHappyDogs_WhenNumberOfStakesThatLeadsToAPoisonusAmountOnTheLastDogAreProvided_ThenReturns4()
    {
        int mockN = 10;
        int mockAvailableSteaks = 34;
        int expected = 2;

        var result = new MilanJRMidCompanyInterview.Answer().CountHappyDogs(mockN, mockAvailableSteaks);

        Assert.That(result, Is.EqualTo(expected));
    }
}