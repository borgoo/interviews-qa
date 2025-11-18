using InterviewsQA.Core.Shared;
using System.Text;
using static InterviewsQA.Core.MilanJRMidCompany.MilanJRMidCompanyInterview.IQuestionSolution;

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

        /// <summary>
        /// Given a series of numbers, return:
        /// * All the multiples of 4
        /// * All the multiples of 9
        /// * All the multiples of 4 and 9
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public (IEnumerable<int> mulOf4, IEnumerable<int> mulOf9, IEnumerable<int> mulOf4And9) FindAllMultiples(IEnumerable<int> nums);


        /// <summary>
        /// Create a zoo.
        /// The zoo will welcome various animals. The Zoo will have the following characteristics:
        /// * Will be able to host various kinds of animals: giraffes, elephants and tigers.
        /// * Will have an Assign function that will allow assigning an animal to a cell in the zoo.The animal will be assigned to the first available cell.
        /// * Will have an Unassign function that will allow unassigning an animal from a specific position in the zoo (and returns the animal).
        /// * At any moment it will be able to print the current state of the zoo: for each cell (from 0 to the total number of cells) it will provide the animal type, the position index of the cell and the time of arrival of the animal.
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public IZoo CreateZoo(int capacity, IDateTimeProvider dateTimeProvider);

        public abstract record Animal();

        public interface IZoo
        {
            public int Capacity { get; init; }
            public void Assign(Animal animal);
            public Animal Unassign(int position);
            public string PrintState();

        }



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

        public (IEnumerable<int> mulOf4, IEnumerable<int> mulOf9, IEnumerable<int> mulOf4And9) FindAllMultiples(IEnumerable<int> nums)
        {
            List<int> mulOf4 = [];
            List<int> mulOf9 = [];
            List<int> mulOf4And9 = [];

            foreach (int num in nums)
            {
                if (num % 4 == 0) mulOf4.Add(num);
                if (num % 9 == 0) mulOf9.Add(num);
                if (num % 4 == 0 && num % 9 == 0) mulOf4And9.Add(num);
            }

            return (mulOf4, mulOf9, mulOf4And9);
        }


        public record Giraffe : Animal;
        public record Elephant : Animal;
        public record Tiger : Animal;


        public class Zoo : IZoo
        {
            const string _empty = "Empty";
            private readonly IDateTimeProvider _dateTimeProvider;
            public int Capacity { get; init; }
            private (Animal animal, TimeOnly arrivalTime)?[] _cells;
            private PriorityQueue<int, int> _availablePositions = new();


            public Zoo(int capacity, IDateTimeProvider dateTimeProvider)
            {
                if(capacity <= 0) throw new ArgumentException("Capacity must be greater than zero.");
                Capacity = capacity;
                _dateTimeProvider = dateTimeProvider;
                _cells = new (Animal animal, TimeOnly arrivalTime)?[capacity];
                for(int i = 0; i < capacity; i++)
                {
                    _availablePositions.Enqueue(i, i);
                }
            }

            public string PrintState()
            {
                StringBuilder result = new();
                for(int i = 0; i < Capacity; i++)
                {
                    StringBuilder sb = new();
                    sb.Append(i + ":");
                    if (_cells[i] is null) sb.Append($" {_empty}");
                    else
                    {
                        sb.Append(" " + _cells[i]!.Value.animal.GetType().Name);
                        sb.Append(", Arrival Time: " + _cells[i]!.Value.arrivalTime.ToString("HH:mm:ss"));
                    }
                    string tmp = sb.ToString();     
                    Console.WriteLine(tmp);
                    result.AppendLine(tmp);
                }
                return result.ToString();
            }

            public Animal Unassign(int position)
            {
                if(position < 0 || position >= Capacity || _cells[position] is null) throw new ArgumentException("Invalid position.");
                _availablePositions.Enqueue(position, position);
                return _cells[position]!.Value.animal;
            }

            void IZoo.Assign(Animal animal)
            {
                if (_availablePositions.Count == 0) throw new Exception("No available positions.");
                int position = _availablePositions.Dequeue();
                _cells[position] = (animal, TimeOnly.FromDateTime(_dateTimeProvider.Now));
            }
        }


        public IZoo CreateZoo(int capacity, IDateTimeProvider dateTimeProvider)
        {
            return new Zoo(capacity, dateTimeProvider);
        }
    }

}