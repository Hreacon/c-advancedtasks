using System.Collections.Generic;

namespace Todo.Objects
{
  public class Category
  {
    private int _id;
    private List<Task> _tasks;
    private string _name;
    private static List<Category> _categories = new List<Category>(){};

    public Category(string categoryName)
    {
      _name = categoryName;
      _id=_categories.Count;
      _categories.Add(this);
      _tasks = new List<Task>(){};
    }

    public /*Not Static*/ void StoreTask(Task newTask)
    {
      _tasks.Add(newTask);
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetName()
    {
      return _name;
    }

    public List<Task> GetTasks()
    {
      return _tasks;
    }

    public int GetId()
    {
      return _id;
    }

    public void DeleteTaskById(int id)
    {
      Task removeTask = null;
      foreach(Task task in _tasks)
      {
        if(task.GetId() == id)
          removeTask = task;
      }
      _tasks.Remove(removeTask);
      // removeTask.SetDescription("This has been changed");
    }

    public static List<Category> GetAll()
    {
      return _categories;
    }

    public static Category FindById(int ID)
    {
      Category realCategory = null;
      foreach (Category item in _categories)
      {
        if (item.GetId() == ID)
        {
          realCategory = item;
        }
      }
      return realCategory;
    }

    public static void RemoveCategoryById(int ID)
    {
      _categories.Remove(Category.FindById(ID));
    }
  }
}
