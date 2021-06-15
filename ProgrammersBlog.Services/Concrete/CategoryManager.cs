using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete {
	public class CategoryManager : ICategoryService {

		private readonly IUnitOfWork _unitOfWork;

		public CategoryManager(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		#region Add Method
		public async Task<IResult> Add( CategoryAddDto categoryAddDto, string createdByName ) {
			await _unitOfWork.Categories.AddAsync( new Category {
				Name = categoryAddDto.Name,
				Description = categoryAddDto.Description,
				Note = categoryAddDto.Note,
				IsActive = categoryAddDto.IsActive,
				CreatedByName = createdByName,
				CreatedDate = DateTime.Now,
				ModifiedByName = createdByName,
				ModifiedDate = DateTime.Now,
				IsDeleted = false
			} ).ContinueWith(t => _unitOfWork.SaveAsync());
			// await _unitOfWork.SaveAsync();
			return new Result( ResultStatus.Success, message: $"{ categoryAddDto.Name} adlı kategori başarıyla eklenmiştir." );
		}

		#endregion

		#region Delete Methods
		public async Task<IResult> Delete( int categoryId, string modifiedByName ) {
			var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
			if (category != null) {
				category.IsDeleted = true;
				category.ModifiedByName = modifiedByName;
				category.ModifiedDate = DateTime.Now;
				await _unitOfWork.Categories.UpdateAsync( category ).ContinueWith( t => _unitOfWork.SaveAsync() );
				return new Result( ResultStatus.Success, message: $"{category.Name} adlı kategori başarıyla silinmişir" );
			}
			return new Result( ResultStatus.Error, message: "Böyle bir kategori bulunamadı." );
		}

		public async Task<IResult> HardDelete( int categoryId ) {
			var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
			if (category != null) {
				await _unitOfWork.Categories.DeleteAsync( category ).ContinueWith(t => _unitOfWork.SaveAsync());
				return new Result( ResultStatus.Success, message: $"{category.Name} adlı kategori başarıyla veritabanından silinmişir" );
			}
			return new Result( ResultStatus.Error, message: "Böyle bir kategori bulunamadı." );
		}

		#endregion

		#region Get Methods
		public async Task<IDataResult<Category>> Get( int categoryId ) {
			var category = await _unitOfWork.Categories.GetAsync( c => c.Id == categoryId, c => c.Articles );

			if (category != null) {
				return new DataResult<Category>( ResultStatus.Success, category );
			}
			return new DataResult<Category>( ResultStatus.Error, message: "Böyle bir kategori bulunamadı.", data: null );
		}

		public async Task<IDataResult<IList<Category>>> GetAll() {
			var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
			// Kategorilerin admin panelinden eklenme ihtimali de mevcut olduğundan -1'den başlatıyoruz.
			if (categories.Count > -1 ) {
				return new DataResult<IList<Category>>( ResultStatus.Success, categories );
			}
			return new DataResult<IList<Category>>( ResultStatus.Error, message: "Hiçbir kategori bulunamadı.", null );
		}

		public async Task<IDataResult<IList<Category>>> GetAllByNonDeleted() {
			var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles);
			if (categories.Count > -1) {
				return new DataResult<IList<Category>>( ResultStatus.Success, categories );
			}
			return new DataResult<IList<Category>>( ResultStatus.Error, message: "Hiçbir kategori bulunamadı.", null );
		}

		#endregion

		#region Update Method
		public async Task<IResult> Update( CategoryUpdateDto categoryUpdateDto, string modifiedByName ) {
			// Update edilecek kategoriyi Id'sine göre getirmeliyiz öncelikle.
			var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
			if (category != null) {
				category.Name = categoryUpdateDto.Name;
				category.Description = categoryUpdateDto.Description;
				category.Note = categoryUpdateDto.Note;
				category.IsActive = categoryUpdateDto.IsActive;
				category.IsDeleted = categoryUpdateDto.IsDeleted;
				category.ModifiedByName = modifiedByName;
				category.ModifiedDate = DateTime.Now;
				await _unitOfWork.Categories.UpdateAsync( category ).ContinueWith( t => _unitOfWork.SaveAsync() );
				return new Result( ResultStatus.Success, message: $"{ categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir.." );
			}
			return new Result( ResultStatus.Error, message: "Böyle bir kategori bulunamadı.");
		}

		#endregion
	}
}
