using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Interfaces;
using DataService.Interfaces;
using RepositoryPattern.Models;

namespace DataService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productCategoryRepository = _unitOfWork.Repository<ProductCategory>();
        }

        public bool Create(ProductCategory category)
        {
            try
            {
                _productCategoryRepository.Add(category);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ProductCategory Get(int idp)
        {
            return _productCategoryRepository.Get(x=>x.CategoryId == idp);
        }

        public List<ProductCategory> GetAll(int page = -1, int size = 10)
        {
            try
            {
                var rsl = _productCategoryRepository.GetAll();
                if(rsl != null && rsl.Any())
                {
                    if (page == -1)
                        return rsl.ToList();
                    else
                        return rsl.Skip(size * page).Take(size).ToList();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<ProductCategory> Search(string keyWord)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductCategory model)
        {
            try
            {
                _productCategoryRepository.Update(model);
                _unitOfWork.SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
