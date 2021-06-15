using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Concrete.EntityFramework.Mappings;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Contexts {
	public class ProgrammersBlogContext : DbContext {
		public DbSet<Article> Articles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {
			optionsBuilder.UseSqlServer( @"Server=DESKTOP-UBOCAVD;Database=ProgrammersBlog;Trusted_Connection=True;Connect Timeout=50;MultipleActiveResultSets=True;Integrated Security=True;" );
		}


		/// <summary>
		/// Mapping işlemlerimizi uyguluyoruz.
		/// </summary>
		/// <param name="modelBuilder"></param>
		
		protected override void OnModelCreating( ModelBuilder modelBuilder ) {
			modelBuilder.ApplyConfiguration( new CategoryMap());
			modelBuilder.ApplyConfiguration( new ArticleMap() );
			modelBuilder.ApplyConfiguration( new CommentMap() );
			modelBuilder.ApplyConfiguration( new RoleMap() );
			modelBuilder.ApplyConfiguration( new UserMap() );
		}
	}
}
