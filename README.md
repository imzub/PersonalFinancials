# Personal Financials

## Setting Up the Project

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/yourusername/PersonalFinancials.git
   cd PersonalFinancials
   ```

2. **Open the Solution:**
   Open the `PersonalFinancials.sln` file in Visual Studio.

3. **Restore NuGet Packages:**
   In Visual Studio, go to `Tools` > `NuGet Package Manager` > `Package Manager Console` and run:
   ```sh
   Update-Package -reinstall
   ```

4. **Set Up the Database:**
   - Ensure you have SQL Server installed and running.
   - Create a new database named `PersonalFinancials`.
   - Execute the SQL scripts located in the `PFDB_SQL` folder to create the necessary tables and stored procedures.

5. **Update Connection Strings:**
   - Open the `App.config` file in the `PF_ClassLibrary` project and update the connection string to point to your SQL Server instance.
   - Open the `appsettings.json` file in the `PersonalFinancialsMvcCore` project and update the connection string to point to your SQL Server instance.

## Running the Project

1. **Build the Solution:**
   In Visual Studio, right-click on the solution in the Solution Explorer and select `Build Solution`.

2. **Run the Desktop Application:**
   - Set `PF_Desktop` as the startup project.
   - Press `F5` to run the desktop application.

3. **Run the Web Application:**
   - Set `PersonalFinancialsMvcCore` as the startup project.
   - Press `F5` to run the web application.
   - The web application should open in your default browser.

4. **Logging:**
   - Events and errors are logged using the `EventLogDataAccess` and `ExceptionLogDataAccess` classes.
   - Event logs are stored in the `tbl_EventLog` table.
   - Error logs are stored in the `tbl_ExceptionLog` table.
