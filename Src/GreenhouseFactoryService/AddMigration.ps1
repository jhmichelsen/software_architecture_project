# AddMigration.ps1

# Step 1: Ask for the migration name
$MigrationName = Read-Host "Enter the migration name"

if ([string]::IsNullOrWhiteSpace($MigrationName)) {
    Write-Host "Migration name cannot be empty. Exiting..."
    exit 1
}

$Project = "Data"
$StartupProject = ".\GreenhouseFactoryService\"

# Step 2: Add the migration
Write-Host "Adding migration '$MigrationName'..."
dotnet ef migrations add $MigrationName --project $Project --startup-project $StartupProject

# Step 3: Ask if the user wants to apply the migration
$applyMigration = Read-Host "Will you apply the migration? (Y/N)"

if ($applyMigration -match "^[Yy]$") {
    Write-Host "Applying migration..."
    dotnet ef database update --project $Project --startup-project $StartupProject
} else {
    Write-Host "Rolling back migration..."
    # Remove the migration we just added
    dotnet ef migrations remove --project $Project --startup-project $StartupProject
}
