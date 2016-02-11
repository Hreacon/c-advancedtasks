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

      Get["/category/{id}/edit"] = parameters => {
        Category editedCategory = Category.FindById(parameters.id);
        return View ["editCategory.cshtml", editedCategory];
      };

      Get["/category/{ID}"] = parameters =>  {

        return View ["viewCategory.cshtml", Category.FindById(parameters.ID)];
      };

      Get["/category/{ID}/deleteTask/{tID}"] = parameters => {
        // get the category
        Category currentCategory = Category.FindById(parameters.id);
        //find the task
        currentCategory.DeleteTaskById(parameters.tID);
        // and delete the task
        return View["viewCategory.cshtml", currentCategory];
      };

      Get["/category/{id}/delete"] = parameters => {
        Category.RemoveCategoryById(parameters.id);
        return View["viewCategories.cshtml", Category.GetAll()];
      };

      Post["/addCategory"] = _ => {
        string name = Request.Form["name"];
        Category newCategory = new Category(name);
        return View["viewCategories.cshtml", Category.GetAll()];
      };

      Post["/updateCategory"] = _ => {
        string name = Request.Form["name"];
        int id = Request.Form["categoryID"];
        Category categoryToUpdate = Category.FindById(id);
        categoryToUpdate.SetName(name);
        return View["viewCategory.cshtml", categoryToUpdate];
      };

      Post["/category/{ID}/addTask"] = parameters => {
        string description = Request.Form["description"];
        Task createdTask = new Task(description);
        Category correspondingCategory = Category.FindById(parameters.id);
        correspondingCategory.StoreTask(createdTask);
        return View ["viewCategory.cshtml", correspondingCategory];
      };

    }
  }
}

// views
// add category, view categories
// detail view for each category, with the ability to add tasks to the category

// functionality
// delete tasks that have been completed
// delete categories that have been completed
