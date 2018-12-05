using ShoppingCartDemo.Models;
using ShoppingCartDemo.Models.HtmlHelpers;
using ShoppingCartDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShoppingCartDemo.Models.ViewModel;

namespace ShoppingCartDemo.Controllers
{
    public class AdminCrudController : Controller
    {
        IApplicationDbContext _productRepo;
        private int _PageSize;

        public AdminCrudController(IApplicationDbContext productRepo, int pageSize = 12)
        {
            _productRepo = productRepo;
            _PageSize = pageSize;
        }

        // GET: AdminCrud
        public ActionResult Index(string category, int page = 1)
        {
            var currentCategory = _productRepo.Categories.SingleOrDefault(c => c.Name == category);

            if (category != null && currentCategory == null)
            {
                return View("Index");
            }

            var productList = new ProductListViewModel
            {
                Products = _productRepo.Products
                .Where(p => category == null || p.CategoryId == _productRepo.Categories.FirstOrDefault(c => c.Name == category).Id)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * _PageSize)
                .Take(_PageSize),

                PagingInfo = new Pagination
                {
                    CurrentPage = page,
                    ItemsPerPage = _PageSize,
                    TotalItems = category == null ?
                    _productRepo.Products.Count() :
                    _productRepo.Products.Where(p => p.CategoryId == currentCategory.Id).Count()
                },

                CurrentCategory = currentCategory?.Name
            };
            var test = productList.Products.Count();
            return View(productList);
        }

        public ActionResult Edit(int Id)
        {
           
            var product = _productRepo.Products.Include(p => p.Category).Include(p => p.Image)
                .FirstOrDefault(p => p.Id == Id);

            if(product == null)
            {
                return HttpNotFound();
            }

            var productViewModel = new ProductViewModel(product)
            {
                Categories = _productRepo.Categories.ToList()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel product, HttpPostedFileBase Image = null)
        {
            if (ModelState.IsValid)
            {
                Product productDto = product.ConvertToProduct();

                if (Image != null)
                {
                    productDto.Image.ImageType = Image.ContentType;
                    productDto.Image.ImageData = new byte[Image.ContentLength];
                    Image.InputStream.Read(productDto.Image.ImageData, 0, Image.ContentLength);
                }
                _productRepo.SaveProduct(productDto);
                TempData["message"] = string.Format("{0} has beed edited succesfully", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                product.Categories = _productRepo.Categories.ToList();
                return View(product);
            }        
        }

        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel()
            {
                Categories = _productRepo.Categories.ToList()
            };

            return View("edit", productViewModel);
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _productRepo.DeleteProduct(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _productRepo.Products.Include(p => p.Category).Include(p => p.Image)
                .SingleOrDefault(p => p.Id == Id);
            
            var productViewModel = new ProductViewModel(product)
            {
                Categories = _productRepo.Categories.ToList()
            };

            return View(productViewModel);
        }
    }

}

