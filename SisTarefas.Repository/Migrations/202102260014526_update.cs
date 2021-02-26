namespace SisTarefas.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 1000, unicode: false),
                        email = c.String(maxLength: 1000, unicode: false),
                        telefone = c.String(maxLength: 1000, unicode: false),
                        senha = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
