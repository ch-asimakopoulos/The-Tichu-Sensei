Both these commands need to be run on a console prompt opened in your repo's src folder.

dotnet ef migrations add initialPgsqlMigration --project TichuSensei.Infrastructure\ --startup-project TichuSensei.WebApi\ --output-dir "YOUR_REPO_PATH\src\TichuSensei.Infrastructure\Persistence\Migrations"

dotnet ef database update --project TichuSensei.Infrastructure\ --startup-project TichuSensei.WebApi\