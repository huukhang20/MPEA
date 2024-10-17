namespace MPEA.Application.Model.RequestModel.WishlistRequest;

public class UpdateWishlistRequest
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? SparePartId {  get; set; }   
    public DateTime? UpdatedAt { get; set; }
}