using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoSvc.Models
{
  public class ToDoItem
  {


    //const
    public ToDoItem()
    {
    }

    public ToDoItem(string desc)
    {
      Desc = desc;
    }

    //member vars
    

    //properies
   
    public int ID { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Description is too long, 100 char max.")]
    public string Desc { get; set; }

    //helpers


    //methods
  }
}