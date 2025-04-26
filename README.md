# News Website Project with Admin Panel

This repository contains a news website developed using ASP.NET MVC with an admin panel for managing the site's content. It leverages C#, HTML, CSS, and Bootstrap to create a responsive and feature-rich web application.

## Features

User-Facing Website
News Display: Showcases news articles categorized by topics.

Responsive Design: Ensures a seamless user experience across all devices, using Bootstrap.

Search Functionality: Allows users to search for articles by keywords.

Comment System: Users can add comments to articles (optional feature).

Admin Panel
Dashboard: Provides an overview of the website's activity.

News Management: Add, edit, and delete news articles.

Category Management: Create and organize news categories.

User Management: Manage users with specific roles (e.g., admin, editor).

Content Moderation: Review and approve submitted comments or news articles.

## Technologies Used

ASP.NET MVC: Framework for developing dynamic, data-driven websites.

C#: The programming language used for server-side logic.

HTML & CSS: For creating and styling the user interface.

Bootstrap: Frontend framework for responsive design.

Entity Framework: ORM for database interactions.

SQL Server: Database to store news articles, user data, and other information.

## Getting Started

Follow these steps to set up and run the project locally:

Clone the Repository:

Open a terminal and run: git clone https://github.com/YourUsername/NewsWebsite.git

Configure the Database:

Update the connectionString in the web.config or appsettings.json file with your SQL Server instance.

Run Database Migrations:

Use Entity Framework to apply migrations: update-database

Build and Run the Project:

Open the solution in Visual Studio and build the project.

Run the application; the website will be accessible at http://localhost:XXXX.

Access the Admin Panel:

Navigate to the admin panel by visiting: http://localhost:XXXX/admin

Default admin credentials: Username: admin@example.com Password: password (Change credentials immediately after first login.)

## Customization

Styles: Customize the look and feel by editing the CSS files in the Content folder.

Views: Modify HTML views in the Views folder to change page layouts.

Admin Panel Functionality: Extend admin panel features by updating controllers and models.
