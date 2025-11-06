using System.Collections;

namespace InterviewsQA.Core.AmericanCompany;

internal static class AmericanCompanyInterview
{

    public interface IQuestionSolution
    {

        /// <summary>
        /// Have the function SeatingStudents(arr) read the array of integers stored in arr which will be in the following format: [K, r1, r2, r3, ...] 
        /// where K represents the number of desks in a classroom, and the rest of the integers in the array will be in sorted order and will represent 
        /// the desks that are already occupied. All of the desks will be arranged in 2 columns, where desk #1 is at the top left, desk #2 is at the top 
        /// right, desk #3 is below #1, desk #4 is below #2, etc. Your program should return the number of ways 2 students can be seated next to each other.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public long SeatingStudents(int[] arr);
    }

    internal class FastApproachAnswer : IQuestionSolution
    {
        public long SeatingStudents(int[] arr)
        {
            int k = arr[0];
            BitArray isBusy = new(k, false);
            for (int i = 1; i < arr.Length; i++)
            {
                int index = arr[i] - 1;
                isBusy[index] = true;
            }

            long result = 0;
            for (int i = 0; i < isBusy.Length; i += 2)
            {
                result += !isBusy[i] && !isBusy[i + 1] ? 2 : 0;
            }
            return result;
        }
    }

    internal class OptimizedAnswer : IQuestionSolution
    {

        public long SeatingStudents(int[] arr)
        {
            if (arr.Length < 1) throw new ArgumentException("Invalid input.");

            int k = arr[0];
            if (k % 2 != 0) throw new ArgumentException("Invalid input.");

            int currLineOfDesks = 0;
            int currBusyDeskIndex = 1;
            long result = 0;
            int numOfDesksLines = k / 2;
            while (currLineOfDesks < numOfDesksLines)
            {

                bool thereAreSomeBusyDesksDataRemaining = currBusyDeskIndex < arr.Length;
                if (!thereAreSomeBusyDesksDataRemaining)
                {

                    int remainigLineOfDesks = numOfDesksLines - currLineOfDesks;
                    result += 2 * remainigLineOfDesks;
                    break;

                }

                int currBusyDeskValue = arr[currBusyDeskIndex] - 1;
                bool isLeftColumn = currBusyDeskValue % 2 == 0;
                int currBusyDeskLine = isLeftColumn ? currBusyDeskValue / 2 : (currBusyDeskValue - 1) / 2;

                bool currLineIsBusy = currBusyDeskLine == currLineOfDesks;
                if (currLineIsBusy)
                {

                    currBusyDeskIndex++;
                    if (isLeftColumn && currBusyDeskIndex < arr.Length)
                    {

                        int newBusyDeskValue = arr[currBusyDeskIndex] - 1;
                        bool isANewLeftColumn = newBusyDeskValue % 2 == 0;
                        if (isANewLeftColumn)
                        {
                            currLineOfDesks++;
                            continue;
                        }

                        int newBusyLine = (newBusyDeskValue - 1) / 2;
                        bool stillReferToCurrentLine = newBusyLine == currLineOfDesks;
                        if (!stillReferToCurrentLine)
                        {

                            currLineOfDesks++;
                            continue;

                        }

                        currBusyDeskIndex++;
                    }



                    currLineOfDesks++;
                    continue;

                }



                result += 2;
                currLineOfDesks++;

            }



            return result;



        }
    }
}