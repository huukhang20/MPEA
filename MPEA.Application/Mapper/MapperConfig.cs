using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Mapper
{
    public partial class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AddUserMapperConfig();
        }

        partial void AddUserMapperConfig();
    }
}
