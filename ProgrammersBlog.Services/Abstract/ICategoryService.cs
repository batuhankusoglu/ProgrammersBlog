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
		Task<IDataResult<CategoryDto>> Get( int categoryId);
		Task<IDataResult<CategoryListDto>> GetAll();        // Daha sonra CategoryId ya da date' e göre getirilebilir.
		Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
		Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();
		Task<IDataResult<CategoryDto>> Add( CategoryAddDto categoryAddDto, string createdByName );
		Task<IDataResult<CategoryDto>> Update( CategoryUpdateDto categoryUpdateDto, string modifiedByName );
		Task<IDataResult<CategoryDto>> Delete( int categoryId, string modifiedByName );			// Sadece kategorinin IsDeleted değerini true yapacak.
		Task<IResult> HardDelete( int categoryId );		// Perminant delete diyebiliriz.?
	}
}
