using AutoMapper;
using MPEA.Application.IRepository;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.WishlistRequest;
using MPEA.Application.Model.ViewModel.WishList;
using MPEA.Domain.Models;

namespace MPEA.Application.Service;

public class WishlistService : IWishlistService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWishlistRepository _wishlistRepository;
    private object _wishListRepository;

    public WishlistService(IUnitOfWork unitOfWork, IMapper mapper, IWishlistRepository wishlistRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _wishlistRepository = wishlistRepository;
    }
    public async Task<Wishlist> CreateWishList(WishlistRequest wishlistRequest)
    {
        if (string.IsNullOrWhiteSpace(wishlistRequest.UserId))
        {
            throw new ArgumentException("UserId is required.");
        }
        if (string.IsNullOrWhiteSpace(wishlistRequest.SparePartId))
        {
            throw new ArgumentException("SparePartId is required.");
        }
        
        if (wishlistRequest.CreatedAt.HasValue && wishlistRequest.CreatedAt.Value > DateTime.UtcNow)
        {
            throw new ArgumentException("CreatedAt cannot be in the future.");
        }
        var wishList = _mapper.Map<Wishlist>(wishlistRequest);
        await _unitOfWork.WishlistRepository.AddAsync(wishList);
        await _unitOfWork.SaveChangesAsync();
        return wishList;
    }

    public async Task<List<WishListResponse>> GetAllWishList()
    {
        var wishLists = await _unitOfWork.WishlistRepository.GetAllAsync();
        var response = _mapper.Map<List<WishListResponse>>(wishLists);
        return response;
    }

    public async Task<WishListResponse> GetWishListById(string id)
    {
        if (!Guid.TryParse(id, out var parsedId))
        {
            throw new ArgumentException("Invalid id format.");
        }

        var wishList = await _unitOfWork.WishlistRepository.GetByIdAsync(parsedId);
        if (wishList == null)
        {
            throw new KeyNotFoundException("WishList not found.");
        }
        var response = _mapper.Map<WishListResponse>(wishList);

        return response;
    }

    public async Task<(List<WishListResponse>?, int)> GetWishListByAccountId(string id)
    {
        var wishLists = await _unitOfWork.WishlistRepository.GetWishListByAccountId(id);
        if (wishLists == null || !wishLists.Any())
        {
            throw new KeyNotFoundException("No WishLists found for the given AccountId.");
        }
        var response = _mapper.Map<List<WishListResponse>>(wishLists);
        return (response, response.Count);
    }

    // public async Task<Wishlist> UpdateWishList(UpdateWishlistRequest updateWishlistRequest)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<Wishlist> DeleteWishList(string id)
    // {
    //     throw new NotImplementedException();
    // }
}