using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete {

	/// <summary>
	/// Bu sınıf sayesinde hem result hemde data dönebiliyoruz.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DataResult<T> : IDataResult<T> {

		public DataResult( ResultStatus resultStatus, T data ) {
			ResultStatus = resultStatus;
			Data = data;
		}

		public DataResult( ResultStatus resultStatus, string message, T data ) {
			ResultStatus = resultStatus;
			Message = message;
			Data = data;
		}

		public DataResult( ResultStatus resultStatus, string message, T data, Exception exception ) {
			ResultStatus = resultStatus;
			Message = message;
			Data = data;
			Exception = exception;
		}

		public T Data { get; }

		public ResultStatus ResultStatus { get; }

		public string Message { get; }

		public Exception Exception { get; }
	}
}
