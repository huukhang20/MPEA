using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.SparePart;
using MPEA.Application.Model.ViewModel.SparePart;
using MPEA.Domain.Models;

namespace MPEA.Application.Service;

public class SparePartService : ISparePartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SparePartService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreatePartResponse> CreateSparePart(CreateSparePartRequest sparePartRequest)
    {
        var response = new CreatePartResponse();

        var sparePart = _mapper.Map<SparePart>(sparePartRequest);
        await _unitOfWork.SparePartRepository.AddAsync(sparePart);

        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            response.Message = "Failed";
            response.Success = true;
            return response;
        }

        response.Message = "Succefully";
        response.Success = true;

        return response;
    }

    public async Task<List<SparePartResponse>> GetAllSparePart()
    {
        var list = await _unitOfWork.SparePartRepository.GetAllAsync();
        var result = _mapper.Map<List<SparePartResponse>>(list);

        return result;
    }

    public async Task<List<SparePartResponse>> GetPartByCateName(string query)
    {
        var list = await _unitOfWork.SparePartRepository.GetByCateName(query);
        var result = _mapper.Map<List<SparePartResponse>>(list);
        return result;
    }

    public async Task<List<SparePartResponse>> GetPartByName(string query)
    {
        var list = await _unitOfWork.SparePartRepository.GetByName(query);
        var result = _mapper.Map<List<SparePartResponse>>(list);
        return result;
    }
}