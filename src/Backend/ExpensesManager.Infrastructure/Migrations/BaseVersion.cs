using FluentMigrator.Builders.Create.Table;

namespace ExpensesManager.Infrastructure.Migrations
{
    public static class BaseVersion
    { 
        public static ICreateTableColumnOptionOrWithColumnSyntax AddBaseContext(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table, string foreignKeyUser = null)
        {
            if (!string.IsNullOrEmpty(foreignKeyUser))
                table.WithColumn("UserId").AsInt64().NotNullable().ForeignKey(foreignKeyUser, "User", "Id");

            return table
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable();
        }
    }
}
