using AutoMapper.QueryableExtensions;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using SwiftBookingTest.Model.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class ClientRecordsController : MvcBaseController
    {
        public ClientRecordsController(ISwiftDemoUow uow)
        {
            sdUow = uow;
        }

        // GET: ClientRecords
        public async Task<JsonResult> Index()
        {
            var model = await Task.FromResult<List<ClientRecordViewModel>>
                (
                    sdUow.ClientRecords
                    .GetAll()
                    .ProjectTo<ClientRecordViewModel>()
                    .ToList()
                 );
            return BetterJson(model, JsonRequestBehavior.AllowGet);
        }



        // GET: ClientRecords/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientRecords/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientRecords/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var client = await Task.FromResult<List<ClientRecordViewModel>>(
                         sdUow.ClientRecords
                        .GetAll()
                        .ProjectTo<ClientRecordViewModel>()
                        .ToList()
                );
            var client2 = client.Where(x => x.Id == id).First();
            return BetterJson(client2, JsonRequestBehavior.AllowGet);
        }

        // POST: ClientRecords/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientRecords/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientRecords/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
