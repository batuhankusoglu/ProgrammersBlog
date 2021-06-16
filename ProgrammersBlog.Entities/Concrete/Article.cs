using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete {
	public class Article : EntityBase,IEntity {
		public string Title { get; set; }
		public string Content { get; set; }
		public string Thumbnail { get; set; } // Resmin ismini ya da yolunu string olarak tutacağız.
		public DateTime Date { get; set; }
		public int ViewCount { get; set; } = 0;
		public int CommentCount { get; set; } = 0;
		
		// SEO Optimization
		public string SeoAuthor { get; set; }
		public string SeoDescription { get; set; }
		public string SeoTags { get; set; }
		
		public int CategoryId { get; set; }
		public Category Category { get; set; } // Navigation Property; Categorye ulaşıp onun ismini ve açıklamasını almak gibi ihtiyaçlar için
		
		// User
		public int UserId { get; set; }
		public User User { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}
