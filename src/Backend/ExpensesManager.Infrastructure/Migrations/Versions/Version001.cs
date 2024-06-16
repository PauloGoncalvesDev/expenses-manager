using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace ExpensesManager.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersion.CreateTableCategory, "Create Table Category")]
    public class Version001 : Migration
    {
        public override void Down() { }

        public override void Up()
        {
            ICreateTableColumnOptionOrWithColumnSyntax table = BaseVersion.AddBaseContext(Create.Table("Category"));

            table
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable();
        }
    }
}
