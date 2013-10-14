using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using ToDoSvc.Infrastructure;
using WebApiContrib.IoC.Ninject;
using Ninject.Web.Mvc;



namespace ToDoSvc
{
  
  
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {

      IKernel kernel = new StandardKernel();
      kernel.Bind<IToDoRepository>().ToConstant(new SampleRepository());
      config.DependencyResolver = new NinjectResolver(kernel);

    

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
      // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
      // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
      //config.EnableQuerySupport();

      // To disable tracing in your application, please comment out or remove the following line of code
      // For more information, refer to: http://www.asp.net/web-api
      config.EnableSystemDiagnosticsTracing();
    }
  }
}
