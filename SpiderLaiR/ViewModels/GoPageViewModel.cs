using SpiderLaiR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderLaiR.ViewModels
{
    public class GoPageViewModel
    {
        public GoPageModel Model { get; set; }=new GoPageModel();

        public GoPageViewModel()
        {
            Model.Title = "123456";
        }
    }
}
