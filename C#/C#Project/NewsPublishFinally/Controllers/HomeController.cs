using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPublishFinally.Models;

namespace NewsPublishFinally.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsRepository newsRepository;

        public HomeController(ILogger<HomeController> logger, NewsRepository newsRepository)
        {
            _logger = logger;
            this.newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //获取全部的新闻数据
        public IActionResult GetAllNews(int pages)
        {
            //获取新闻数据
            List<object> list = newsRepository.GetAllNews(pages);
            //获取页码
            ViewBag.Pages = (int[])list[1];
            //获取当前高亮显示的页码
            ViewBag.PageActive = (int)list[2];

            return View((List<Hashtable>)list[0]);
        }

        //获取一个分类的新闻数据
        public IActionResult GetClassNews(string cname)
        {
            List<Hashtable> result = newsRepository.GetClassNews(cname);
            ViewBag.pages = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            return View(result);
        }

        //获取新闻详情
        public IActionResult GetNewsContentAndComment(string title, int page)
        {
            List<object> result = newsRepository.GetNewsContentAndComment(title);
            ViewBag.Comment = result[1];
            ViewBag.page = page;
            ViewBag.pages = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            return View(result[0]);
        }

        //添加评论
        public IActionResult AddComment(NewsInfo news)
        {
            newsRepository.AddComment(news);
            //页面重定向
            //传入所需要的参数
            return RedirectToAction("GetNewsContentAndComment", new { title = news.title });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
