﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projectF.Data;
using projectF.Models;
using System.Dynamic;
using System.Reflection;
using static projectF.Models.Employee;

namespace projectF.Controllers
{
   

    public class servicesController : Controller
    {
		private ApplicationDBcontext db;
        private IWebHostEnvironment _environment;
        private List<string> imageType=new List<string>() {"jpg","jpeg","png","gif"};
		public servicesController(ApplicationDBcontext db, IWebHostEnvironment _environment)
		{
			this.db = db;
            this._environment = _environment;
		}

		//list to work on
		public List<Employee> employees = new List<Employee>() { new Employee()
        {
            employeeID = 123,
                Email = "mm@mosher.com",
                age = 25,
                employeeimage = null,
                employeeName = "mona",
               // gender = "female",
                password = "2555",
                salary = 10000,
                state="Admin"
                },
             new Employee()
        {
            employeeID = 1,
                Email = "mm@mosher.com",
                age = 25,
                employeeimage = null,
                employeeName = "mona",
               // gender = "female",
                password = "2555",
                salary = 10000,
                 state="Employee"
                },
             new Employee()
        {
            employeeID = 1,
                Email = "mm@mosher.com",
                age = 25,
                employeeimage = null,
                employeeName = "mona",
               // gender = "female",
                password = "2555",
                salary = 10000
                }
         };
        public List<client> clients = new List<client>() { 
        new client()
        {
            clientID = 1,
            clientName="karem atea",
            operationID=123,
            operationName="ship"
            
        },
         new client()
        {
            clientID = 2,
            clientName="keroles atea",
            operationID=213,
            operationName="maintenance"
        },
           new client()
        {
            clientID = 3,
            clientName="katren atea",
            operationID=321,
            operationName="maintenance"
        }
        };
		
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult profile()
        { 
            var item = db.Employees.FirstOrDefault(x=>x.Email==HttpContext.Session.GetString("em"));
            return View(item); 
        }
        public IActionResult client()
        {
           
            IEnumerable<client> clients = db.clients.ToList();
			return View(clients);
        }
       
        public IActionResult operation()
        {
			IEnumerable<operations> operationss = db.operations.ToList();
			return View(operationss);
        }
        public IActionResult finance() 
        {
            IEnumerable<finance> finances = db.finances.ToList();
            return View(finances);
            
        }
        public IActionResult ToDoList()
        {
            HttpContext.Session.SetString("emp", "employee");
            string y = HttpContext.Session.GetString("em");
            var item = db.Employees.FirstOrDefault(x=>x.Email==y);
            List<to_do_list> to_do_list = db.to_do_list.Where(x=>x.employeeID==item.employeeID).ToList();
            return View(to_do_list);
        }
        //start
        //[HttpPost]
        //public IActionResult ToDoList(IFormCollection frm)
        //{
        //    ViewBag.id = int.Parse(frm["id"]);
        //    int y = ViewBag.id;
        //    var item = db.to_do_list.FirstOrDefault(x => x.taskID == y);
        //    if (frm["check"] == "Submit")
        //        item.state = true;
        //    //HttpContext.Session.SetString("emp", "employee");
        //    //string y = HttpContext.Session.GetString("em");
        //    //var item = db.Employees.FirstOrDefault(x => x.Email == y);
        //    //IEnumerable<to_do_list> to_do_list = db.to_do_list.Where(x => x.employeeID == item.employeeID).ToList();
        //    //return View(to_do_list);
        //    return View();
        //}
        public IActionResult Employee() 

