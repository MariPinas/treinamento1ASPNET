using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using treinamento1ASPNET.Context;
using treinamento1ASPNET.Model;
using treinamento1ASPNET.Context;

namespace treinamento1ASPNET.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(ProductDTO productDTO)
        {
            var product = new Product
            {
                Nome = productDTO.Nome,
                Preco = productDTO.Preco,
                Estoque = productDTO.Estoque
            };

            _context.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetByID(int id)
        {
            var produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }
            return Ok(produtoEncontrado);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDTO productDTO)
        {
            var produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            produtoEncontrado.Nome = productDTO.Nome;
            produtoEncontrado.Preco = productDTO.Preco;
            produtoEncontrado.Estoque = productDTO.Estoque;

            _context.SaveChanges();

            return Ok(produtoEncontrado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }
            _context.Remove(produtoEncontrado);
            _context.SaveChanges();
            return NoContent();
        }

    }
}