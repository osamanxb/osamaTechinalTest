/// Question 1 Without using any kind of .Sort or OrderBy Method or touching the constructor re-arrange the Numbers list into numerical order
/// Hint: I'm looking for loops

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
	public class Question1
	{
		public List<int> Numbers { get; set; }
		//wrong constructor name. it should be Question1
		public Question14()
		{
			Numbers = new List<int>()
			{
				1,9,32,5,2,6,4,2,7
			};
		}

		public void Answer()
		{
			int n = Numbers.Count;
			for (int i = 0; i < n - 1; i++)
			{
				for (int j = 0; j < n - i - 1; j++)
				{
					if (Numbers[j] > Numbers[j + 1])
					{
						SwapWithNext(j);
					}
				}
			}

			// Print the sorted Numbers list
			Console.WriteLine("Sorted Numbers:");
			foreach (int num in Numbers)
			{
				Console.Write(num + " ");
			}
		}
		//Using bubble sort
		public void SwapWithNext(int j)
		{

			int temp = Numbers[j];
			Numbers[j] = Numbers[j + 1];
			Numbers[j + 1] = temp;
		}
	}
}
