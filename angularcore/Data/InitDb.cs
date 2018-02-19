using angularcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularcore.Data
{
    public class InitDb
    {
        public static void Init(CoreCMSApi context)
        {
            context.Database.EnsureCreated();

            if (context.Pages.Any())
            {
                return;
            }

            var pages = new Page[]
            {
                new Page { Title = "Home", Slug = "Home", Content = "Home content", HasSidebar = "no"},
                new Page { Title = "About", Slug = "About", Content = "About content", HasSidebar = "no"},
                new Page { Title = "Services", Slug = "Services", Content = "Services content", HasSidebar = "no"},
                new Page { Title = "Contact", Slug = "Contact", Content = "Contact content", HasSidebar = "no"}
            };

            foreach(Page p in pages)
            {
                context.Pages.Add(p);
            }

            context.SaveChanges();

            var sidebar = new Sidebar
            {
                Content = "sidebar content"
            };

            context.Sidebar.Add(sidebar);
            context.SaveChanges();

            var user = new User
            {
                UserName = "admin",
                Password = "password",
                IsAdmin = "yes"
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
