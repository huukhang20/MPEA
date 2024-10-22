﻿using MPEA.Application.Model.RequestModel.SparePart;
using MPEA.Application.Model.ViewModel.SparePart;

namespace MPEA.Application.IService;

public interface ISparePartService
{
    Task<CreatePartResponse> CreateSparePart(CreateSparePartRequest sparePartRequest);
}