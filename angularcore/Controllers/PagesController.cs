using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularcore.Data;
using angularcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace angularcore.Controllers
{
    [Route("api/[controller]")]
    public class PagesController : Controller
    {
        public readonly CoreCMSApi _context;

        public PagesController(CoreCMSApi context)
        {
            _context = context;
        }

        //GET api/pages
        public IActionResult Get()
        {
            List<Page> pages = _context.Pages.ToList();

            return Json(pages);
        }

        //GET api/pages/slug
        [HttpGet("{slug}")]
        public IActionResult Get(string slug)
        {
            Page page = _context.Pages.SingleOrDefault(x => x.Slug == slug);

            if (page == null)
            {
                return Json("PageNotFound");
            }

            return Json(page);
        }
    }
}