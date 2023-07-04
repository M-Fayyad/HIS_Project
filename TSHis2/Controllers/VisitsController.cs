using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TSHis2.Models;

namespace TSHis2.Controllers
{
    public class VisitsController : Controller
    {
        private readonly HisContext _context;
        private readonly IToastNotification _toastNotification;
        public VisitsController(HisContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Visits
        public IActionResult Index(string SearchByUmn)
        {
            var visitsList = _context.Visits.Include(v => v.Patient);
            if (!string.IsNullOrEmpty(SearchByUmn))
            {
                visitsList = visitsList.Where(p => p.Umn.ToLower().Contains(SearchByUmn.ToLower())).Include(v => v.Patient);
            }

            //visitsList = visitsList.OrderByDescending(v => v.EntryDate).Take(10);
            return View(visitsList.ToList());

        }

        // GET: Visits/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Visits == null)
            {
                return NotFound();
            }

            var visit = _context.Visits
                .Include(v => v.Patient)
                .FirstOrDefault(m => m.VisitId == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // GET: Visits/Create
        public IActionResult Create(int? id, string umn)
        {
            //ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");

            //this viewBag for  fetch data from the patient view to visit controller to visit view
            ViewBag.PatientId = id;
            ViewBag.umn = umn;
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Visit visit)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(visit);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Visit has been added successfully");

                return RedirectToAction("Index","Patient");
            //}
            //ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", visit.PatientId);
            //return View(visit);
        }

        // GET: Visits/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Visits == null)
            {
                return NotFound();
            }

            var visit = _context.Visits.Find(id);
            if (visit == null)
            {
                return NotFound();
            }
            //ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", visit.PatientId);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VisitId,PatientId,Umn,TicketNumber,EntryPlace,PaymentType,EntryHour,EntryDate,CurrentLocation")] Visit visit)
        {
            if (id != visit.VisitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visit);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitExists(visit.VisitId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _toastNotification.AddSuccessToastMessage("Visit has been updated successfully");

                return RedirectToAction(nameof(Index));
            }
            //ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", visit.PatientId);
            return View(visit);
        }

        //// GET: Visits/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Visits == null)
        //    {
        //        return NotFound();
        //    }

        //    var visit = await _context.Visits
        //        .Include(v => v.Patient)
        //        .FirstOrDefaultAsync(m => m.VisitId == id);
        //    if (visit == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(visit);
        //}

        //// POST: Visits/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Visits == null)
        //    {
        //        return Problem("Entity set 'HisContext.Visits'  is null.");
        //    }
        //    var visit = await _context.Visits.FindAsync(id);
        //    if (visit != null)
        //    {
        //        _context.Visits.Remove(visit);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool VisitExists(int id)
        {
          return (_context.Visits?.Any(e => e.VisitId == id)).GetValueOrDefault();
        }
    }
}
