public interface IUnitOfWork
{
     IAboutReadRepository AboutReadRepository { get; }
     IAboutSkillReadRepository AboutSkillReadRepository { get; }
     IAdvantageReadRepository AdvantageReadRepository { get; }
     IBrandReadRepository BrandReadRepository { get; }
     ICountryReadRepository CountryReadRepository { get; }
     IDeliveryPointReadRepository DeliveryPointReadRepository { get; }
     IFaqReadRepository FaqReadRepository { get; }
     IFaqQuestionReadRepository FaqQuestionReadRepository { get; }
     INewsReadRepository NewsReadRepository { get; }
     IPoctAdressReadRepository PoctAdressReadRepository { get; }
     IServiceReadRepository ServiceReadRepository { get; }
     ISettingReadRepository SettingReadRepository { get; }
     ISkillReadRepository SkillReadRepository { get; }

    IAboutWriteRepository AboutWriteRepository { get; }
    IAboutSkillWriteRepository AboutSkillWriteRepository { get; }
    IAdvantageWriteRepository AdvantageWriteRepository { get; }
    IBrandWriteRepository BrandWriteRepository { get; }
    ICountryWriteRepository CountryWriteRepository { get; }
    IDeliveryPointWriteRepository DeliveryPointWriteRepository { get; }
    IFaqWriteRepository FaqWriteRepository { get; }
    IFaqQuestionWriteRepository FaqQuestionWriteRepository { get; }
    INewsWriteRepository NewsWriteRepository { get; }
    IPoctAdressWriteRepository PoctAdressWriteRepository { get; }
    IServiceWriteRepository ServiceWriteRepository { get; }
    ISettingWriteRepository SettingWriteRepository { get; }
    ISkillWriteRepository SkillWriteRepository { get; }

   
 
}

