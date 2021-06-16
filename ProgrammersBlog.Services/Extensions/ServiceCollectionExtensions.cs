using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;

namespace ProgrammersBlog.Services.Extensions {
	/// <summary>
	/// Extension sınıfımız static olmalıdır.
	/// </summary>
	public static class ServiceCollectionExtensions {
		public static IServiceCollection LoadMyServices( this IServiceCollection serviceCollection ) {
			serviceCollection.AddDbContext<ProgrammersBlogContext>();
			serviceCollection.AddScoped<IUnitOfWork, IUnitOfWork>();
			serviceCollection.AddScoped<ICategoryService, CategoryManager>();
			serviceCollection.AddScoped<IArticleService, ArticleManager>();
			return serviceCollection;
		}
	}
}
