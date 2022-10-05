public struct ApiRoutes
{
    private const string Root = "api";
    private const string Base = Root;
    public struct About
    {
        public const string GetAll = Base + "/about";
        public const string Get = Base + "/about/{aboutId}";
        public const string Update = Base + "/about/{aboutId}";
        public const string Delete = Base + "/about/{aboutId}";
        public const string Create = Base + "/about";
    }
    public struct AboutSkill
    {
        public const string GetAll = Base + "/aboutSkill";
        public const string Get = Base + "/aboutSkill/{aboutSkillId}";
        public const string Update = Base + "/aboutSkill/{aboutSkillId}";
        public const string Delete = Base + "/aboutSkill/{aboutSkillId}";
        public const string Create = Base + "/aboutSkill";
    }
    public struct Advantage
    {
        public const string GetAll = Base + "/advantage";
        public const string Get = Base + "/advantage/{advantageId}";
        public const string Update = Base + "/advantage/{advantageId}";
        public const string Delete = Base + "/advantage/{advantageId}";
        public const string Create = Base + "/advantage";
    }
    public struct Brand
    {
        public const string GetAll = Base + "/brand";
        public const string Get = Base + "/brand/{brandId}";
        public const string Update = Base + "/brand/{brandId}";
        public const string Delete = Base + "/brand/{brandId}";
        public const string Create = Base + "/brand";
    }
    public struct Country
    {
        public const string GetAll = Base + "/country";
        public const string Get = Base + "/country/{countryId}";
        public const string Update = Base + "/country/{countryId}";
        public const string Delete = Base + "/country/{countryId}";
        public const string Create = Base + "/country";
    }
    public struct DeliveryPoint
    {
        public const string GetAll = Base + "/deliveryPoint";
        public const string Get = Base + "/deliveryPoint/{deliveryPointId}";
        public const string Update = Base + "/deliveryPoint/{deliveryPointId}";
        public const string Delete = Base + "/deliveryPoint/{deliveryPointId}";
        public const string Create = Base + "/deliveryPoint";
    }
    public struct Faq
    {
        public const string GetAll = Base + "/faq";
        public const string Get = Base + "/faq/{faqId}";
        public const string Update = Base + "/faq/{faqId}";
        public const string Delete = Base + "/faq/{faqId}";
        public const string Create = Base + "/faq";
    }
    public struct FaqQuestion
    {
        public const string GetAll = Base + "/faqQuestion";
        public const string Get = Base + "/faqQuestion/{faqQuestionId}";
        public const string Update = Base + "/faqQuestion/{faqQuestionId}";
        public const string Delete = Base + "/faqQuestion/{faqQuestionId}";
        public const string Create = Base + "/faqQuestion";
    }
    public struct News
    {
        public const string GetAll = Base + "/news";
        public const string Get = Base + "/news/{newsId}";
        public const string Update = Base + "/news/{newsId}";
        public const string Delete = Base + "/news/{newsId}";
        public const string Create = Base + "/news";
    }
    public struct PoctAdress
    {
        public const string GetAll = Base + "/poctAdress";
        public const string Get = Base + "/poctAdress/{poctAdressId}";
        public const string Update = Base + "/poctAdress/{poctAdressId}";
        public const string Delete = Base + "/poctAdress/{poctAdressId}";
        public const string Create = Base + "/poctAdress";
    }
    public struct Service
    {
        public const string GetAll = Base + "/service";
        public const string Get = Base + "/service/{serviceId}";
        public const string Update = Base + "/service/{serviceId}";
        public const string Delete = Base + "/service/{serviceId}";
        public const string Create = Base + "/service";
    }
    public struct Setting
    {
        public const string GetAll = Base + "/setting";
        public const string Get = Base + "/setting/{settingId}";
        public const string Update = Base + "/setting/{settingId}";
        public const string Delete = Base + "/setting/{settingId}";
        public const string Create = Base + "/setting";
    }
    public struct Skill
    {
        public const string GetAll = Base + "/skill";
        public const string Get = Base + "/skill/{skillId}";
        public const string Update = Base + "/skill/{skillId}";
        public const string Delete = Base + "/skill/{skillId}";
        public const string Create = Base + "/skill";
    }
    public struct DeclareAdmin
    {
        public const string GetAll = Base + "/admin/declare";
        public const string Get = Base + "/admin/declare/{declareId}";
        public const string Delete = Base + "/admin/declare/{declarelId}";
        public const string Create = Base + "/admin/declare";
    }
    public struct OrderAdmin
    {
        public const string GetAll = Base + "/admin/order/GetAll";
        public const string Get = Base + "/admin/order/{orderId}";
        public const string Delete = Base + "/admin/order/{orderlId}";
        public const string Create = Base + "/admin/order";
    }
    public struct OrderUser
    {
        public const string GetAll = Base + "/user/order";
        public const string Get = Base + "/user/order/{orderId}";
        public const string Delete = Base + "/user/order/{orderlId}";
        public const string Create = Base + "/user/order";
    }
    public struct DeclareUser
    {
        public const string GetAll = Base + "/user/declare";
        public const string Get = Base + "/user/declare/{declareId}";
        public const string Delete = Base + "/user/declare/{declarelId}";
        public const string Create = Base + "/user/declare";
    }
    public struct CommitmentAdmin
    {
        public const string GetAll = Base + "/admin/GetAll";
        public const string Delete = Base + "/admin/commitment/{commitmentId}";
        public const string Create = Base + "/admin/commitment";
    }
    public struct CommitmentUser
    {
        public const string GetAll = Base + "/user/GetAll";
        public const string Delete = Base + "/user/commitment/{commitmentId}";
        public const string Create = Base + "/user/commitment";
    }
    public struct AppealAdmin
    {
        public const string GetAll = Base + "/admin/appealGetAll";
    }
    public struct AppealUser
    {
        public const string Create = Base + "/user/appeal";
        public const string GetAll = Base + "/user/appealGetAll";

    }

    public struct Authentication
    {
        public const string Register = Base + "/admin/register";
        public const string Login = Base + "/admin/login";
        public const string ForgetPassword = Base + "/admin/forgetPassword";
        public const string ResetPassword = Base + "/admin/resetPassword";
        public const string Verify = Base + "/admin/verify";
        public const string UpdateInformation = Base + "/admin/updateInformation";

    }
    public struct AuthenticationClient
    {
        public const string Register = Base + "/register";
        public const string LoginUser = Base + "/admin/loginUser";
        public const string ForgetPassword = Base + "/forgetPassword";
        public const string ResetPassword = Base + "/resetPassword";
        public const string Verify = Base + "/verify";
        public const string UpdateInformation = Base + "/updateInformation";

    }

    public struct File
    {
        public const string GetFileByName = Base + "/getFile/{fileName}";
    }
}

