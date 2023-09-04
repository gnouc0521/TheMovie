using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Enities
{
	public class FilmCountry : Entity
	{
		public virtual string NameCountry { get; set; }
		public virtual string Code { get; set; }
	}
}
