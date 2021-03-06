﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VendasWEB.Models;

namespace VendasWEB.DAL
{
    public class ProdutoDAO
    {
        // #1
        private readonly Context _context;

        // #2
        public ProdutoDAO(Context context)
        {
            _context = context;
        }

        public List<Produto> Listar() => _context.Produtos.Include(x => x.Categoria).ToList();    
        
        public bool Cadastrar(Produto produto)
        {
            if (BuscarPorNome(produto.Nome) == null)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Remover(int id)
        {
            _context.Produtos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public Produto BuscarPorId(int id) => _context.Produtos.Find(id);

        public Produto BuscarPorNome(string nome) => _context.Produtos.FirstOrDefault(x => x.Nome == nome);

        public List<Produto> ListarCategoria(int id) => _context.Produtos.Where(x => x.CategoriaId == id).ToList();
        

    }
}


/* #1
 * Objeto global que recebe o Obj context e poder usa-lo nos metodos da classe
 */


/* #2
 * Criar o ctor com o context para poder usa-lo ao instaciar Produto
 */