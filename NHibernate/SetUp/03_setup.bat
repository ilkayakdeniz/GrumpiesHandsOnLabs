set cleanupSqlPath=%cd%\cleanup.sql
sqlcmd -S localhost\SQLeXPRESS -i %cleanupSqlPath%

set setupSqlPath=%cd%\S03_setup.sql
sqlcmd -S localhost\SQLeXPRESS -i %setupSqlPath%

set /p DUMMY=Hit ENTER to continue...