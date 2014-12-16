#Migration

```
Enable-Migrations -EnableAutomaticMigrations -ProjectName SepatedDbContextApplication.DataAccess -ContextTypeName IdentityContext -MigrationsDirectory IdentityContextMigrations
Enable-Migrations -EnableAutomaticMigrations -ProjectName SepatedDbContextApplication.DataAccess -ContextTypeName DataContext -MigrationsDirectory DataContext�@Migrations
Update-Database -ProjectName SepatedDbContextApplication.DataAccess  -Configuration SepatedDbContextApplication.DataAccess.IdentityContextMigrations.Configuration
Update-Database -ProjectName SepatedDbContextApplication.DataAccess  -Configuration SepatedDbContextApplication.DataAccess.DataContextMigrations.Configuration
```