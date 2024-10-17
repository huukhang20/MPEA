using AutoMapper;
using MPEA.Application.Model.RequestModel.WishlistRequest;
using MPEA.Application.Model.ViewModel.WishList;
using MPEA.Domain.Models;

namespace MPEA.Application.Mapper;

public partial class MapperConfig : Profile
{
    partial void AddWishListMapperConfig()
    {
        CreateMap<Wishlist, WishlistRequest>().ReverseMap();
        CreateMap<Wishlist, UpdateWishlistRequest>().ReverseMap();
        CreateMap<Wishlist, WishListResponse>().ReverseMap();
    }
}