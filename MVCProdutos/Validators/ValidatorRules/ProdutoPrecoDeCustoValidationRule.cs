using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProdutos.Models;

namespace MVCProdutos.Validators.ValidatorRules
{
    public class ProdutoPrecoDeCustoValidationRule
    {
        public bool Validar( Produto prod )
        {
            bool validacao = true;
            if (prod.ValorDeCusto > prod.ValorDeVenda)
                validacao = false;
            
            if (prod.ValorDeCusto == 0)
                validacao = false;

            return validacao;
        }
    }
}