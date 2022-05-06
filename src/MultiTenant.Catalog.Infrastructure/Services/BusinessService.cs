using AutoMapper;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;
using MultiTenant.Catalog.Domain.Entities;
using MultiTenant.Catalog.Domain.Exceptions;
using MultiTenant.Catalog.Infrastructure.Common.Repositories;
using MultiTenant.Catalog.Infrastructure.Common.Unit;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class BusinessService : IBusinessService
{
    private readonly IRepository<Business> _businessRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BusinessService(IRepository<Business> businessRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<BusinessContract>> GetListAsync()
    {
        var businessLines = await _businessRepository.ListAsync();
        var mapped = _mapper.Map<List<BusinessContract>>(businessLines);
        return mapped;
    }

    public async Task<BusinessContract> GetAsync(Guid businessId)
    {
        var businessLine = await _businessRepository.GetByIdAsync(businessId);
        if (businessLine is null)
            throw new NotFoundException(nameof(businessId), nameof(Business));
        var mapped = _mapper.Map<BusinessContract>(businessLine);
        return mapped;
    }

    public async Task<BusinessContract> CreateAsync(BusinessContract model)
    {
        var business = _mapper.Map<Business>(model);
        _businessRepository.Add(business);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BusinessContract>(business);
    }

    public async Task<BusinessContract> UpdateAsync(BusinessContract model)
    {
        var businessLine = await _businessRepository.GetByIdAsync(model.Id);
        if (businessLine is null)
            throw new NotFoundException("businessId", nameof(Business));
        _businessRepository.Update(_mapper.Map<Business>(model));
        await _unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<bool> DeleteAsync(Guid businessId)
    {
        var businessLine = await _businessRepository.GetByIdAsync(businessId);
        if (businessLine is null)
            throw new NotFoundException(nameof(businessId), nameof(Business));
        _businessRepository.Delete(businessLine);
        return await _unitOfWork.SaveChangesAsync();
    }
}