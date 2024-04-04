using todolist.Data;
using todolist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace todolist.Controllers
{

    public class GorevController : Controller

    {
        
        private readonly DataContext _Context;
        public GorevController(DataContext context) // db olayı 
        {
            _Context = context;
        }

        public async Task<IActionResult> Index()
        {
    

            return View(await _Context.Gorevler.ToListAsync()); // ana sayfada görevleri listeleme
        }



        public async Task<IActionResult> Create()
        {
            ViewBag.Gorevler = new SelectList(await _Context.Gorevler.ToListAsync());
            return View();
        }
//
            public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var grv = await _Context
                             .Gorevler
                             .FirstOrDefaultAsync(o => o.GorevId == id);

        if (grv == null)
        {
            return NotFound();
        }
        return View(grv);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Gorev model)
    {
        if (id != model.GorevId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _Context.Update(model);
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_Context.Gorevler.Any(o => o.GorevId == model.GorevId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        return View(model);
    }




 


        [HttpPost]
        public async Task<IActionResult> Create(Gorev model)
        {
            
            _Context.Gorevler.Add(new Gorev() { Aciklama = model.Aciklama, GorevDurum = model.GorevDurum });
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Gorev = await _Context.Gorevler.FindAsync(id);

            if (Gorev == null)
            {
                return NotFound();
            }

            return View(Gorev);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var Gorev = await _Context.Gorevler.FindAsync(id);
            if (Gorev == null)
            {
                return NotFound();
            }
            _Context.Gorevler.Remove(Gorev);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }


}