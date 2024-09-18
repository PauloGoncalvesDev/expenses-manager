using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace ExpensesManager.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersion.CreateTableCategory, "Create Table Category")]
    public class Version002 : Migration
    {
        public override void Down() { }

        public override void Up()
        {
            ICreateTableColumnOptionOrWithColumnSyntax table = BaseVersion.AddBaseContext(Create.Table("Category"), "FK_Category_User_Id");

            table
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable();
        }
    }
}
