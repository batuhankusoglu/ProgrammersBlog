using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract {
	public interface IResult {
		// Result durumu paylaşılmalı. ResultStatus enum olarak oluşturulmalı.
		// Constructora sonuç verirken sadece get yeterli, daha sonra değiştirilebilir olmayacaklar.

		public ResultStatus ResultStatus { get; }      //ResultStatus.Success or ResultStatus.Error
		public string Message { get; }
		public Exception Exception { get; }
	}
}
