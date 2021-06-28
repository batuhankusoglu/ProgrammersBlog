using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers {
	
	[Area("Admin")]
	public class CategoryController : Controller {
		
		//category servisi çağırmamız gerekiyor.
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService) {
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index() {
			// Categoryservice içinde data resuly dönüyoruz. Bu result success ise ona göre işlem yapacağız.
			var result = await _categoryService.GetAll();
			
			// Aşağıdaki kısım controllerda değil viewda çözecğimiz için commente alındı.
			//if (result.ResultStatus == ResultStatus.Success) {
			//	return View( result.Data );
			//}
			
			return View(result.Data);
		}

		/// <summary>
		/// Partial View olduğundan asenkron yapmamıza gerek yok.
		/// </summary>
		/// <returns></returns>
		public IActionResult Add() {
			return PartialView( "_CategoryAddPartial" );
		}
	}
}
