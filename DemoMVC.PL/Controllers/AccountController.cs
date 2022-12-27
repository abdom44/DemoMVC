using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.PL.Controllers
{
    public class AccountController : Controller
    {



        #region Registration (Sign Up)


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }



        #endregion



        #region Login (Sign IN)

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        #endregion


        #region Sign Out


        #endregion


        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }


        #endregion



        #region Reset Password


        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }


        #endregion
    }
}
