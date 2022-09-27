using Starex.Application.Interfaces.Repositories.Logging;
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
    IDeclareReadRepository DeclareReadRepository { get; }
    IAppealReadRepository AppealReadRepository { get; }
    ICommitmentReadRepository CommitmentReadRepository { get; }
    IOrderReadRepository OrderReadRepository { get; }
    IPackageReadRepository PackageReadRepository { get; }
    IReturnPackageReadRepository ReturnPackageReadRepository { get; }



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
    IActionLogWriteRepository ActionLogWriteRepository { get; }
    IErrorLogWriteRepository ErrorLogWriteRepository { get; }
    IAppealWriteRepository AppealWriteRepository { get; }
    IDeclareWriteRepository DeclareWriteRepository { get; }
    ICommitmentWriteRepository CommitmentWriteRepository { get; }
    IOrderWriteRepository OrderWriteRepository { get; }
    IPackageWriteRepository PackageWriteRepository { get; }
    IReturnPackageWriteRepository ReturnPackageWriteRepository { get; }
}

