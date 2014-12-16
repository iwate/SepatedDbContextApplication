using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SepatedDbContextApplication.DataAccess;
using SepatedDbContextApplication.Entity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace SepatedDbContextApplication.Web.Controllers
{
    public class DataController : Controller
    {
        private IDataRepository _repo;
        internal IDataRepository Repo
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new DataRepository(HttpContext.GetOwinContext().Get<DataContext>());
                }
                return _repo;
            }
        }
        // GET: Data
        public ActionResult Index()
        {
            return View(Repo.GetAll());
        }

        // GET: Data/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = await Repo.Find(id.Value);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // GET: Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Text")] Datum datum)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(datum);
                await Repo.Save();
                return RedirectToAction("Index");
            }

            return View(datum);
        }

        // GET: Data/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = await Repo.Find(id.Value);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: Data/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Text")] Datum datum)
        {
            if (ModelState.IsValid)
            {
                Repo.Update(datum);
                await Repo.Save();
                return RedirectToAction("Index");
            }
            return View(datum);
        }

        // GET: Data/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datum datum = await Repo.Find(id.Value);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Datum datum = await Repo.Find(id);
            Repo.Remove(datum);
            await Repo.Save();
            return RedirectToAction("Index");
        }
    }
}
