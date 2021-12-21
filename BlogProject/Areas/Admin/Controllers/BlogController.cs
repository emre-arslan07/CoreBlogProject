using BlogProject.Areas.Admin.Models;
using BlogProject.Dal.Concrete;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                //excel dosyasında ilk satır doludur yazmaya 2.satırdan başlar
                int BlogRowCount = 2;
                foreach (var item in GetBlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogTitle;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ExcelSheet1.xlsx");
                }
            }
        }
        //todo:mimari içine alınacak
        public List<BlogModel> GetBlogTitleList()
        {
            List<BlogModel> blogModels = new List<BlogModel>();
            using (var c = new BlogProjectDbContext())
            {
                blogModels = c.Blogs.Select(x => new BlogModel
                {
                    BlogID = x.BlogID,
                    BlogTitle = x.BlogTitle
                }).ToList();
                return blogModels;
            }
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
