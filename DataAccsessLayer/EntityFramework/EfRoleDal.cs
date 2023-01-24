using DataAccsessLayer.Concrete.Repositories;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;

namespace DataAccesLayer.EntityFramework
{
	public class EfRoleDal : GenericRepository<Role>, IRoleDal
	{
	}
}