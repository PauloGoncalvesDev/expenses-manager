using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace ExpensesManager.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersion.CreateTableTransaction, "Create Table Transaction")]
    public class Version002 : Migration
    {
        public override void Down() { }

        public override void Up()
        {
            ICreateTableColumnOptionOrWithColumnSyntax table = BaseVersion.AddBaseContext(Create.Table("Transaction"));

            table
                .WithColumn("CategoryId").AsInt64().NotNullable().ForeignKey("FK_Transaction_Category_Id", "Category", "Id")
                .WithColumn("Amount").AsDecimal().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("Type").AsInt32().NotNullable()
                .WithColumn("TransactionDate").AsDateTime().NotNullable();
        }
    }
}
