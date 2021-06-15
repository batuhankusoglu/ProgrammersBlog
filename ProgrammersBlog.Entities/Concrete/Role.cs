﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete {
	public class Role : EntityBase,IEntity {
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<User> Users { get; set; } // Bir role birden fazla kullanıcı sahip olabilir
	}
}
