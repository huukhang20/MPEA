using AutoMapper;
using MPEA.Application.Model.RequestModel.SparePart;
using MPEA.Application.Model.ViewModel.SparePart;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Mapper
{
    public partial class MapperConfig : Profile
    {
        partial void AddSparePartMapperConfig()
        {
            CreateMap<CreateSparePartRequest, SparePart>();
            CreateMap<Category, CreatePartResponse>();
        }
    }
}
