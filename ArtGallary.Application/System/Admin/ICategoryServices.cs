using ArtGallery.Data.Entities;
using ArtGallery.ViewModel.System.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallary.Application.System.Admin
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategories();//
        Task<IEnumerable<Category>> SearchCategory(string catename);//
        Task<Category> GetCategory(int cateid);

        Task<bool> InsertCategory(Category category);//
        Task<bool> UpdateCategory(CategoryRequest cateid);
        Task<bool> DeleteCategory(int cateid);//
    }
}
