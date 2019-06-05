using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProdutos.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }
        [MaxLength(2)]
        public string UnidadeDeMedida { get; set; }
        public decimal ValorDeCusto { get; set; }

        public decimal MargemDeLucro { get; set; }
        public decimal ValorDeVenda { get; set; }

        public DateTime DataDaInclusao { get; set; }
        public DateTime DataDaAlteracao { get; set; }

        public decimal Estoque { get; set; }
        public bool Ativo { get; set; }
    }
}