using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace ExpensesManager.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersion.CreateTableUserImage, "Create Table User Image")]
    public class Version004 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            ICreateTableColumnOptionOrWithColumnSyntax table = BaseVersion.AddBaseContext(Create.Table("UserImage"), "FK_UserImage_User_Id");

            table
                .WithColumn("FileName").AsString().NotNullable()
                .WithColumn("ContentType").AsString().NotNullable()
                .WithColumn("ImageSize").AsInt32().NotNullable()
                .WithColumn("ImageUrl").AsString().NotNullable();
        }
    }
}
