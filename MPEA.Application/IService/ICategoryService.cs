using MPEA.Application.IRepository;
using MPEA.Application.Model.ViewModel.Category;
using MPEA.Application.Model.ViewModel.User;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IService
{
    public interface ICategoryService
    {
        Task<List<CategoryNameResponse>> GetAllCategoryName();
    }
}
