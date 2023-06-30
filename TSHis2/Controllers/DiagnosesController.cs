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
    public class DiagnosesController : Controller
    {
        private readonly HisContext _context;

        public DiagnosesController(HisContext context)
        {
            _context = context;
        }

        // GET: Diagnoses
        public async Task<IActionResult> Index()
        {
            var hisContext = _context.Diagnoses.Include(d => d.Emp).Include(d => d.Visit);
            return View(await hisContext.ToListAsync());
        }

        // GET: Diagnoses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diagnoses == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.Emp)
                .Include(d => d.Visit)
                .FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        // GET: Diagnoses/Create
        public IActionResult Create(int? id)
        { 
            ViewBag.visitId = id;

            //ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId");
            //ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId");
            return View();
        }

        // POST: Diagnoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Diagnosis diagnosis)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(diagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", diagnosis.EmpId);
            //ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", diagnosis.VisitId);
            //return View(diagnosis);
        }

        // GET: Diagnoses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diagnoses == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", diagnosis.EmpId);
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", diagnosis.VisitId);
            return View(diagnosis);
        }

        // POST: Diagnoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiagnosisId,VisitId,EmpId,Examiation,Diagnosis1,DoctorDecision,DiagnosisDate,DiagnosisHour,DiagnosisLocation")] Diagnosis diagnosis)
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
                    await _context.SaveChangesAsync();
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
            ViewData["EmpId"] = new SelectList(_context.Employees, "EmpId", "EmpId", diagnosis.EmpId);
            ViewData["VisitId"] = new SelectList(_context.Visits, "VisitId", "VisitId", diagnosis.VisitId);
            return View(diagnosis);
        }

        // GET: Diagnoses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diagnoses == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnoses
                .Include(d => d.Emp)
                .Include(d => d.Visit)
                .FirstOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            return View(diagnosis);
        }

        // POST: Diagnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diagnoses == null)
            {
                return Problem("Entity set 'HisContext.Diagnoses'  is null.");
            }
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis != null)
            {
                _context.Diagnoses.Remove(diagnosis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosisExists(int id)
        {
          return (_context.Diagnoses?.Any(e => e.DiagnosisId == id)).GetValueOrDefault();
        }
    }
}
