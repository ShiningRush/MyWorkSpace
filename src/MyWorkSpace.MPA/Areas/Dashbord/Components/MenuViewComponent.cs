using Microsoft.AspNetCore.Mvc;
using MyWorkSpace.MPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkSpace.MPA.Areas.Dashbord.Components
{
    public class MenuViewComponent : ViewComponent
    {

        public MenuViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View("Menu",items);
        }
        private Task<List<MenuModel>> GetItemsAsync()
        {
            var menus = new List<MenuModel>()
            {
                new MenuModel()
                {
                    MenuText = "主页",
                    Url = "/Dashbord/Default/Index",
                    IconStr = "fa fa-dashboard fa-fw",
                },

                new MenuModel()
                {
                    MenuText = "图表",
                    Url = "#",
                    IconStr = "fa fa-bar-chart-o fa-fw",
                    ChildItem = new List<MenuModel>()
                    {
                        new MenuModel(){ MenuText = "Flot Charts", Url = "#",IconStr = "" },
                        new MenuModel(){ MenuText = "Morris.js Charts", Url = "#", IconStr = "" }
                    }
                },

                new MenuModel()
                {
                    MenuText = "列表",
                    Url = "/Dashbord/Default/Table",
                    IconStr = "fa fa-table fa-fw",
                },

                new MenuModel()
                {
                    MenuText = "输入框",
                    Url = "/Dashbord/Default/Form",
                    IconStr = "fa fa-edit fa-fw",
                },

                new MenuModel()
                {
                    MenuText = "交互控件",
                    Url = "#",
                    IconStr = "fa fa-wrench fa-fw",
                    ChildItem = new List<MenuModel>()
                    {
                        new MenuModel(){ MenuText = "面板", Url = "/Dashbord/Default/PanelsAndWells",IconStr = "" },
                        new MenuModel(){ MenuText = "按钮", Url = "/Dashbord/Default/Buttons",IconStr = "" },
                        new MenuModel(){ MenuText = "提示", Url = "/Dashbord/Default/Notifications",IconStr = "" },
                        new MenuModel(){ MenuText = "排版", Url = "/Dashbord/Default/Typography",IconStr = "" },
                        new MenuModel(){ MenuText = "图标", Url = "/Dashbord/Default/Icons",IconStr = "" },
                        new MenuModel(){ MenuText = "表格", Url = "/Dashbord/Default/Grid",IconStr = "" },
                    }
                },

                new MenuModel()
                {
                    MenuText = "展示页面",
                    Url = "#",
                    IconStr = "fa fa-wrench fa-fw",
                    ChildItem = new List<MenuModel>()
                    {
                        new MenuModel(){ MenuText = "Blank Page", Url = "#",IconStr = "" },
                        new MenuModel(){ MenuText = "Login Page", Url = "#",IconStr = "" },
                    }
                },
            };

            return Task.FromResult(menus);
        }
    }
}
