using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProdutos.Models;
using MVCProdutos.Services;

namespace MVCProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosService _produtoService = new ProdutosService();

        // GET: Produtos
        public ActionResult Index()
        {
            //return View(db.Produtos.ToList());
            return View(_produtoService.ListarTodos());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _produtoService.Consultar(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Descricao,UnidadeDeMedida,ValorDeCusto,MargemDeLucro,ValorDeVenda,DataDaInclusao,DataDaAlteracao,Estoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if( _produtoService.Salvar(produto) )
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Message = "Erro na inclusão !";
                }
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _produtoService.Consultar(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Descricao,UnidadeDeMedida,ValorDeCusto,MargemDeLucro,ValorDeVenda,DataDaInclusao,DataDaAlteracao,Estoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if( _produtoService.Atualizar(produto))
                  return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _produtoService.Consultar(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if( _produtoService.Excluir(id))
                return RedirectToAction("Index");

            return RedirectToAction("ErroAoExcluir");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
