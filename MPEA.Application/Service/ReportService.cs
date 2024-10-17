using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.ReportRequest;
using MPEA.Application.Model.ViewModel.Report;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;

namespace MPEA.Application.Service;

public class ReportService : IReportService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
     public async Task<bool> AddReport(ReportRequest addReportRequest)
     {
         var report = _mapper.Map<Report>(addReportRequest);
         report.Id = Guid.NewGuid().ToString(); 
         report.CreatedAt = DateTime.UtcNow; 
         _unitOfWork.ReportRepository.AddAsync(report);
         var result = await _unitOfWork.SaveChangesAsync();
         return result > 0;
     }

    public async Task<(List<ReportResponse>, int)> GetAllReportPending(ListModels listReport)
    {
        var reportList = await _unitOfWork.ReportRepository.GetAllReportPendingAsync();
        if (reportList.Count == 0) throw new Exception("Không tìm thấy báo cáo nào chưa xử lý");
        var result = _mapper.Map<List<ReportResponse>>(reportList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listReport.PageSize);
        int? itemsToSkip = (listReport.PageNumber - 1) * listReport.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listReport.PageSize)
            .ToList();
        return (result, totalPages);
    }

    public async Task<bool> DeleteReport(string id)
    {
        var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);
        if (report == null) throw new Exception("Không tìm thấy báo cáo");

        report.Status = ReportStatus.Inactive.ToString();

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

     public async Task<bool> UpdateReport(UpdateReportRequest updateReport)
    {
        var report = await GetReportById(updateReport.Id);
        if (report == null)
        {
            return false; // Báo cáo không tồn tại
        }

        // Cập nhật thông tin báo cáo
        report.UserId = updateReport.UserId;
        report.Content = updateReport.Content;
        report.Type = updateReport.Type;

        // Lưu lại báo cáo đã được cập nhật
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<ReportResponse> GetReportById(string reportId)
    {
        var result = await _unitOfWork.ReportRepository.GetByIdAsync(reportId);
        if (result == null) throw new Exception("Không tìm thấy báo cáo");
        return _mapper.Map<ReportResponse>(result);
    }

    public async Task<(List<ReportResponse>, int)> GetAllReport(ListModels list)
    {
        var reportList = await _unitOfWork.ReportRepository.GetAllAsync();
        if (reportList.Count == 0) throw new Exception("Không tìm thấy báo cáo nào");
        var result = _mapper.Map<List<ReportResponse>>(reportList);

        var totalPages = (int)Math.Ceiling((double)result.Count / list.PageSize);
        int? itemsToSkip = (list.PageNumber - 1) * list.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(list.PageSize)
            .ToList();
        return (result, totalPages);
    }
}