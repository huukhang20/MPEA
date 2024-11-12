using AutoMapper;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.NotificationRequest;
using MPEA.Application.Model.ViewModel.Notification;
using MPEA.Application.Model.ViewModel.PostResponse;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;

namespace MPEA.Application.Service;

public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> CreateNotification(NotificationRequest notification)
    {
        var newNotification = _mapper.Map<Notification>(notification);
        newNotification.Status = NotificationStatus.Active.ToString();
        newNotification.IsRead = false;
        await _unitOfWork.NotificationRepository.AddAsync(newNotification);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<List<NotificationResponse>> Get5Notification(int id)
    {
        var list = await _unitOfWork.NotificationRepository.Get5NotificationOfUser(id);

        return _mapper.Map<List<NotificationResponse>>(list);
    }

    public async Task<NotificationDetailResponse?> GetNotificationById(int id)
    {
        var notification = await _unitOfWork.NotificationRepository.GetByIdAsync(id);
        if (notification == null) throw new Exception("Khong tim thay Notification");
        await ReadNotification(id);
        return _mapper.Map<NotificationDetailResponse>(notification);
    }

    public async Task<(List<NotificationResponse>?, int)> GetNotificationByAccountId(ListModels listModels ,int id)
    {
        var accountList = await _unitOfWork.NotificationRepository.GetAllByAccount(id);
        accountList = accountList.Where(x => x.Status == NotificationStatus.InActive.ToString()).ToList();
        var result = _mapper.Map<List<NotificationResponse>>(accountList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (result, totalPages);
    }

    public async Task<bool> ReadNotification(int id)
    {
        var notification = await _unitOfWork.NotificationRepository.GetByIdAsync(id);
        if (notification == null) throw new Exception("Khong tim thay Notification");
        notification.IsRead = true;

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<List<NotificationResponse>> GetNotifications(int pageNumber, int pageSize)
    {
        var list = await _unitOfWork.NotificationRepository.GetNotifications(pageNumber, pageSize);
        var result = _mapper.Map<List<NotificationResponse>>(list);
        return result;
    }
}