﻿using Starex.Application.Interfaces.Repositories.Logging;
using Starex.Persistence.Context;
using Starex.Persistence.Repositories.Log;
using Starex.Persistence.Repositories.Logging;

public class UnitOfWork : IUnitOfWork
{
    IAboutReadRepository _aboutReadRepository;
    IAboutSkillReadRepository _aboutSkillReadRepository;
    IAdvantageReadRepository _advantageReadRepository;
    IBrandReadRepository _brandReadRepository;
    ICountryReadRepository _countryReadRepository;
    IDeliveryPointReadRepository _deliveryPointReadRepository;
    IFaqReadRepository _faqReadRepository;
    IFaqQuestionReadRepository _faqQuestionReadRepository;
    INewsReadRepository _newsReadRepository;
    IPoctAdressReadRepository _poctAdressReadRepository;
    IServiceReadRepository _serviceReadRepository;
    ISettingReadRepository _settingReadRepository;
    ISkillReadRepository _skillReadRepository;
    IAppealReadRepository _appealReadRepository;
    ICommitmentReadRepository _commitmentReadRepository;
    IDeclareReadRepository _declareReadRepository;
    IOrderReadRepository _orderReadRepository;
    IPackageReadRepository _packageReadRepository;
    IReturnPackageReadRepository _returnPackageReadRepository;


    IAboutWriteRepository _aboutWriteRepository;
    IAboutSkillWriteRepository _aboutSkillWriteRepository;
    IBrandWriteRepository _brandWriteRepository;
    IAdvantageWriteRepository _advantageWriteRepository;
    ICountryWriteRepository _countryWriteRepository;
    IDeliveryPointWriteRepository _deliveryPointWriteRepository;
    IFaqWriteRepository _faqWriteRepository;
    IFaqQuestionWriteRepository _faqQuestionWriteRepository;
    INewsWriteRepository _newsWriteRepository;
    IPoctAdressWriteRepository _poctAdressWriteRepository;
    IServiceWriteRepository _serviceWriteRepository;
    ISettingWriteRepository _settingWriteRepository;
    ISkillWriteRepository _skillWriteRepository;
    IActionLogWriteRepository _actionLogWriteRepository;
    IErrorLogWriteRepository _errorLogWriteRepository;
    IAppealWriteRepository _appealWriteRepository;
    ICommitmentWriteRepository _commitmentWriteRepository;
    IDeclareWriteRepository _declareWriteRepository;
    IOrderWriteRepository _orderWriteRepository;
    IPackageWriteRepository _packageWriteRepository;
    IReturnPackageWriteRepository _returnPackageWriteRepository;
    private readonly StarexDbContext _context;
    public UnitOfWork(StarexDbContext context)
    {
        _context = context;
    }

