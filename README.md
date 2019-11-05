# MvcMusicStore
The application is a simple web application for music store. There are three main parts to the application: shopping, checkout, 
and administration. 
It's a tutorial from Microsoft and I did some enhancements. 
It's developed using C#, MVC5, and EF6.

Please read the MVC Music Store - Tutorial - v3.0.pdf for more information.

You can attach the database files from App_Data folder to start using the project immediately.
Or In case if you decided not using the deployed database in App_Data folder. 
And by running the application for the first time, the database files will be created automatically for you 
and a sample data will be inserted into the created database. 
The only thing that you need to do in this case is to creat the missing aspnet_[User Authintication] tables by using the follwoing steps: 

	Resources to create/define users and roles on web admin tool 

		1- Tool to add aspnet_[User Authintication] tables to your database
			- Open C:\Windows\Microsoft.NET\Framework64\v4.0.30319 
				OR cmd => cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
			- Open Aspnet_regsql.exe
				OR run Aspnet_regsql.exe -A all -E -d [Application Directory]/App_Data/MusicStoreDB.mdf

		2- open the admin web tool
			- cmd => cd C:\Program Files (x86)\IIS Express

			- By Assuming the port # is 44333  and the Application Directory is C:\Hany\CSharp\Projects\MvcMusicStore,
			  you can run the  iisexpress as follows:
			  iisexpress.exe /path:C:\Windows\Microsoft.NET\Framework\v4.0.30319\ASP.NETWebAdminFiles /vpath:/ASP.NETWebAdminFiles /port:44333 /clr:4.0 /ntlm

			- The you can use the follwoing URL to open the web admin tool to create roles and users: 
			http://localhost:44333/asp.netwebadminfiles/default.aspx?applicationPhysicalPath=C:\Hany\CSharp\Projects\MvcMusicStore&applicationUrl=/
			 