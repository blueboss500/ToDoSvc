using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoSvc.Controllers;
using ToDoSvc.Infrastructure;
using ToDoSvc.Models;

namespace ToDoSvc.Tests.Controllers
{
  [TestClass]
  public class ToDoControllerTest
  {

    [TestMethod]
    public void Get()
    {
      // Arrange
      ToDoController controller = new ToDoController(new SampleRepository());

      // Act
      IEnumerable<ToDoItem> result = controller.Get();

      // Assert
      Assert.IsNotNull(result);
      Assert.IsTrue(result.Count() > 0);
    }

    [TestMethod]
    public void GetById()
    {
      // Arrange
      ToDoController controller = new ToDoController(new SampleRepository());

      // Act
      ToDoItem result = controller.Get(0);

      // Assert
      Assert.AreEqual("Wash the car.", result.Desc);
    }

    [TestMethod]
    public void Post()
    {
      // Arrange
      //ToDoController controller = new ToDoController(new SampleRepository());

     
      //var request = new HttpRequest("", "http://example.com/", "");
      //var response = new HttpResponse(TextWriter.Null);
      //var httpContext = new HttpContextWrapper(new HttpContext(request, response));
      //controller.ControllerContext = new ControllerContext(httpContext, new RouteData(),controller);


      //// Act
      //ToDoItem item = new ToDoItem(){ID = 5, Desc = "New Item"};
      //controller.Post(item);
      //ToDoItem result = controller.Get(5);

      //// Assert
      //Assert.AreEqual("New Item", result.Desc);
    }



    [TestMethod]
    public void Delete()
    {
      // Arrange
      ToDoController controller = new ToDoController(new SampleRepository());

      // Act
      controller.Delete(0);
      try
      {
        ToDoItem result = controller.Get(0);
      }
      catch (HttpResponseException e)
      {
        Assert.IsTrue(true);
        return;

      }
      // Assert
      Assert.IsTrue(false);
    }
  }
}
