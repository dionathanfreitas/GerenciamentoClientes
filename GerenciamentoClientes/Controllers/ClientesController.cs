using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoClientes.Models;

namespace GerenciamentoClientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _context;

        public ClientesController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int PageSize = 5;

            int totalClientes = await _context.Cliente.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalClientes / PageSize);

            page = Math.Max(1, Math.Min(page, totalPages));

            int startIndex = (page - 1) * PageSize;

            var clientesPaginados = await _context.Cliente
                .Skip(startIndex)
                .Take(PageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalRegistros = totalClientes;

            return View(clientesPaginados);
        }

        [HttpGet]
        public IActionResult Filtrar(string tipo, string valor, int page = 1)
        {
            IQueryable<Cliente> query = _context.Cliente;

            if (!string.IsNullOrEmpty(valor))
            {
                switch (tipo)
                {
                    case "nome":
                        query = query.Where(c => c.Nome.Contains(valor));
                        break;
                    case "cep":
                        query = query.Where(c => c.CEP.Contains(valor));
                        break;
                    case "email":
                        query = query.Where(c => c.Email.Contains(valor));
                        break;
                }
            }

            const int PageSize = 5;

            int totalClientes = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalClientes / PageSize);

            page = Math.Max(1, Math.Min(page, totalPages));

            int startIndex = (page - 1) * PageSize;

            var clientesPaginados = query
                .Skip(startIndex)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return PartialView("_TabelaClientes", clientesPaginados);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,Email,DataNascimento,CEP")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,Email,DataNascimento,CEP")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            return View(cliente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Não foi encontrado esse registro na base.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Cliente?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
    }
}
