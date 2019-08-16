# PDFGenerator_DotNetCore
Developer (Anuja Patel)
Create a new ASP.NET CORE WEB Application Project.
Continue creating new project with .NET CORE 2.2 > Web Application(Model-View-Controller).

Add reference of DinkToPdf package.
Then, we need to download the library from GitHub repository and copy v0.12.4 folder's content to inside of “PDFNative” folder that we have created.
refer PDFNative folder

Loading Assemblies
We need to load the related assemblies when application is started. Firstly, we will create a new class named “CustomAssemblyLoadContext” in startup folder of MVC project.
Refer CustomAssemblyLoadContext.cs

Changes in startup.cs
Refere StartUp.cs

Generating a PDF file from HTML.
Refer Controllers/HomeController.cs > DownloadPDF code.

Add Button on ui to download pdf.
Refer Views/Home/Index.cshtml