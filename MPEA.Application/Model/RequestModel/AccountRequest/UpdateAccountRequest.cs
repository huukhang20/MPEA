namespace MPEA.Application.Model.RequestModel.AccountRequest;

public class UpdateAccountRequest
{
    public required string PhoneNumber { get; set; }
    public required string FullName { get; set; }
}