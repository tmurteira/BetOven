﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetOven.Data;
using BetOven.Models;

namespace BetOven.Controllers
{
    public class ApostasController : Controller
    {
        private readonly Context _context;

        public ApostasController(Context context)
        {
            _context = context;
        }

        // GET: Apostas
        public async Task<IActionResult> Index()
        {
            var context = _context.Apostas.Include(a => a.Jogo).Include(a => a.User);
            return View(await context.ToListAsync());
        }

        // GET: Apostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apostas = await _context.Apostas
                .Include(a => a.Jogo)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (apostas == null)
            {
                return NotFound();
            }

            return View(apostas);
        }

        // GET: Apostas/Create
        public IActionResult Create()
        {
            ViewData["JogoFK"] = new SelectList(_context.Set<Jogos>(), "Njogo", "Njogo");
            ViewData["UserFK"] = new SelectList(_context.Set<Utilizadores>(), "UserId", "Email");
            return View();
        }

        // POST: Apostas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantia,Data,Estado,Descricao,Multiplicador,UserFK,JogoFK")] Apostas apostas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apostas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogoFK"] = new SelectList(_context.Set<Jogos>(), "Njogo", "Njogo", apostas.JogoFK);
            ViewData["UserFK"] = new SelectList(_context.Set<Utilizadores>(), "UserId", "Email", apostas.UserFK);
            return View(apostas);
        }

        // GET: Apostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apostas = await _context.Apostas.FindAsync(id);
            if (apostas == null)
            {
                return NotFound();
            }
            ViewData["JogoFK"] = new SelectList(_context.Set<Jogos>(), "Njogo", "Njogo", apostas.JogoFK);
            ViewData["UserFK"] = new SelectList(_context.Set<Utilizadores>(), "UserId", "Email", apostas.UserFK);
            return View(apostas);
        }

        // POST: Apostas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantia,Data,Estado,Descricao,Multiplicador,UserFK,JogoFK")] Apostas apostas)
        {
            if (id != apostas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apostas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApostasExists(apostas.ID))
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
            ViewData["JogoFK"] = new SelectList(_context.Set<Jogos>(), "Njogo", "Njogo", apostas.JogoFK);
            ViewData["UserFK"] = new SelectList(_context.Set<Utilizadores>(), "UserId", "Email", apostas.UserFK);
            return View(apostas);
        }

        // GET: Apostas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apostas = await _context.Apostas
                .Include(a => a.Jogo)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (apostas == null)
            {
                return NotFound();
            }

            return View(apostas);
        }

        // POST: Apostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apostas = await _context.Apostas.FindAsync(id);
            _context.Apostas.Remove(apostas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApostasExists(int id)
        {
            return _context.Apostas.Any(e => e.ID == id);
        }
    }
}