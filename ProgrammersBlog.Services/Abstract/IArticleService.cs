using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract {
	public interface IArticleService {
		// Bütün işlemler asenkron olarak hazırlanmalıdır.
		Task<IDataResult<ArticleDto>> Get( int articleId );
		Task<IDataResult<ArticleListDto>> GetAll();        // Daha sonra CategoryId ya da date' e göre getirilebilir.
		Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();

		// Bu metod anasayfa için kullanılacaktır. Silinmemiş ve aktif durumda bulunan...
		Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();

		Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
		Task<IResult> Add( ArticleAddDto articleAddDto, string createdByName );
		Task<IResult> Update( ArticleUpdateDto articleUpdateDto, string modifiedByName );
		Task<IResult> Delete( int articleId, string modifiedByName );          // Sadece kategorinin IsDeleted değerini true yapacak.
		Task<IResult> HardDelete( int articleId );     // Perminant delete diyebiliriz.?
	}
}
