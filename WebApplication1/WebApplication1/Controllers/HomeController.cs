using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebApplication1.Models;
using ClassLib;
using WebApplication1.Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }
        [HttpPost]
        public IActionResult Result(Input input)
        {
            // Сохранение варианта исходных данных
            if (!string.IsNullOrEmpty(input.Name))
            {
                var existVariant = _context.Variants.FirstOrDefault(x => x.Name == input.Name);

                if (existVariant != null)
                {
                    // Обновление варианта
                    existVariant.d = input.d;
                    existVariant.S1 = input.S1;
                    existVariant.S2 = input.S2;
                    existVariant.w = input.w;
                    existVariant.t = input.t;

                    _context.Variants.Update(existVariant);
                    _context.SaveChanges();
                }
                else
                {
                    var variant = new Variant
                    {
                        Name = input.Name,
                        d = input.d,
                        S1 = input.S1,
                        S2 = input.S2,
                        w = input.w,
                        t = input.t
                        //UserId = _userId,
                        //CreatedAt = DateTime.Now
                    };

                    _context.Variants.Add(variant);
                    _context.SaveChanges();
                }
            }

            //Выполнение расчета
            var lib = new TeploobmenSolver(input);
            var result = lib.calc();

                return View(result);
        }
        public IActionResult Result_k(Input input)
        {
            // Сохранение варианта исходных данных
            if (!string.IsNullOrEmpty(input.Name))
            {
                var existVariant = _context.Variants.FirstOrDefault(x => x.Name == input.Name);

                if (existVariant != null)
                {
                    // Обновление варианта
                    existVariant.d = input.d;
                    existVariant.S1 = input.S1;
                    existVariant.S2 = input.S2;
                    existVariant.w = input.w;
                    existVariant.t = input.t;

                    _context.Variants.Update(existVariant);
                    _context.SaveChanges();
                }
                else
                {
                    var variant = new Variant
                    {
                        Name = input.Name,
                        d = input.d,
                        S1 = input.S1,
                        S2 = input.S2,
                        w = input.w,
                        t = input.t
                        //UserId = _userId,
                        //CreatedAt = DateTime.Now
                    };

                    _context.Variants.Add(variant);
                    _context.SaveChanges();
                }
            }
           
            //Выполнение расчета
            var lib = new TeploobmenSolver(input);
            var result = lib.calc();

            return View(result);
        }
        [HttpGet]
        public IActionResult Index(int? variantId)
        {
            var viewModel = new HomeViewModel();

            if (variantId != null)
            {
                viewModel.Variant = _context.Variants
                    .FirstOrDefault(x => x.Id == variantId);

            }

            viewModel.Variants = _context.Variants.ToList();
            

            return View(viewModel);

        }
        public IActionResult Index_k(int? variantId)
        {
            var viewModel = new HomeViewModel();

            if (variantId != null)
            {
                viewModel.Variant = _context.Variants
                    .FirstOrDefault(x => x.Id == variantId);
            }
            viewModel.Variants = _context.Variants.ToList();
            return View(viewModel);
        }
        public IActionResult Remove(int? variantId)
        {
            var variant = _context.Variants
                .FirstOrDefault(x => x.Id == variantId);
            if (variant != null)
            {
                _context.Variants.Remove(variant);
                _context.SaveChanges();

                TempData["message"] = $"Вариант {variant.Name} удален.";
            }
            else
            {
                TempData["message"] = $"Вариант не найден.";
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}