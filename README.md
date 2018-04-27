# KLTTimeKeeper

KLT TimeKeeper App


Overview

The main features of this application includes time keeping for students for school projects such that they can be viewed by other students and the instructor to show the average man hours spent. The application allows the students to keep timesheets of the work they have completed on school projects in collaboration with other members of their group. Further, the application shows the average man hours of students within said group in, and the average man hours of groups compared to other groups within that project for the course. 

On the home page, users may login or create a new account. When creating a new account the user may select an option to request instructor or admin status.

All students are able to register for new courses, and view the courses they are currently registered for. Seeing their course material includes, being able to see all projects within the course, as well as the work status of the groups and individuals within those projects. 

Students may view specific timesheets, and edit or delete entries from their timesheets provided they are within the accepted time frame for approved edits. If they are outside the approved time, it will not allow edits. Students cannot edit another student’s time sheet.

Instructors will be able to view all the courses they currently teach as well as all the projects, groups and students within the courses (similar) to the students access. They will be able to have full editing capabilities for each of the courses, projects, and time entries for those projects for students. When viewing student time sheets, they should be able to see highlighted entries showing that a student has edited their time sheet.

Administrators (this assumes an admin status for an instructor), will be able to view all courses not just the courses they teach. Admin users will also similarly have the same kind of view and edit capabilities as the instructor, just more widespread. Additionally, the admin will receive notifications about users requesting instructor or admin status. The admin will then be able to approve or deny them the status.

How to setup your own version of the KLTTimekeeper application.

Note: This outline assumes the user is using an azure service, github, entity framework code first database, and visual studio 2017.

How to set up an app service in azure 
-	After logging into your azure portal, create a new service and navigate to cloud services.
-	Enter a DNS for your server, and either create a new resource group.
-	 Select a location, and fill in package information for your service
-	Make sure when filling in package information, that “Start deployment” is selected
-	Either add or create a certificate for your service.
This is a summary of the documentation provided by Microsoft, for further reading you may see the link here. 
https://docs.microsoft.com/en-us/azure/cloud-services/cloud-services-how-to-create-deploy-portal
	
How to set up database in azure
-	In the Azure portal, there is a “SQL databases” button in the navigation bar.
-	After clicking the “SQL databases”, you could click “+Add” to add a new SQL database for this project.

How to add a connection string to the appsetting.json” file
-	After creating a SQL database, go into the database.
-	In the “Overview” page, under the “Connection strings”, click “Show database connection strings”.
-	Copy the connection string to the “appsettings.json” within the “KLTTimekeeper” solution, after “DefaultConnection”.
How to add a migration and a update to database
-	After making changes to the database structure, in the Microsoft Visual Studio, enter “Add-Migration” in the “Package Manager Console”.
-	After migration, enter “Update-Database” into the “Package Manager Console”.
How to clone project from github for the time keeper application
-First, open your visual studio IDE before cloning the project
-Upon going to the URL provided, you will see the code repository for the project which includes the most recent commits/ most recent code pushed to the project 
	-https://github.com/TeddyCodeDev/KLTTimeKeeper
-You will note on the left side of the screen, it will show what branch the project is currently showing.
- By default, this branch will be set to the “master” branch. Before continuing, make sure to select the “KLTTimeKeeper” branch instead.
- Next, you will notice on the right hand side of the screen, there is a drop down option to clone the project.
-From here, you can copy the corresponding “https” link to your clipboard.
-In visual studio, open your team explorer window and create a new connection
-Here you have the option to clone an existing project with a provided link.
-You may use the link provided as described earlier, to clone the project. 
