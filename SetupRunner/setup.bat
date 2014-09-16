set setupSqlPath=%cd%\Customer_create.sql
sqlcmd -S localhost\SQLeXPRESS -i %setupSqlPath%