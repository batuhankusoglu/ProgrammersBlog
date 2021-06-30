using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
		private readonly IMapper _mapper;

		public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		#region Add Method
		public async Task<IDataResult<CategoryDto>> Add( CategoryAddDto categoryAddDto, string createdByName ) {
			var category = _mapper.Map<Category>(categoryAddDto);
			category.CreatedByName = createdByName;
			category.ModifiedByName = createdByName;
			var addedCategory =  await _unitOfWork.Categories.AddAsync( category );
			await _unitOfWork.SaveAsync();
			// await _unitOfWork.SaveAsync();
			return new DataResult<CategoryDto>( ResultStatus.Success, message: $"{ categoryAddDto.Name} adlı kategori başarıyla eklenmiştir.",
				new CategoryDto { 
					Category = addedCategory,
					ResultStatus = ResultStatus.Success,
					Message = $"{ categoryAddDto.Name} adlı kategori başarıyla eklenmiştir."
				} );
		}

		#endregion

		#region Delete Methods
		public async Task<IDataResult<CategoryDto>> Delete( int categoryId, string modifiedByName ) {
			var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
			if (category != null) {
				category.IsDeleted = true;
				category.ModifiedByName = modifiedByName;
				category.ModifiedDate = DateTime.Now;
				var deletedCategory =  await _unitOfWork.Categories.UpdateAsync( category );
				await _unitOfWork.SaveAsync();
				return new DataResult<CategoryDto>( ResultStatus.Success, message: $"{ deletedCategory.Name} adlı kategori başarıyla silinmiştir.",
					new CategoryDto {
						Category = deletedCategory,
						ResultStatus = ResultStatus.Success,
						Message = $"{ deletedCategory.Name} adlı kategori başarıyla silinmiştir."
					} );
			}
			return new DataResult<CategoryDto>( ResultStatus.Error, message: "Böyle bir kategori bulunamadı.",
					new CategoryDto {
						Category = null,
						ResultStatus = ResultStatus.Error,
						Message = "Böyle bir kategori bulunamadı."
					} );
		}

		public async Task<IResult> HardDelete( int categoryId ) {
			var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
			if (category != null) {
				await _unitOfWork.Categories.DeleteAsync( category );
				await _unitOfWork.SaveAsync();
				return new Result( ResultStatus.Success, message: $"{category.Name} adlı kategori başarıyla veritabanından silinmişir" );
			}
			return new Result( ResultStatus.Error, message: "Böyle bir kategori bulunamadı." );
		}

		#endregion

		#region Get Methods
		public async Task<IDataResult<CategoryDto>> Get( int categoryId ) {
			var category = await _unitOfWork.Categories.GetAsync( c => c.Id == categoryId, c => c.Articles );

			if (category != null) {
				return new DataResult<CategoryDto>( ResultStatus.Success, new CategoryDto { 
					Category = category,
					ResultStatus = ResultStatus.Success
				} );
			}
			return new DataResult<CategoryDto>( ResultStatus.Error, message: "Böyle bir kategori bulunamadı.", 
				data: new CategoryDto { 
					Category = null,
					ResultStatus = ResultStatus.Error,
					Message = "Böyle bir kategori bulunamadı."
				}  );
		}

		public async Task<IDataResult<CategoryListDto>> GetAll() {
			var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
			// Kategorilerin admin panelinden eklenme ihtimali de mevcut olduğundan -1'den başlatıyoruz.
			if (categories.Count > -1 ) {
				return new DataResult<CategoryListDto>( ResultStatus.Success, new CategoryListDto { 
					Categories = categories,
					ResultStatus = ResultStatus.Success
				} );
			}
			return new DataResult<CategoryListDto>( ResultStatus.Error, message: "Hiç bir kategori bulunamadı.", 
				new CategoryListDto {

					// Aşağıdaki tanımlamalar View içerisinde ihtiyaçlarımızı gidermemizi sağlayacak. (Result döndüğümüzde)
					Categories = null,
					ResultStatus = ResultStatus.Error,
					Message = "Hiç bir kategori bulunamadı."
				} );
		}

		public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted() {
			var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles);
			if (categories.Count > -1) {
				return new DataResult<CategoryListDto>( ResultStatus.Success, new CategoryListDto {
					Categories = categories,
					ResultStatus = ResultStatus.Success
				} );
			}
			return new DataResult<CategoryListDto>( ResultStatus.Error, message: "Hiç bir kategori bulunamadı.",
				new CategoryListDto {

					// Aşağıdaki tanımlamalar View içerisinde ihtiyaçlarımızı gidermemizi sağlayacak. (Result döndüğümüzde)
					Categories = null,
					ResultStatus = ResultStatus.Error,
					Message = "Hiç bir kategori bulunamadı."
				} );
		}

		public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive() {
			var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles);
			if (categories.Count > -1) {
				return new DataResult<CategoryListDto>( ResultStatus.Success, new CategoryListDto {
					Categories = categories,
					ResultStatus = ResultStatus.Success
				} );
			}
			return new DataResult<CategoryListDto>( ResultStatus.Error, message: "Hiçbir kategori bulunamadı.", null );
		}

		#endregion

		#region Update Method
		public async Task<IDataResult<CategoryDto>> Update( CategoryUpdateDto categoryUpdateDto, string modifiedByName ) {
			// Update edilecek kategoriyi Id'sine göre getirmeliyiz öncelikle.
			var category = _mapper.Map<Category>(categoryUpdateDto);
			category.ModifiedByName = modifiedByName;
			var updatedCategory =  await _unitOfWork.Categories.UpdateAsync( category );
			await _unitOfWork.SaveAsync();
			return new DataResult<CategoryDto>( ResultStatus.Success, message: $"{ categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir.",
				new CategoryDto { 
					Category = updatedCategory,
					ResultStatus = ResultStatus.Success,
					Message = $"{ categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir."
				} );
		}

		#endregion
	}
}
