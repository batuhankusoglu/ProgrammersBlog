using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;

namespace ProgrammersBlog.Data.Concrete {
	public class UnitOfWork : IUnitOfWork {

		private readonly ProgrammersBlogContext _context;
		private readonly EfArticleRepository _articleRepository;
		private readonly EfCategoryRepository _categoryRepository;
		private readonly EfCommentRepository _commentRepository;
		private readonly EfRoleRepository _roleRepository;
		private readonly EfUserRepository _userRepository;

		public UnitOfWork( ProgrammersBlogContext context ) {
			_context = context;
		}

		// Repositoryler için return işlemleri.
		public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository( _context );

		public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

		public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository( _context );

		public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository( _context );

		public IUserRepository Users => _userRepository ?? new EfUserRepository( _context );


		/// <summary>
		/// Context dispose ediliyor.
		/// </summary>
		/// 
		public async ValueTask DisposeAsync() {
			await _context.DisposeAsync();
		}


		public async Task<int> SaveAsync() {
			return await _context.SaveChangesAsync();
		}
	}
}
