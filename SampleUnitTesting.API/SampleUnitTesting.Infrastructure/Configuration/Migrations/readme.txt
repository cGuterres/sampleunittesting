Add-Migration Command:
	Add-Migration InitialCreate -StartupProject SampleUnitTesting.API -Context SampleUnitTestingDbContext -OutputDir Configuration/Migrations

Update-Database command
Update-Database -StartupProject SampleUnitTesting.API -Context SampleUnitTestingDbContext
