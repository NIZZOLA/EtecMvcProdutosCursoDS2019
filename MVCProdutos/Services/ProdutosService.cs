using MVCProdutos.Models;
using MVCProdutos.Validators;
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
        private ProdutoValidator validator = new ProdutoValidator();

        public bool Salvar( Produto prod )
        {
            if (validator.ValidarInclusao(prod))
            {
                prod.DataDaInclusao = DateTime.Now;
                db.Produtos.Add(prod);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Atualizar( Produto prod )
        {
            prod.DataDaAlteracao = DateTime.Now;
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