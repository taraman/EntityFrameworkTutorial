using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach04.Data
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}
