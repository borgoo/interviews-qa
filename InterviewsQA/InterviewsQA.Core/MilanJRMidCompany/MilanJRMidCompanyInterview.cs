using System.Collections;

namespace InterviewsQA.Core.MilanJRMidCompany;

internal static class MilanJRMidCompanyInterview
{

    public interface IQuestionSolution
    {

        /// <summary>
        /// Remove all duplicates from the input. The result array should mantains the original order of the elements.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] FilterDuplicates(int[] arr);

        /// <summary>
        /// You need to feed your dogs.
        /// Each dog MUST receive at least 1 steak.
        /// You must assign all the steaks to the dogs if possible (no more than 8 steaks per dog).
        /// If any dog receives 0 steaks, return 0.
        /// A dog is considered happy if it receives exactly 8 steaks.
        /// A dog is poisoned if it receives exactly 4 steaks.
        /// You DO NOT want to poison your dogs because you are a good owner.
        /// What is the maximum number of happy dogs you can have?
        /// </summary>
        /// <param name="n">Number of dogs. 0 < n < 11</param>
        /// <param name="availableSteaks">Total number of available steaks.</param>
        /// <returns>Maximum number of happy dogs achievable</returns>
        public int CountHappyDogs(int n, int availableSteaks);
    }

    internal class Answer : IQuestionSolution
    {
        public int[] FilterDuplicates(int[] arr)
        {
            HashSet<int> seen = [];
            List<int> result = [];

            foreach (int v in arr)
            {
                if (seen.Contains(v)) continue;
                seen.Add(v);
                result.Add(v);
            }

            return [.. result];

        }

        public int CountHappyDogs(int n, int availableSteaks)
        {
            const int toBeHappy = 8;
            const int toBePoisoned = 4;
            const int minSteaks = 1;
            const int toBeAdded = toBeHappy - minSteaks;

            int oneSteakForeachDogAtLeast = n;
            availableSteaks -= oneSteakForeachDogAtLeast;

            if (availableSteaks < 0) return 0;


            int result = availableSteaks / toBeAdded;

            if (result >= n) return Math.Min(result, n);

            int lastDogReceiveNumOfSteaks = 1 + (availableSteaks  % toBeAdded);

            if (lastDogReceiveNumOfSteaks == toBePoisoned) return result - 1;

            return result;

        }


    }

}