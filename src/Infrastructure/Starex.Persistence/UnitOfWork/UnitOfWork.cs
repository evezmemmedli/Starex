using Starex.Persistence.Context;
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
        public INewsReadRepository NewsReadRepository => _newsReadRepository?? new NewsReadRepository(_context);
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
        public ISettingWriteRepository SettingWriteRepository =>_settingWriteRepository ?? new SettingWriteRepository(_context);
        public ISkillWriteRepository SkillWriteRepository => _skillWriteRepository ?? new SkillWriteRepository(_context);
    }
