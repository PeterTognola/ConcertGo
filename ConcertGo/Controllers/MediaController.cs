using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ConcertGo.Models;
using ConcertGo.ViewModels;

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

        // GET: Media/Create/5
        public ActionResult Create(Guid? concertId)
        {
            if (!concertId.HasValue) return null; // todo error.

            return View(new CreateMediaViewModel
            {
                ConcertId = concertId.Value
            });
        }

        // POST: Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMediaViewModel media) // todo finish off.
        {
            if (!ModelState.IsValid) return View(media);

            using (var context = new ApplicationDbContext())
            {
                var concert = await context.Concerts.FindAsync(media.ConcertId);

                if (concert == null) return null; // todo error.

                if (concert.Media == null) concert.Media = new List<Media>();

                concert.Media.Add(new Media
                {
                    Id = Guid.NewGuid(),
                    Name = media.Name
                });

                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public JsonResult FileHandler() // return file name for media creation.
        { // do like instagram does, upload file while user completes form.
            return null; // todo handle file.
        }
    }
}