        {
            IEnumerable<Employee> employees = db.Employees.ToList();
			return View(employees);  
        }
        public IActionResult History() 
        { 
            IEnumerable<History> historys = db.history.ToList();
            return View(historys);
        }
		public IActionResult EmpFinance()
		{
            IEnumerable<finance> finances = db.finances.ToList();
            return View(finances);
		}
        public IActionResult empHistory()
        {
			IEnumerable<History> historys = db.history.ToList();
			return View(historys);
			
        }
        public IActionResult ADToDoList()
        {
            HttpContext.Session.SetInt32("id", 0);
            dynamic model=new ExpandoObject();
            IEnumerable<to_do_list> to_do_list = db.to_do_list.ToList();
            model.to = to_do_list;
            IEnumerable<Employee>employee=db.Employees.ToList();
            model.employee = employee;

            return View(to_do_list);
			
        }
        public IActionResult detailsforEmoployee(int id)
        {
            var emp = db.Employees.Find(id);
            return View(emp);
        }
        //[HttpPost]
        //public IActionResult detailsforEmoployee(int id)
        //{
            
        //}
        public IActionResult empClient()
        {
			IEnumerable<client> clients = db.clients.ToList();
			return View(clients);
		}
        //
        public IActionResult addclient()
        {
            var id=db.operations.Select(x=>x.operationsID).ToList();
            ViewBag.operationID = id;
            return View(new client());
        }
        [HttpPost]
		public IActionResult addclient(client x)
		{
            db.clients.Add(x);
            db.SaveChanges();  
			return RedirectToAction("client");
		}
        public IActionResult addtodolist()
        {
            List<int> id = new List<int>();
            id = db.Employees.Where(x=>x.state=="Employee").Select(x => x.employeeID).ToList();
            ViewBag.employeeID = id;
            return View (new to_do_list());
        }
        [HttpPost]
        public IActionResult addtodolist(to_do_list x)
        {
			db.to_do_list.Add(x);
			db.SaveChanges();
			return RedirectToAction("ADToDoList");
		}
        public IActionResult addNewHistory()
        {
            //var id= (from emp in db.Employees
            //         select new { emp.employeeID, emp.employeeName }); 

            List<int> id = new List<int>();
            id = db.Employees.Where(x => x.state == "Employee").Select(x => x.employeeID).ToList();
            ViewBag.employeeID = id;

            id = db.operations.Select(x => x.operationsID).ToList();
            ViewBag.operationID = id;
            id=db.operations.Select(x=>x.clientID).ToList();
            ViewBag.clientID=id;
var ope = db.operations.ToList();
            TempData["operation"] = db.operations.ToList();
            //return View(new History());
            return View();
        }
        [HttpPost]
        public IActionResult addNewHistory(History x)
        {
            
            db.history.Add(x);
            db.SaveChanges();
            return RedirectToAction("History");
        }
		public IActionResult addOperation()
		{
            List<int> id = new List<int>();
            id = db.clients.Select(x => x.clientID).ToList();
            ViewBag.clientID = id;
            id = db.finances.Select(x => x.financeID).ToList();
            ViewBag.finance = id;
            return View(new operations());
		}
		[HttpPost]
		public IActionResult addOperation(operations x)
		{
            List<int> id = new List<int>();
            id = db.clients.Select(x => x.clientID).ToList();

            //ViewBag.clientID = id;
            db.operations.Add(x);
			db.SaveChanges();
			return RedirectToAction("operation");
		}
		public IActionResult addEmployee()
        {
            return View(new Employee());
        }
        [HttpPost]
        public async Task<IActionResult> addEmployee(Employee e,IFormFile img_file)
            {
            string path = Path.Combine(_environment.WebRootPath, "photo"); // wwwroot/photo/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            { 
                List<string> x=img_file.FileName.Split(".").ToList();
                var last=x.Last();
                bool s = false;
                foreach(var y in imageType)
                {
                    if (last == y)
                    { s = true;
                        break;
                    }

                }
                if(s)
                {


					path = Path.Combine(path, img_file.FileName); // for exmple : /photo/Photoname.png
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await img_file.CopyToAsync(stream);
					}
					e.employeeimage = img_file.FileName;
				}
				else
				{
					e.employeeimage = "default.jpg"; // to save the default image path in database.
				}
				try
				{
                    //e.Email = (string)(e.Email).Concat("@mosher.com");
                    string xx = e.Email;

                    e.Email = xx + "@mosher.com";
                    db.Add(e);
					db.SaveChanges();
					login log = new login();
					log.email = e.Email;
					log.password = e.password;
					log.state = e.state;
					db.Add(log);
					db.SaveChanges();


					return RedirectToAction("Employee");
				}
				catch (Exception ex) { ViewBag.exc = ex.Message; }
			}
            //    path = Path.Combine(path, img_file.FileName); // for exmple : /photo/Photoname.png
            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        await img_file.CopyToAsync(stream);
            //    }
            //  e.employeeimage = img_file.FileName;
            //}
            //else
            //{
            //    e.employeeimage = "default.jpg"; // to save the default image path in database.
            //}
            //try
            //{
            //    // e.Email =(string) (e.Email).Concat("@mosher.com");
            //    //var x = e.Email;
            //    //x = (string)x.Concat("@mosher.com");
            //    //e.Email = x;
            //    db.Add(e);
            //    db.SaveChanges();
            //    login log=new login();
            //    log.email = e.Email;
            //    log.password = e.password;
            //    log.state= e.state;
            //    db.Add(log);
            //    db.SaveChanges();
             

