// Question 3 - Code review the code below. Write any comments / suggestions in code comments next to the affected line.
// if you feel like your comment can be backed up with evidence: eg 'this breaks the open closed principle' - please point to any evidence via MSDN, 
// blogposts etc


//Start code review HERE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace InterviewQuestions
{
	public class Question3
	{
		// Should be marked as readonly if it is initialized in the constructor and not modified elsewhere
		public string defaultAnswer;
		//typo=> It should be "AvailableAnswers"
		//"AvaliableAnswers" is not initialized anywhere
		private List<string> AvaliableAnswers { get; set; }

		//wrong constructor name. it should be Question3
		//typo => parameter name should be "availableAnswers"
		public Question7(List<string> avaliableAnswers)
		{
			defaultAnswer = GetDefaultAnswer(avaliableAnswers);
		}

		/* If we are going to have other ways to get DefaultAnswer in future, we will need to modify this class which violates "Open Closed Pinciples"
           https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp#the-open-closed-principle
        */

		//typo => parameter name should be "availableAnswers"
		public string GetDefaultAnswer(List<string> avaliableAnswers)
		{
			try
			{
				//we shouldn't have more than one avaliable answer NORMALLY, so lets try and get one.
				// Instead of relying on catching exceptions due to unexpected input, validate the input explicitly by checking if its count is 0 or if multiple answers exist.
				return avaliableAnswers.Single();
			}
			catch (Exception e)
			{
				//Using exeption for control flow is less clear
				if (avaliableAnswers.Count == 0)
				{
					//typo => "avaliable" should be "available
					//returning string is not a good practice. It should be handled by the caller
					return "There are no answers avaliable";
				}
				else
				{
					// there were multiple answers. Inform the user
					return "There are more than 1 answers to this question";
				}
			}
		}
		// Rename the method to something more descriptive, like "DisplayAvailableAnswersToUser", to clarify whether it displays the default answer or the available ones.
		public void DisplayAnswersToUser()
		{
			foreach (var answer in AvaliableAnswers)
			{
				// IndexOf() may cause issues with duplicate values. Consider using an incremented counter variable or a standard for loop to track the position.
				var currentItemPosition = AvaliableAnswers.IndexOf(answer) + 1;
				Console.WriteLine(currentItemPosition + " - " + answer);
			}
		}
	}
}
