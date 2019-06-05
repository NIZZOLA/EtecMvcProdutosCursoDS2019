using MVCProdutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProdutos.Services
{
    public class ProdutosService
    {
        private MVCProdutosContext db = new MVCProdutosContext();

        public bool Salvar( Produto prod )
        {
            db.Produtos.Add(prod);
            db.SaveChanges();

            return true;
        }

        public bool Atualizar( Produto prod )
        {
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public Produto Consultar( int id )
        {
            return db.Produtos.Find(id);
        }

        public ICollection<Produto> ListarTodos()
        {
            return db.Produtos.OrderBy(a => a.Descricao).ToList();
        }

        public bool Excluir( int id )
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return true;
        }
    }
}