            //    return RedirectToAction("Employee");
            //}
            //catch (Exception ex) { ViewBag.exc = ex.Message; }
            return View();
        }
            //db.Employees.Add(e);
            //db.SaveChanges();
        public IActionResult addFinance()
        {
            List<int> id = new List<int>();
            id = db.operations.Select(x => x.operationsID).ToList();
            ViewBag.id = id;
            return View(new finance());
        }
        [HttpPost]
        public IActionResult addFinance(finance f)
        {
            f.maintenanceAmount = f.operationAmount * 0.15;
            f.taxes = f.operationAmount * 0.30;
            db.finances.Add(f);
            db.SaveChanges();
            return RedirectToAction("finance");
        }
        //
        public IActionResult Deleteclient(int id)
        {
            var client1=db.clients.Find(id);
            return View(client1);
        }
        [HttpPost]
        public IActionResult Deleteclient(client client1)
        { db.clients.Remove(client1);
        db.SaveChanges();
            return RedirectToAction("client");
        }
        public IActionResult DeleteHistory(int id)
        {
            var history1=db.history.Find(id);
            return View(history1);
        }
        [HttpPost]
        public IActionResult DeleteHistory(History history1)
        {
            db.history.Remove(history1);
            db.SaveChanges();
            return RedirectToAction("History");
        }
        public IActionResult DeleteTodolist(int id)
        {
            var todolist1 = db.to_do_list.FirstOrDefault(x=>x.taskID==id);
            return View(todolist1);
        }
        [HttpPost]
        public IActionResult DeleteTodolist(to_do_list todolist1)
        {
            db.to_do_list.Remove(todolist1);
            db.SaveChanges();
            return RedirectToAction("ADToDoList");
        }
        public IActionResult DeleteFinance(int id)
        {
            var finance1 = db.finances.Find(id);
            return View(finance1);
        }
        [HttpPost]
        public IActionResult DeleteFinance(finance finance1)
        {
            db.finances.Remove(finance1);
            db.SaveChanges();
            return RedirectToAction("finance");
        }
        public IActionResult DeleteOperation(int id)
        {
            var operation1=db.operations.Find(id);
            return View(operation1);
        }
        [HttpPost]
        public IActionResult DeleteOperation(operations operation1)
        {
            db.operations.Remove(operation1);
            db.SaveChanges();
            return RedirectToAction("operation");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var employee1 = db.Employees.Find(id);
            return View(employee1);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee1)
        {
            
            login l = db.login.Find(employee1.Email);
            
            db.Employees.Remove(employee1);
            if (l!=null)
            {
                db.login.Remove(l);
            }
            
            db.SaveChanges();
            return RedirectToAction("Employee");
        }
        public IActionResult EditEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            TempData["email"] = employee.Email;
            if (employee == null)
            {
                return new NoContentResult();
            }
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(IFormCollection frm, IFormFile image)

        {
            Employee employee = new Employee();
            employee.employeeID = int.Parse(frm["id"]);

            string path = Path.Combine(_environment.WebRootPath, "photo"); // wwwroot/photo/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (image != null)
            {
                List<string> x = image.FileName.Split(".").ToList();
                var last = x.Last();
                bool s = false;
                foreach (var y in imageType)
                {
                    if (last == y)
                    {
                        s = true;
                        break;
                    }

                }
                if (s)
                {


                    path = Path.Combine(path, image.FileName); // for exmple : /photo/Photoname.png
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    employee.employeeimage = image.FileName;

                }
                else
                {
                    employee.employeeimage = "default.jpg"; // to save the default image path in database.
                }
                try
                {
                    //e.Email = (string)(e.Email).Concat("@mosher.com");

                    //employee.employeeimage = (string)frm["image"];




                    employee.Email = (string)frm["email"];
                    employee.state = (string)frm["state"];
                    employee.age = int.Parse(frm["age"]);
                    employee.employeeName = (string)frm["emp"];
                    employee.salary = float.Parse(frm["salary"]);
                    employee.password = (string)frm["pass"];
                    db.Employees.Update(employee);
                    db.SaveChanges();
                    //login l2 = db.login.FirstOrDefault(x => x.password == employee.password);
                    //l2.email = employee.Email;
                    //l2.password = employee.password;
                    //l2.state = employee.state;
                    //db.login.Update(l2);
                    //db.SaveChanges();






                    //return RedirectToAction("Employee");
                }
                catch (Exception ex) { ViewBag.exc = ex.Message; }
            }


            //employee.Email = (string)frm["email"];
            //employee.state = (string)frm["state"];
            //employee.age = int.Parse(frm["age"]);
            //employee.employeeName = (string)frm["emp"];
            //employee.salary = float.Parse(frm["salary"]);
            //employee.password = (string)frm["pass"];


            //db.Employees.Update(employee);
            //db.SaveChanges();
            string email = (string)TempData["email"];
            login l = db.login.FirstOrDefault(x=>x.email==email);
            l.email = (string)frm["email"];
            l.password = (string)frm["pass"];
            l.state = (string)frm["state"];
            db.login.Update(l);
            db.SaveChanges();


            //         db.Employees.Remove(employee);
            //db.Employees.Add(employee);
            //         db.SaveChanges();
            return RedirectToAction("Employee");
		}
        public IActionResult EditFinance(int id )
        {
			var finance = db.finances.Find(id);
            List<int> opeid = new List<int>();
            opeid = db.operations.Select(x => x.operationsID).ToList();
            ViewBag.id = opeid;
            if (finance == null)
			{
				return new NoContentResult();
			}
			return View(finance);
		}
        [HttpPost]
		public IActionResult EditFinance(IFormCollection frm)
		{
			finance finaces = new finance();
			finaces.financeID = int.Parse(frm["id"]);
			finaces.operationID = int.Parse(frm["operationID"]);
			finaces.operationAmount = double.Parse(frm["opeamount"]);
			finaces.totalAmount = double.Parse(frm["totalamount"]);
            finaces.taxes = finaces.operationAmount * 0.30;
            finaces.maintenanceAmount = finaces.operationAmount * 0.15;
            //finaces.taxes = double.Parse(frm["taxes"]);
            finaces.state = (string) frm["state"];
			//finaces.maintenanceAmount= double.Parse(frm["mainamount"]);
			db.finances.Update(finaces);
			db.SaveChanges();
			//         db.Employees.Remove(employee);
			//db.Employees.Add(employee);
			//         db.SaveChanges();
			return RedirectToAction("finance");
		}
	}
}
