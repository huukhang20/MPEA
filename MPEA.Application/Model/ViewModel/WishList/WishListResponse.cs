namespace MPEA.Application.Model.ViewModel.WishList;

public class WishListResponse
{
    public string? UserId { get; set; }
    public string? SparePartId {  get; set; }   
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}