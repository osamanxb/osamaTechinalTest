/// Question2 Refactor the code below so that the nested if statements are reduced as much as possible.
/// Attempt to failfast as much as possible, so that all checks do not need to run if any validation has failed.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
	public class Question2
	{
		private ISuccessChecker _initializationChecker;
		private ISuccessChecker _nullChecker;
		private ISuccessChecker _dataEntryValidation;
		private ISuccessChecker _databaseValiator;

		private Question4(ISuccessChecker initializationChecker, ISuccessChecker nullChecker,
			ISuccessChecker dataEntryChecker, ISuccessChecker databaseValidator)
		{
			_initializationChecker = initializationChecker;
			_nullChecker = nullChecker;
			_dataEntryValidation = dataEntryChecker;
			_databaseValiator = databaseValidator;
		}

		//Used fail first approach to reduce nested if statements and it will return as soon as it fails
		public string GetResult()
		{
			string resultToReturnToUser = string.Empty;
			if (!_initializationChecker.DidSucceed())
			{
				return "Entry did not pass initial validation";
			}

			if (!_nullChecker.DidSucceed())
			{
				return "Could not validate nulls";
			}

			if (!_dataEntryValidation.DidSucceed())
			{
				return "Could not validate data entry";
			}

			if (!_databaseValidator.DidSucceed())
			{
				return "Could not validate database";
			}

			return "validated";
		}

		private interface ISuccessChecker
		{
			bool DidSucceed();
		}
	}
}
