using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete; //EntityLayer katmanı kullanıldı.
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}



		public List<Category> GetList()
		{
			return _categoryDal.List();
		}
		public void CategoryAddBusinessLayer(Category category) // Ekleme İşlemi:
																// Ekleme işlemi için önce CategoryValidator classında ki şartları kontrol etmeli.
		{
			_categoryDal.İnsert(category);
			//_categoryDal.İnsert(category);
		}

		public void CategoryDelete(Category category)
		{
			_categoryDal.Delete(category);
		}

		public void CategoryUpdate(Category category)
		{
			_categoryDal.Update(category);
		}

		public Category GetById(int id)
		{
			return _categoryDal.Get(x => x.CategoryId == id);
		}

	
	}
}
