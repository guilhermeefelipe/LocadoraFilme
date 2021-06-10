using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora.Data;
using Locadora.Models;

namespace Locadora.Controllers
{
    public class FilmesController : Controller
    {
        private readonly LocadoraContext _context;

        public FilmesController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            List<Filme> filme = new List<Filme>();
            var items = _context.Filme.ToList();
            foreach(var item in items)
            {
                filme.Add(new Filme
                {
                    cd_filme = item.cd_filme,
                    ds_nome = item.ds_nome,
                    dt_criacao = item.dt_criacao,
                    st_ativo = item.st_ativo
                    
                });
            }

            //GenerosController c = new GenerosController(_context);

            return View(items);
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.cd_filme == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cd_filme,ds_nome,dt_criacao,st_ativo")] Filme filme)
        {
            if (String.IsNullOrEmpty(filme.ds_nome))
                ModelState.AddModelError("Amount ", "Amount, Greater than 2 please");

            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cd_filme,ds_nome,dt_criacao,st_ativo")] Filme filme)
        {
            if (id != filme.cd_filme)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.cd_filme))
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
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.cd_filme == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.cd_filme == id);
        }

        [HttpPost]
        public IActionResult DeleteFilmes(List<Filme> pFilme)
        {
            List<Filme> filme = new List<Filme>();
            foreach (var item in pFilme)
            {
                if(item.ids.Selected)
                {
                    var filmeSelecionado = _context.Filme.Find(item.cd_filme);
                    filme.Add(filmeSelecionado);
                }
            }
            _context.Filme.RemoveRange(filme);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
