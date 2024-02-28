using OrnekToDoList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ÖrnekToDoList.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult List()
		{
			Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities();
			ViewBag.Liste = dbo.tbl_todolist.Where(x => !x.IsCompleted).ToList();
			return View();
		}
		public ActionResult Create(tbl_todolist l)
		{
			Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities();
			dbo.tbl_todolist.Add(l);
			dbo.SaveChanges();
			return RedirectToAction("List");
		}
		[HttpPost]
		public ActionResult Edit(tbl_todolist d)
		{
			Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities();
			tbl_todolist update = dbo.tbl_todolist.FirstOrDefault(x => x.Id == d.Id);
			update.Title = d.Title;
			update.Description = d.Description;
			update.Date = d.Date;
			dbo.SaveChanges();
			return RedirectToAction("List");
		}
		public ActionResult Delete(int Id)
		{
			Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities();
			tbl_todolist delete = dbo.tbl_todolist.FirstOrDefault(x => x.Id == Id);
			dbo.tbl_todolist.Remove(delete);
			dbo.SaveChanges();
			return RedirectToAction("List");
		}
		public ActionResult Complete(int Id)
		{
			using (Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities())
			{
				tbl_todolist task = dbo.tbl_todolist.FirstOrDefault(x => x.Id == Id);

				if (task != null)
				{
					task.IsCompleted = !task.IsCompleted;
					dbo.SaveChanges();
				}
			}
			return RedirectToAction("List");
		}
	}
}
