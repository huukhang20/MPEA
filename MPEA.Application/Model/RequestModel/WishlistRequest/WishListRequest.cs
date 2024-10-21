namespace MPEA.Application.Model.RequestModel.WishlistRequest;

public class WishlistRequest
{
    public string? UserId { get; set; }
    public string? SparePartId {  get; set; }   
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}