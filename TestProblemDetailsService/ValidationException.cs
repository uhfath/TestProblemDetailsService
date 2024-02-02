using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestProblemDetailsService
{

	[Serializable]
	public class ValidationException : Exception
	{
		public ValidationException(ModelStateDictionary modelStateDictionary)
		{
			ModelStateDictionary = modelStateDictionary;
		}
		public ValidationException(ModelStateDictionary modelStateDictionary, string message) : base(message)
		{
			ModelStateDictionary = modelStateDictionary;
		}
		public ValidationException(ModelStateDictionary modelStateDictionary, string message, Exception inner) : base(message, inner)
		{
			ModelStateDictionary = modelStateDictionary;
		}
		protected ValidationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

		public ModelStateDictionary ModelStateDictionary { get; }
	}
}
