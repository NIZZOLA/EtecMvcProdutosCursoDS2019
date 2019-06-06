using MVCProdutos.Models;
using MVCProdutos.Validators.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProdutos.Validators
{
    public class ProdutoValidator
    {
        public bool ValidarInclusao( Produto prod )
        {
            bool retorno = true;
            if (! new ProdutoPrecoDeCustoValidationRule().Validar(prod))
                retorno = false;

            if (!new ProdutoPrecoDeVendaValidationRule().Validar(prod))
                retorno = false;

            return retorno;
        }

        public bool ValidarAlteracao(Produto prod)
        {
            bool validacao = true;
            
            return validacao;
        }
    }
}