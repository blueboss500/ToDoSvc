using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoSvc.Models;

namespace ToDoSvc.Infrastructure
{
  public class SampleRepository:IToDoRepository
  {
    //member vars
    private int m_nextID = 0;
    private Dictionary<int,ToDoItem> m_Items = new Dictionary<int,ToDoItem>(); 

    //constructor
    public SampleRepository()
    {
      Add(new ToDoItem("Wash the car."));
      Add(new ToDoItem("Mow the lawn"));
      Add(new ToDoItem("Return books back to library"));
    }

    //interface implementations
    public IEnumerable<ToDoItem> Get()
    {
      return m_Items.Values.OrderBy(i => i.ID);
    }

    public bool TryGet(int id, out ToDoItem toDoItem)
    {
      return m_Items.TryGetValue(id, out toDoItem);
    }

    public ToDoItem Add(ToDoItem toDoItem)
    {
      toDoItem.ID = m_nextID++;
      m_Items[toDoItem.ID] = toDoItem;
      return toDoItem;
    }

    public bool Delete(int id)
    {
      return m_Items.Remove(id);
    }
  }
}