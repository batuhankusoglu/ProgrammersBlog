using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Shared.Data.Abstract {
	/// <summary>
	/// Bu classta tüm entityler için DAL classlarda kullanılabilecek metodlar yazılmıştır.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IEntityRepository<T> where T:class,IEntity,new(){
		
		/// <summary>
		/// Expression ile bir kullanıcıyı ve o kullanıcının bilgilerini getirebiliyoruz.
		/// Bu kısımda bir tane entity getirilebilmektedir.
		/// </summary>
		/// <param name="predicate"> Filtreleme için kullanılıyor. </param>
		/// <param name="includeProperties"> Burada birden fazla properties istenebilir bu sebeple birden fazla parametre verebilmek için params getiriliyor. </param>
		/// <returns></returns>
		Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includeProperties);  // var kullanici = repository.GetAsync(k=>k.Id==15)

		/// <summary>
		/// Burada birden fazla entity getirilmesi amaçlanmıştır.
		/// </summary>
		/// <param name="predicate"> Null gelebilir, eğer null gelmezse bize gelen filtreye göre yükler. </param>
		/// <param name="includeProperties"></param>
		/// <returns></returns>
		Task<IList<T>> GetAllAsync( Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties );

		Task AddAsync( T entity );
		Task UpdateAsync( T entity );
		Task DeleteAsync( T entity );
		Task<bool> AnyAsync( Expression<Func<T, bool>> predicate );
		Task<int> CountAsync( Expression<Func<T, bool>> predicate );
	}
}
