using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryNameResponse>> GetAllCategoryName()
        {
            var listCate = (await _unitOfWork.CategoryRepository.GetAllAsync());
            var result = _mapper.Map<List<CategoryNameResponse>>(listCate);
            return result;

        }
    }
}
