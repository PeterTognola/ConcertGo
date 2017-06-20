using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConcertGo.Models;

namespace ConcertGo.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Index()
        {
            return null; // todo show all recent media files.
        }

        // GET: Media/Details/5
        public ActionResult Details(Guid? id)
        {
            return null; // todo show media details.
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type")] Media media)
        {
            if (!ModelState.IsValid) return View(media);

            using (var context = new ApplicationDbContext())
            {
                
            }

            return RedirectToAction("Index");
        }

        public JsonResult FileHandler() // return file name for media creation.
        { // do like instagram does, upload file while user completes form.
            return null; // todo handle file.
        }
    }
}
