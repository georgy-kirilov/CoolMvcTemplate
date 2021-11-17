namespace CoolMvcTemplate.Web.Areas.Administration.Controllers
{
    using CoolMvcTemplate.Common;
    using CoolMvcTemplate.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
