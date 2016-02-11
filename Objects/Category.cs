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

    public /*Not Static*/ void StoreTasks(Task newTask)
    {
      _tasks.Add(newTask);
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

    public static List<Category> GetAll()
    {
      return _categories;
    }

    public static Category FindById(int ID)
    {
      Category realCategory = new Category("Error");
      foreach (Category item in _categories)
      {
        if (item.GetId() == ID)
        {
          realCategory = item;
        }
      }
      return realCategory;
    }

  }
}
