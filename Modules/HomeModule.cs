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
        return View["viewCategories.cshtml", Category.GetAll()];
      };

      Get["/category/{ID}"] = parameters =>  {

        return View ["viewCategory.cshtml", Category.FindById(parameters.ID)];
      };

      Post["/addCategory"] = _ => {
        string name = Request.Form["name"];
        Category newCategory = new Category(name);
        return View["viewCategories.cshtml", Category.GetAll()];
      };

      Post["/category/{ID}/addTask"] = parameters => {
        string description = Request.Form["description"];
        Task createdTask = new Task(description);
        Category correspondingCategory = Category.FindById(parameters.id);
        correspondingCategory.StoreTask(createdTask);
        return View ["viewCategory.cshtml", correspondingCategory];
      };
      Get["/category/{ID}/deleteTask"] = parameters => {
        
      }

    }
  }
}

// views
// add category, view categories
// detail view for each category, with the ability to add tasks to the category

// functionality
// delete tasks that have been completed
// delete categories that have been completed
