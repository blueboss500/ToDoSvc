using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoSvc.Infrastructure;
using ToDoSvc.Models;

namespace ToDoSvc.Controllers
{
  public class ToDoController : ApiController
  {
    //member vars
    private IToDoRepository m_Repository;

    //constr
    public ToDoController(IToDoRepository repository)
    {
      this.m_Repository = repository;
    }

    // GET api/todo
    [Queryable]
    public IQueryable<ToDoItem> Get()
    {
      return m_Repository.Get().AsQueryable();
    }

    // GET api/todo/5
    public ToDoItem Get(int id)
    {
      ToDoItem item;
      if (!m_Repository.TryGet(id, out item))
      {
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
      }
      return item;
    }

    // POST api/todo
    public HttpResponseMessage Post(ToDoItem item)
    {
      item = m_Repository.Add(item);
      var response = Request.CreateResponse<ToDoItem>(HttpStatusCode.Created, item);
      response.Headers.Location = new Uri(Request.RequestUri, "/api/todo/" + item.ID.ToString());
      return response;
    }

  

    // DELETE api/todo/5
    public ToDoItem Delete(int id)
    {
      ToDoItem item;
      if (!m_Repository.TryGet(id, out item))
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
      m_Repository.Delete(id);
      return item;
    }
  }
}
