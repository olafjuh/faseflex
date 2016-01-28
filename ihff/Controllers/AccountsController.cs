using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Models;
using System.Web.Security;
using System.Security.Cryptography;
namespace ihff.Controllers

{

    public class AccountsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            Account logInAccount = (Account)Session["loggedin_account"];
            IEnumerable<Activity> activities = repository.GetActivities();
            return View(activities);
        }
        private DbRepository repository = new DbRepository();
        public ActionResult AddAccount()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult AddAccount(AddNewAccount accounts)
        {
            if (ModelState.IsValid)
            {
                string hashPasword = HashPassword.HashThePassword(accounts.Password);
                Account account = new Account(accounts.Id, accounts.FirstName, accounts.LastName, 
                    accounts.EmailAddress, hashPasword, accounts.AccesTo);
                repository.AddAccount(account);
                FormsAuthentication.SetAuthCookie(account.EmailAddress, false);
                Session["loggedin_account"] = account;
                return RedirectToAction("Index");
            }
            else
            {
                return View(accounts);
            }
        }
        [HttpPost]
        public ActionResult Login(LoginModel login_account)
        {
            if (ModelState.IsValid)
            {
                Account account = repository.GetAccount(login_account.EmailAddress, login_account.Password);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.EmailAddress, false);
                    Session["loggedin_account"] = account;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The username or password provided is incorrect");
                    return View("Login", login_account);
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Accounts");
        }
    }
}