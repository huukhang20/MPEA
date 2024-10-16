using MPEA.Application.BaseModel;
using MPEA.Application.Model.RequestModel.ReportRequest;
using MPEA.Application.Model.ViewModel.Report;

namespace MPEA.Application.IService;

public interface IReportService
{
    // Task<bool> AddReport(ReportRequest addReportRequest);
    Task<(List<ReportResponse>, int)> GetAllReportPending(ListModels listReport);
    Task<bool> DeleteReport(string id);
    // Task<bool> UpdateReport(UpdateReportRequest updateReport);
    Task<ReportResponse> GetReportById(string reportId);
    Task<(List<ReportResponse>, int)> GetAllReport(ListModels list);
}