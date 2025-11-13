namespace InterviewsQA.Core.MilanJRMidFSCompany;

internal class MilanJRMidFSCompanyInterview
{
    public interface IQuestionSolution
    {

        /// <summary>
        /// Implement a quicksort algorithm that sort the input array in ascending order.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>sorted arr in ascending order</returns>
        public int[] QuickSort(int[] arr);

        /// <summary>
        /// An hiker tracks his steps during his hike: D-downhill, U-uphill.
        /// Hikes always starts and ends at sea level, and each step up or down represents a  unit change in altitude.
        /// A mountain is a sequence of consecutive steps above sea level.
        /// A valley is a sequence of consecutive steps below sea level.
        /// Given the sequence of up and down steps during a hike, find and print the number of valleys walked through. 
        /// </summary>
        /// <param name="track"></param>
        /// <returns>The number of valleys encountered</returns>
        public int CountValleys(string track);
    }

    internal class Answer : IQuestionSolution
    {
        private static readonly Dictionary<char, int> _stepIncrement = new() {
            { 'D', -1},
            { 'U', 1}
        };

        public int CountValleys(string track)
        {
            const int seaLevel = 0;
            int numOfValleys = 0;
            int currHeight = seaLevel;

            if (string.IsNullOrEmpty(track)) return currHeight;

            foreach(char step in track) {

                int inc = _stepIncrement[step];

                bool currentlyOnAMountain = currHeight > 0;
                currHeight += inc;
                if (currHeight == 0 && !currentlyOnAMountain) numOfValleys++;

            }

            return numOfValleys;

        }

        public int[] QuickSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1) return arr;

            int pivot = arr[0];
            List<int> littleOnes = [];
            List<int> greatest = [];
            for (int i = 1; i < n; i++) {
                if (arr[i] < pivot) littleOnes.Add(arr[i]);
                else greatest.Add(arr[i]);
            }

            int[] before = QuickSort([.. littleOnes]);
            int[] after = QuickSort([.. greatest]);

            int[] result = new int[n];
            Array.Copy(before, result, before.Length);
            result[before.Length] = pivot;
            Array.Copy(after, 0, result, before.Length+1, after.Length);
            return result;
        }

    }
}