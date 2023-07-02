using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSHis2.Models;

namespace TSHis2.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly HisContext _context;

        public DiagnosisController(HisContext context)
        {
            _context = context;
        }

        // GET: Diagnosis
        public IActionResult Index()
        {
            var hisContext = _context.Diagnoses.Include(d => d.Visit);
            return View(hisContext.ToList());
        }

        // GET: Diagnosis/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Diagnoses == null)
            {
                return NotFound();
            }

            var diagnosis = _context.Diagnoses
                .Include(d => d.Visit)
                .FirstOrDefault(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        // GET: Diagnosis/Create
        public IActionResult Create(int? id)
        {
            ViewBag.VisitId = id;
            //ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId");
            return View();
        }

        // POST: Diagnosis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Diagnosis diagnosis)
        {
            //if (ModelState.IsValid)
            //{
            _context.Add(diagnosis);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", diagnosis.VisitId);
            //return View(diagnosis);
        }

        // GET: Diagnosis/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Diagnoses == null)
            {
                return NotFound();
            }

            var diagnosis = _context.Diagnoses.Find(id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", diagnosis.VisitId);
            return View(diagnosis);
        }

        // POST: Diagnosis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DiagnosisId,VisitId,Examiation,Drugs,Tests,Diagnosis1,DoctorDecision,DiagnosisDate,DiagnosisLocation")] Diagnosis diagnosis)
        {
            if (id != diagnosis.DiagnosisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosis);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisExists(diagnosis.DiagnosisId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", diagnosis.VisitId);
            return View(diagnosis);
        }

        //// GET: Diagnosis/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Diagnoses == null)
        //    {
        //        return NotFound();
        //    }

        //    var diagnosis = await _context.Diagnoses
        //        .Include(d => d.Visit)
        //        .FirstOrDefaultAsync(m => m.DiagnosisId == id);
        //    if (diagnosis == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(diagnosis);
        //}

        //// POST: Diagnosis/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Diagnoses == null)
        //    {
        //        return Problem("Entity set 'HisContext.Diagnoses'  is null.");
        //    }
        //    var diagnosis = await _context.Diagnoses.FindAsync(id);
        //    if (diagnosis != null)
        //    {
        //        _context.Diagnoses.Remove(diagnosis);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool DiagnosisExists(int id)
        {
            return (_context.Diagnoses?.Any(e => e.DiagnosisId == id)).GetValueOrDefault();
        }
    }
}
