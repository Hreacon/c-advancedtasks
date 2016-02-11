using Nancy;
using Todo.Objects;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["add_new_task.cshtml"];
      };
      Get["/view_all_tasks"] = _ => {
        List<string> allTasks = Task.GetAll();
        return View["view-all-tasks.cshtml", allTasks];
      };
      Post["/tasks_cleared"]  = _ => {
        Task.ClearAll();
        return View["tasks_cleared.cshtml"];
      };
      Post["/task_added"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        newTask.Save();
        List<string> allTasks = Task.GetAll();
        return View["view-all-tasks.cshtml", allTasks];
      };
    }
  }
}
