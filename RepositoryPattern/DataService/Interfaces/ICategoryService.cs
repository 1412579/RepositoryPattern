using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Models;
namespace DataService.Interfaces
{
    public interface ICategoryService
    {
        List<ProductCategory> GetAll(int page = -1, int size = -1);
        ProductCategory Get(int idp);
        List<ProductCategory> Search(string keyWord);
        bool Create(ProductCategory product);
        bool Update(ProductCategory product);
    }
}
