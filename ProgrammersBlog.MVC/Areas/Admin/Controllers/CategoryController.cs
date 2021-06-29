using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.MVC.Areas.Admin.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers {

	[Area( "Admin" )]
	public class CategoryController : Controller {

		//category servisi çağırmamız gerekiyor.
		private readonly ICategoryService _categoryService;

		public CategoryController( ICategoryService categoryService ) {
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index() {
			// Categoryservice içinde data resuly dönüyoruz. Bu result success ise ona göre işlem yapacağız.
			var result = await _categoryService.GetAll();

			// Aşağıdaki kısım controllerda değil viewda çözecğimiz için commente alındı.
			//if (result.ResultStatus == ResultStatus.Success) {
			//	return View( result.Data );
			//}

			return View( result.Data );
		}

		/// <summary>
		/// Partial View olduğundan asenkron yapmamıza gerek yok.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Add() {
			return PartialView( "_CategoryAddPartial" );
		}
		[HttpPost]
		public async Task<IActionResult> Add( CategoryAddDto categoryAddDto ) {
			if (ModelState.IsValid) {
				var result = await _categoryService.Add(categoryAddDto, "Batuhan");
				if (result.ResultStatus == ResultStatus.Success) {
					var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel{
						CategoryDto = result.Data,
						// Formun içerisine modal state frontend tarafına gönderiliyor. Oradaki true-false durumuna göre bir kontrol sağlanıyor.
						// O yüzden CategoryAddPartial geri dönüyoruz. Geriye dönen partial oraya yazıyor olacağız.                                                         
						CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial",categoryAddDto)
					});
					return Json( categoryAddAjaxModel );
				}
			}
			var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel{
				
				// Formun içerisine modal state frontend tarafına gönderiliyor. Oradaki true-false durumuna göre bir kontrol sağlanıyor.
				// O yüzden CategoryAddPartial geri dönüyoruz. Geriye dönen partial oraya yazıyor olacağız.                                                         
				CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial",categoryAddDto)
			});
			return Json( categoryAddAjaxErrorModel );
		}
	}
}
