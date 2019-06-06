namespace MVCProdutos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50),
                        UnidadeDeMedida = c.String(maxLength: 2),
                        ValorDeCusto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MargemDeLucro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorDeVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataDaInclusao = c.DateTime(nullable: false),
                        DataDaAlteracao = c.DateTime(nullable: false),
                        Estoque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
        }
    }
}
