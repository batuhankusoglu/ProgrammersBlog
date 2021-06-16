using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Entities.Dtos {
	public class ArticleDto : DtoGetBase {
		public Article Article { get; set; }
		// View tarafında kendimize esneklik sağlamak için tekrar ResultStatus tanımladık
		// ResultStatus success dönmez ise view tarafında göstermeme vb. esneklikler için 
		
	}
}
