using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract {
	public abstract class EntityBase {
		public virtual int Id { get; set; }
		// Başka classta override edebilmek için abstract olarak tanımladık...
		// Override edebilmemiz için virtual olarak tanımlamamız da gerekli...
		public virtual DateTime CreatedDate { get; set; } = DateTime.Now;   // Oluşturulma tarihi -->  override CreatedDate = new DateTime(2020/01/01);  
		public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;  // Düzenlenme tarihi
		public virtual bool IsDeleted { get; set; } = false;
		public virtual bool IsActive { get; set; } = true;
		public virtual string CreatedByName { get; set; } = "Admin";   // Default değer olarak Admin atadık... --> Üye kaydı olmadan yorum bırakabilme olacağı için Id yerine name tercih edildi.
		public virtual string ModifiedByName { get; set; } = "Admin ";
		public virtual string Note { get; set; }
	}
}
