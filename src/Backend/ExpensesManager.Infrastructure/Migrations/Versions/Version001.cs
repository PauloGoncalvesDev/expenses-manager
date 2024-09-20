using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace ExpensesManager.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersion.CreateTableUserAndAdditionalInfoUser, "Create Tables User and AdditionalInfoUser")]
    public class Version001 : Migration
    {
        public override void Down() { }

        public override void Up()
        {
            CreateUserTable();

            CreateAdditionalInfoUserTable();
        }

        private void CreateUserTable()
        {
            ICreateTableWithColumnOrSchemaOrDescriptionSyntax table = Create.Table("User");

            table
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("DeletionDate").AsDateTime().Nullable()
                .WithColumn("Mail").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Salt").AsString().NotNullable();
        }

        private void CreateAdditionalInfoUserTable()
        {
            ICreateTableColumnOptionOrWithColumnSyntax table = BaseVersion.AddBaseContext(Create.Table("AdditionalInfoUser"), "FK_AdditionalInfoUser_User_Id");

            table
                .WithColumn("BirthDate").AsDateTime().NotNullable()
                .WithColumn("Phone").AsString().NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("Nationality").AsString().NotNullable()
                .WithColumn("Occupation").AsString().NotNullable();
        }
    }
}
