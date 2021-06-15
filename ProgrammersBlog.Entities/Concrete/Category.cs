using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete {
	/// <summary>
	/// Data katmanından erişmek isteyeceğimiz için bu class public olacaktır.
	/// </summary>
	public class Category : EntityBase, IEntity{
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<Article> Articles { get; set; }
	}
}
