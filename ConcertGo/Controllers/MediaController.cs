using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ConcertGo.Models;
using ConcertGo.ViewModels;
using WebGrease.Css.Extensions;
using File = ConcertGo.Models.File;

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

                var newMedia = new Media
                {
                    Id = Guid.NewGuid(),
                    Comment = media.Comment,
                    Files = new List<File>()
                };

                foreach (var file in media.Files.Split(','))
                {
                    if (file == "") continue;

                    var currentFile = await context.Files.FindAsync(new Guid(file));
                    if (currentFile == null) continue;

                    currentFile.HasMedia = true;
                    newMedia.Files.Add();
                }

                concert.Media.Add(newMedia);

                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> FileHandler() // return file name for media creation.
        { // do like instagram does, upload file while user completes form. Get meta and store with media.
            var fileId = Guid.NewGuid();
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];

                    if (fileContent == null || fileContent.ContentLength <= 0) continue;

                    var contentType = fileContent.ContentType;

                    var stream = fileContent.InputStream;

                    var fileName = fileId + "." + fileContent.FileName.Split('.')[fileContent.FileName.Split('.').Length - 1];

                    var path = Path.Combine(Server.MapPath("~/App_Data/Concert_Content/"), fileName);

                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }

                    using (var context = new ApplicationDbContext())
                    {
                        context.Files.Add(new File
                        {
                            Id = fileId,
                            Type = FileType.Photo, // todo
                            UploadDateTime = DateTime.UtcNow,
                            Location = path,
                            Url = $"~/App_Data/Concert_Content/{fileName}"
                        });

                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error");
            }

            return Json(fileId);
        }
    }
}
