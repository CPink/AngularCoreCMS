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
    public class SidebarController : Controller
    {
        private readonly CoreCMSApi _context;

        public SidebarController(CoreCMSApi context)
        {
            _context = context;
        }

        //GET api/sidebar
        public IActionResult Get()
        {
            Sidebar sidebar = _context.Sidebar.FirstOrDefault();

            return Json(sidebar);
        }

        //PUT api/sidebar
        [HttpPut("edit")]
        public IActionResult Edit([FromBody] Sidebar sidebar)
        {
            _context.Update(sidebar);
            _context.SaveChanges();

            return Json("Ok");
        }

    }
}