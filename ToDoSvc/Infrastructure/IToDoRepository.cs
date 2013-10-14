using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoSvc.Models;

namespace ToDoSvc.Infrastructure
{
  public interface IToDoRepository
  {
    IEnumerable<ToDoItem> Get();
    bool TryGet(int id, out ToDoItem toDoItem);
    ToDoItem Add(ToDoItem toDoItem);
    bool Delete(int id);
  }
}
