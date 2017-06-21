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
using ConcertGo.ViewModels;

namespace ConcertGo.Controllers
{
    public class ConcertController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Concert
        public async Task<ActionResult> Index()
        {
            return View(await db.Concerts.ToListAsync());
        }

        // GET: Concert/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var concert = await db.Concerts.Include(c => c.Media).FirstAsync(x=> x.Id == id).ContinueWith(x => // todo will return null, fix it.
            {
                return new ConcertDetailViewModel
                {
                    Artists = x.Result.Artists.Select(y => new ArtistViewModel
                    {
                        Name = y.Name
                    }),
                    Name = x.Result.Name,
                    Id = x.Result.Id,
                    Media = x.Result.Media.Select(y => new MediaViewModel
                    {
                        Name = y.Name
                    })
                };
            });

            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // GET: Concert/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concert/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                concert.Id = Guid.NewGuid();
                db.Concerts.Add(concert);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(concert);
        }

        // GET: Concert/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = await db.Concerts.FindAsync(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // POST: Concert/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concert).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(concert);
        }

        // GET: Concert/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = await db.Concerts.FindAsync(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // POST: Concert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Concert concert = await db.Concerts.FindAsync(id);
            db.Concerts.Remove(concert);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
