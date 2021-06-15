using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract {
	public interface ICategoryService {
		// Bütün işlemler asenkron olarak hazırlanmalıdır.
		Task<IDataResult<Category>> Get( int categoryId);
		Task<IDataResult<IList<Category>>> GetAll();        // Daha sonra CategoryId ya da date' e göre getirilebilir.
		Task<IDataResult<IList<Category>>> GetAllByNonDeleted();
		Task<IResult> Add( CategoryAddDto categoryAddDto, string createdByName );
		Task<IResult> Update( CategoryUpdateDto categoryUpdateDto, string modifiedByName );
		Task<IResult> Delete( int categoryId, string modifiedByName );			// Sadece kategorinin IsDeleted değerini true yapacak.
		Task<IResult> HardDelete( int categoryId );		// Perminant delete diyebiliriz.?
	}
}
