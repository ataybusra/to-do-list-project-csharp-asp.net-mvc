using OrnekToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrnekToDoList.Controllers
{
	public class CompletedTaskController : Controller
	{
		// GET: CompletedTask
		public ActionResult CompletedTaskList()
		{
			Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities();
			ViewBag.List = dbo.tbl_todolist.Where(x => x.IsCompleted).ToList();
			return View();
		}
		[HttpPost]
		public ActionResult Delete(int Id)
		{
			Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities();
			tbl_todolist delete = dbo.tbl_todolist.FirstOrDefault(x => x.Id == Id);
			dbo.tbl_todolist.Remove(delete);
			dbo.SaveChanges();
			return RedirectToAction("CompletedTaskList");
		}
		public ActionResult Incomplete(int Id)
		{
			using (Dbo_ToDoListEntities dbo = new Dbo_ToDoListEntities())
			{
				tbl_todolist tasks = dbo.tbl_todolist.FirstOrDefault(x => x.Id == Id);

				if (tasks != null)
				{
					// IsCompleted değerini tersine çevir
					tasks.IsCompleted = !tasks.IsCompleted;
					dbo.SaveChanges();
				}
			}
			return RedirectToAction("CompletedTaskList");
		}

	}
}