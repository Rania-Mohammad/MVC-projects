using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using projectF.Data;
using projectF.Models;
using static System.Net.WebRequestMethods;
namespace projectF.Controllers
{
	public class WelcomeController : Controller
	{
		private ApplicationDBcontext db;
        private const string SessionKeyEmail = "email";
        private const string SessionKeyPassword = "password";
		private const string SessionKeyState = "state";
        public string SessionKeyRem = "yes";
        //,Microsoft.AspNetCore.Http.HttpContext context
        public WelcomeController(ApplicationDBcontext db)
		{
			this.db = db;
            //context.Session.SetString(SessionKeyEmail, "");
            //context.Session.SetString(SessionKeyPassword,"");
            //context.Session.SetString(SessionKeyState, "");
        }
		public IActionResult Index()
		{
            // HttpContext.Session.GetString(SessionKeyState);
            //if (HttpContext.Session.GetString(SessionKeyRem) != null)
            //{
            //    TempData["x"] = HttpContext.Session.GetString(SessionKeyRem);
            //}
            //HttpContext.Session.SetString("email", "");
            //HttpContext.Session.SetString("phone", "");
            //var model = HttpContext.Session.GetString(SessionKeyState);

            //return View(model);
            //if (!Request.Cookies.TryGetValue("state", out string state))
            //{
            //    return RedirectToAction("login");
            //}

            //return View("Profile", state);
            //if (Request.Cookies.TryGetValue("state", out string state))
            //return View(state); 

            //if (HttpContext.Session.GetString(SessionKeyState) != null)
            //{
            //    var x = HttpContext.Session.GetString(SessionKeyState);
            //    TempData["x"] = x;

            //}
          
            return View();
		}
		[HttpPost]
		public IActionResult Index(IFormCollection fr)
		{
            //if ((string)fr["owner"] == "Admin")
            //	TempData["type"] = (string)fr["owner"];
            //else if ((string)fr["employee"] == "Employee")
            //	TempData["type"] = (string)fr["employee"];
            //if (!Request.Cookies.TryGetValue("state", out string state))
            //{
            //    return RedirectToAction("login");
            //}
           
            if (HttpContext.Session.GetString(SessionKeyEmail) != null || HttpContext.Session.GetString(SessionKeyState) != null)
            {
                //TempData[SessionKeyState] = HttpContext.Session.GetString(SessionKeyState);
               
                return RedirectToAction("home");
            }
              

                return RedirectToAction("login");
            //return RedirectToAction("login");
           
		}
		public IActionResult login()
		{
            //List<login> los = new List<login>();
            //los = db.login.ToList();
            // ViewBag.err = "Invalid E-mail or Password";
            //var model = new login();

            //if (HttpContext.Session.GetString(SessionKeyEmail) != null)
            //{
            //    model.email = HttpContext.Session.GetString(SessionKeyEmail);
            //    model.Remember = true;
            //}
            //return View(model);
            TempData["errmsg"] = "There is something wrong with your email or password";
            return View();
		}
		[HttpPost]
		public IActionResult login(IFormCollection frm,login model)
		{
            //HttpContext.Session.SetString("mm", (string)frm["state"]);
            var log = db.login.FirstOrDefault(x=>x.email==(string)frm["email"]);
			TempData["st"] = frm["state"].ToString();
            if (frm["submit"]== "Submit")
            {
                HttpContext.Session.SetString("email", (string)frm["remail"]);
                HttpContext.Session.SetString("phone", (string)frm["Phone"]);
                var x = db.login.FirstOrDefault(x=>x.email==HttpContext.Session.GetString("email"));
                forgetData f = new forgetData();
                f.Email = HttpContext.Session.GetString("email");
                f.PhoneNumber = HttpContext.Session.GetString("phone");
                f.IsEmailConfirmed = true;
                f.password = x.password;
                db.forgetDatas.Add(f);
                db.SaveChanges();
            }
            if (log != null)
			{
				
				

				if (log.email != (string)frm["email"] || log.password != (string)frm["password"]||(log.email != (string)frm["email"]&& log.password != (string)frm["password"]) || log.state != (string)frm["state"])
                {
					//if (model.e == "user" && model.Password == "pass")
					//{
					//	HttpContext.Session.SetString(SessionKeyEmail, model.email);
					//	HttpContext.Session.SetString(SessionKeyPassword, model.password);
					//HttpContext.Session.SetString(SessionKeyState, model.state);


					//               if (model.Remember)
					//	{
					//		var options = new CookieOptions
					//		{
					//			Expires = System.DateTimeOffset.Now.AddDays(7),
					//			HttpOnly = true,
					//			Secure = true
					//		};
					//		Response.Cookies.Append("email", model.email, options);
					//	}
					//	else
					//	{
					//		Response.Cookies.Delete("email");
					//	}

					//return RedirectToAction("home");
					//}
					//else
					//{
					//	ModelState.AddModelError(string.Empty, "Invalid username or password");
					//}
					//ViewBag.check = false;
					//return View(ViewBag.check);
					//return RedirectToAction("Error");
					TempData["errmsg"] = "There is something wrong with your email or password";
                    ViewBag.err = false;
                    return View();
					//ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
				else
				{
                    //ModelState.AddModelError(string.Empty, "Invalid username or password");
                    //return RedirectToAction("Error");
                    //ModelState.AddModelError(string.Empty, "Invalid username or password");

                    HttpContext.Session.SetString("em", (string)frm["email"]);
                   
                    var item2 = db.Employees.FirstOrDefault(x => x.Email == HttpContext.Session.GetString("em"));
					HttpContext.Session.SetString("name", item2.employeeName);
                   
                    if (frm["remember"] == "on")
                    {
                        //HttpContext.Session.SetString(SessionKeyEmail, (string)frm["email"]);
                        HttpContext.Session.SetString(SessionKeyPassword, (string)frm["password"]);
                        HttpContext.Session.SetString(SessionKeyEmail, (string)frm["email"]);
                        HttpContext.Session.SetString(SessionKeyState, (string)frm["state"]);
                        
                        //HttpContext.Session.SetString(SessionKeyState, (string)frm["state"]);

                        //HttpContext.Session.SetString(SessionKeyRem, "true");
                        var item = db.Employees.FirstOrDefault(x => x.Email == HttpContext.Session.GetString("email"));
						HttpContext.Session.SetString("name", item.employeeName);
					}
					
					//if (model.Remember)
					//{
					//    var options = new CookieOptions
					//    {
					//        Expires = System.DateTimeOffset.Now.AddDays(7),
					//        HttpOnly = true,
					//        Secure = true
					//    };
					//    Response.Cookies.Append("state", model.state, options);
					//}
					//else
					//{
					//    Response.Cookies.Delete("email");
					//}

					return RedirectToAction("home");
                }
				
			}
			else
			{

				//ViewBag.check = false;
				//return View(ViewBag.check);
				ModelState.AddModelError(string.Empty, "Invalid username or password");
			}

            //if ()
            //{
            //	//if (log.state == (string)frm["state"])
            //	//{
            //	//	//ViewBag.state=log.state;
            //	//	ViewData["state"] = (string)frm["state"];
            //	//}
            //}
            //else
            //	ViewBag.error = "Wrong Data";

            return View();
        }
        public IActionResult home()
        {
            //string xx = HttpContext.Session.GetString("sta");
            //HttpContext.Session.SetString("mm", TempData["st"].ToString());
           
            if (HttpContext.Session.GetString(SessionKeyState) != null)
            {
                
                TempData["st"] = HttpContext.Session.GetString(SessionKeyState);
               
            }
            else
            {
                TempData["st"]= HttpContext.Session.GetString("mm");
            }
            //else
            //{
            //    TempData["st"] = "bb";
            //}
            List<forgetData> list = db.forgetDatas.Where(x => x.IsEmailConfirmed == true).ToList();
            ViewBag.count=list.Count;   
            HttpContext.Session.SetInt32("count", list.Count);

            return View();
		}
		//[NonAction]
		//public IActionResult check(bool check)
		//{
		//	ViewBag.check= check;
		//	return View("login");
		//}

		
		public IActionResult Logout()
		{
            //HttpContext.Session.Remove(SessionKeyEmail);
            //HttpContext.Session.Remove(SessionKeyPassword);
            //HttpContext.Session.Remove(SessionKeyState);
            HttpContext.Session.Clear();
            //HttpContext.Session.Set(SessionKeyEmail, null);
            //HttpContext.Session.Set(SessionKeyState, null);
            //HttpContext.Session.Set(SessionKeyPassword, null);
            //TempData["st"] = null;

            return RedirectToAction("index");
		}
        public IActionResult forgetPass()
        {
            IEnumerable<forgetData> forget = db.forgetDatas.Where(x => x.IsEmailConfirmed == true).ToList();

            return View(forget);  
        }
        public IActionResult EditPass(int id)
        {

            //var list = db.forgetDatas.Find(id);
            //bool x = true;
            var list = db.forgetDatas.Find(id);
            if (list == null)
            {
                return new NoContentResult();
            }            
            return View(list);
        }
        [HttpPost]
        public IActionResult EditPass(forgetData f)
        {
            List<Employee> list = db.Employees.Where(x => x.Email == f.Email).ToList();
            list[0].password = f.password;
            var obg = db.login.FirstOrDefault(x => x.email == f.Email);
            obg.password=f.password;
            db.login.Update(obg);
            db.Employees.Update(list[0]);
            db.forgetDatas.Update(f); 
            db.SaveChanges();
            //         db.Employees.Remove(employee);
            //db.Employees.Add(employee);
            //         db.SaveChanges();
            return RedirectToAction("forgetPass");
        }
        public IActionResult notification() {
            ViewBag.email=HttpContext.Session.GetString("email");
            ViewBag.phone = HttpContext.Session.GetString("phone");
            return View();        }
	}
}
