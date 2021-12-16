using BlogProject.Bll.Abstract;
using BlogProject.Bll.DependencyResolver.Ninject;
using BlogProject.Bll.ValidationRules;
using BlogProject.Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        public IActionResult Index(int page=1)
        {
            var values = _categoryService.GetAll().ToPagedList(page,3);
            return View(values);
        }
        public IActionResult UpdateCategoryStatus(int id)
        {
            var value = _categoryService.GetById(id);
            if (value.CategoryStatus==true)
            {
                value.CategoryStatus = false;
                _categoryService.Update(value);
            }
            else
            {
                value.CategoryStatus = true;
                _categoryService.Update(value);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(category);
            if (validationResult.IsValid)
            {
                category.CategoryStatus = true;
                _categoryService.Add(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
