using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Enities
{
	public class TypeFilm : Entity
	{
		public virtual string NameType { get; set; }
		public virtual string Description { get; set; } = string.Empty;
		public virtual string Code { get; set; };
	}
}