    public IAboutReadRepository AboutReadRepository => _aboutReadRepository ?? new AboutReadRepository(_context);
    public IAboutSkillReadRepository AboutSkillReadRepository => _aboutSkillReadRepository ?? new AboutSkillReadRepository(_context);
    public IAdvantageReadRepository AdvantageReadRepository => _advantageReadRepository ?? new AdvantageReadRepository(_context);
    public IBrandReadRepository BrandReadRepository => _brandReadRepository ?? new BrandReadRepository(_context);
    public ICountryReadRepository CountryReadRepository => _countryReadRepository ?? new CountryReadRepository(_context);
    public IDeliveryPointReadRepository DeliveryPointReadRepository => _deliveryPointReadRepository ?? new DeliveryPointReadRepository(_context);
    public IFaqReadRepository FaqReadRepository => _faqReadRepository ?? new FaqReadRepository(_context);
    public IFaqQuestionReadRepository FaqQuestionReadRepository => _faqQuestionReadRepository ?? new FaqQuestionReadRepository(_context);
    public INewsReadRepository NewsReadRepository => _newsReadRepository ?? new NewsReadRepository(_context);
    public IPoctAdressReadRepository PoctAdressReadRepository => _poctAdressReadRepository ?? new PoctAdressReadRepository(_context);
    public IServiceReadRepository ServiceReadRepository => _serviceReadRepository ?? new ServiceReadRepository(_context);
    public ISettingReadRepository SettingReadRepository => _settingReadRepository ?? new SettingReadRepository(_context);
    public ISkillReadRepository SkillReadRepository => _skillReadRepository ?? new SkillReadRepository(_context);
    public IAboutWriteRepository AboutWriteRepository => _aboutWriteRepository ?? new AboutWriteRepository(_context);
    public IAboutSkillWriteRepository AboutSkillWriteRepository => _aboutSkillWriteRepository ?? new AboutSkillWriteRepository(_context);
    public IAdvantageWriteRepository AdvantageWriteRepository => _advantageWriteRepository ?? new AdvantageWriteRepository(_context);
    public IBrandWriteRepository BrandWriteRepository => _brandWriteRepository ?? new BrandWriteRepository(_context);
    public ICountryWriteRepository CountryWriteRepository => _countryWriteRepository ?? new CountryWriteRepository(_context);
    public IDeliveryPointWriteRepository DeliveryPointWriteRepository => _deliveryPointWriteRepository ?? new DeliveryPointWriteRepository(_context);
    public IFaqWriteRepository FaqWriteRepository => _faqWriteRepository ?? new FaqWriteRepository(_context);
    public IFaqQuestionWriteRepository FaqQuestionWriteRepository => _faqQuestionWriteRepository ?? new FaqQuestionWriteRepository(_context);
    public INewsWriteRepository NewsWriteRepository => _newsWriteRepository ?? new NewsWriteRepository(_context);
    public IPoctAdressWriteRepository PoctAdressWriteRepository => _poctAdressWriteRepository ?? new PoctAdressWriteRepository(_context);
    public IServiceWriteRepository ServiceWriteRepository => _serviceWriteRepository ?? new ServiceWriteRepository(_context);
    public ISettingWriteRepository SettingWriteRepository => _settingWriteRepository ?? new SettingWriteRepository(_context);
    public ISkillWriteRepository SkillWriteRepository => _skillWriteRepository ?? new SkillWriteRepository(_context);
    public IActionLogWriteRepository ActionLogWriteRepository => _actionLogWriteRepository ?? new ActionLogWriteRepository(_context);
    public IErrorLogWriteRepository ErrorLogWriteRepository => _errorLogWriteRepository ?? new ErrorLogWriteRepository(_context);



    public IDeclareReadRepository DeclareReadRepository => _declareReadRepository ?? new DeclareReadRepository(_context);

    public IAppealReadRepository AppealReadRepository => _appealReadRepository ?? new AppealReadRepository(_context);

    public ICommitmentReadRepository CommitmentReadRepository => _commitmentReadRepository ?? new CommitmentReadRepository(_context);

    public IOrderReadRepository OrderReadRepository => _orderReadRepository ?? new OrderReadRepository(_context);

    public IPackageReadRepository PackageReadRepository => _packageReadRepository ?? new PackageReadRepository(_context);

    public IReturnPackageReadRepository ReturnPackageReadRepository => _returnPackageReadRepository ?? new ReturnPackageReadRepository(_context);

    public IAppealWriteRepository AppealWriteRepository => _appealWriteRepository ?? new AppealWriteRepository(_context);

    public IDeclareWriteRepository DeclareWriteRepository => _declareWriteRepository ?? new DeclareWriteRepository(_context);

    public ICommitmentWriteRepository CommitmentWriteRepository => _commitmentWriteRepository ?? new CommitmentWriteRepository(_context);

    public IOrderWriteRepository OrderWriteRepository => _orderWriteRepository ?? new OrderWriteRepository(_context);

    public IPackageWriteRepository PackageWriteRepository => _packageWriteRepository ?? new PackageWriteRepository(_context);

    public IReturnPackageWriteRepository ReturnPackageWriteRepository => _returnPackageWriteRepository ?? new ReturnPackageWriteRepository(_context);
}
