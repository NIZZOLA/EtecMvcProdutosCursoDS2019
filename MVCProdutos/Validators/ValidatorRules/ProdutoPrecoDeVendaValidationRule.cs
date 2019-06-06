using MVCProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProdutos.Validators.ValidatorRules
{
    public class ProdutoPrecoDeVendaValidationRule
    {
        public bool Validar(Produto prod)
        {
            bool validacao = true;
            if (prod.ValorDeVenda == 0)
                validacao = false;

            if (prod.ValorDeCusto > prod.ValorDeVenda)
                validacao = false;

            return validacao;
        }
    }
}