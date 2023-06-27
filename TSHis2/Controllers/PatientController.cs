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
    public class PatientController : Controller
    {
        private readonly HisContext _context;

        public PatientController(HisContext context)
        {
            _context = context;
        }

        // GET: Patient
        public IActionResult Index(string SearchByName)
        {
            //return _context.Patients != null ? 
            //            View(_context.Patients.ToList()) :
            //            Problem("Entity set 'HisContext.Patients'  is null.");
            
            var patientList = _context.Patients.ToList();
            if (!string.IsNullOrEmpty(SearchByName))
            {
                patientList = patientList.Where(p => p.PatientName.ToLower().Contains(SearchByName.ToLower())).ToList();
            }
            patientList = patientList.OrderByDescending(p => p.PatientId).Take(10).ToList();
            return View(patientList);
        }

        // GET: Patient/Details/5
        //public IActionResult Details(int? id)
        //{
        //    if (id == null || _context.Patients == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = _context.Patients.FirstOrDefault(m => m.PatientId == id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(patient);
        //}

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PatientId,NationalId,Umn,PatientName,PatientAge,PatientAddress,PhoneNumber")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patient/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PatientId,NationalId,Umn,PatientName,PatientAge,PatientAddress,PhoneNumber")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
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
            return View(patient);
        }

        // GET: Patient/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = _context.Patients.FirstOrDefault(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Patients == null)
            {
                return Problem("Entity set 'HisContext.Patients'  is null.");
            }
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
          return (_context.Patients?.Any(e => e.PatientId == id)).GetValueOrDefault();
        }
    }
}
