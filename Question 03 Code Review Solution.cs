using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace InterviewQuestions
{
	// Added an interface to define the contract for answer handling (Open close principle)
	public interface IAnswerHandler
	{
		string GetDefaultAnswer(List<string> availableAnswers);
		void DisplayAnswersToUser();
	}

	public class Question3 : IAnswerHandler // Implementing the interface
	{
		// Changed to readonly to protect against modification
		public readonly string defaultAnswer;

		// Corrected property name from AvaliableAnswers to AvailableAnswers
		private List<string> AvailableAnswers { get; set; }

		// Corrected constructor name and parameter name
		public Question3(List<string> availableAnswers)
		{
			AvailableAnswers = availableAnswers; // Initialize the AvailableAnswers property
			defaultAnswer = GetDefaultAnswer(availableAnswers);
		}

		// now it does not violate the Open Closed Principle as it is part of the interface
		// Corrected parameter name to availableAnswers
		public string GetDefaultAnswer(List<string> availableAnswers)
		{
			// Validate input explicitly by checking if its count is 0 or if multiple answers exist.
			if (availableAnswers == null || availableAnswers.Count == 0)
			{
				// Corrected typo from "avaliable" to "available"
				return "There are no answers available";
			}

			if (availableAnswers.Count > 1)
			{
				return "There are more than 1 answer to this question";
			}

			// Safely return the single available answer as we already handled null and multiple answers cases
			return availableAnswers.Single();
		}

		// Renamed the method to DisplayAvailableAnswersToUser for clarity
		public void DisplayAvailableAnswersToUser()
		{

			// Check if AvailableAnswers is not null or empty before processing
			if (AvailableAnswers == null || !AvailableAnswers.Any())
			{
				Console.WriteLine("No answers to display.");
				return; // Exit early if no answers are available
			}

			// Using a for loop to avoid IndexOf() issues with duplicate values (If in any case we would have any)
			for (int i = 0; i < AvailableAnswers.Count; i++)
			{
				// Using string interpolation for clarity
				Console.WriteLine($"{i + 1} - {AvailableAnswers[i]}");
			}
		}
	}
}
