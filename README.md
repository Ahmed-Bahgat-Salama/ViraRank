<div align="center">
<h1>ViraRank API - Backend 🚀</h1>
<p>
The official backend service for the ViraRank application, built with ASP.NET Core 8. It provides a robust API for user management, authentication, and AI-powered SEO analysis.
</p>

<p>
<img src="https://www.google.com/search?q=https://img.shields.io/badge/.NET-8.0-blueviolet" alt=".NET 8.0">
<img src="https://www.google.com/search?q=https://img.shields.io/badge/Entity%2520Framework-Core-blue" alt="EF Core">
<img src="https://www.google.com/search?q=https://img.shields.io/badge/SQL%2520Server-Used-red" alt="SQL Server">
<img src="https://www.google.com/search?q=https://img.shields.io/badge/Authentication-JWT-green" alt="JWT Authentication">
</p>
</div>

📋 Table of Contents
Getting Started

Prerequisites

Installation & Configuration

🛠️ Technology Stack

📖 API Endpoint Documentation

Authentication

Users

SEO Analysis

🤝 Contributing

📜 License

🏁 Getting Started
Follow these steps to get the project up and running on your local machine.

Prerequisites
.NET 8 SDK

SQL Server (Express edition is sufficient)

An API testing tool like Postman

🔧 Installation & Configuration
Clone the Repository:

git clone [https://github.com/Ahmed-Bahgat-Salama/ViraRank.git](https://github.com/Ahmed-Bahgat-Salama/ViraRank.git)

Create appsettings.json file:
This file is intentionally excluded from the repository. You must create it manually in the root project folder (ViraRankCleanApi). Copy the content below into it:

Note: Make sure the ConnectionStrings match your local SQL Server configuration.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=vira_rank_clean;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "ThisIsMySuperStrongAndLongSecretKeyForViraRankApp2024AndMustBeAtLeast32BytesLong!",
    "Issuer": "ViraRankApi",
    "Audience": "ViraRankClient"
  },
  "AiModel": {
    "BaseUrl": "[https://omaraboelmaaty-seo-rank-classifier.hf.space/](https://omaraboelmaaty-seo-rank-classifier.hf.space/)"
  },
  "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning"}},
  "AllowedHosts": "*"
}

Create the Database:
Open the Package Manager Console in Visual Studio and run the following commands:

Add-Migration InitialCreate
Update-Database

Run the Project:
Open the project in Visual Studio and press the green https run button.

🛠️ Technology Stack
Framework: ASP.NET Core 8

Database: SQL Server with Entity Framework Core 8

Authentication: JWT (JSON Web Tokens)

Architecture: REST API

📖 API Endpoint Documentation
Here are the main endpoints that the client application can consume.

Base URL: The root URL for all endpoints is your localhost address (e.g., https://localhost:7186).

Authentication
Endpoint

Method

Authorization

Description

/api/auth/register

POST

No

Registers a new user.

/api/auth/login

POST

No

Logs in a user and returns a JWT.

/api/auth/change-password

POST

Yes

Changes the current user's password.

<details>
<summary>Click to see request/response examples for Authentication</summary>

Register Request Body:

{
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00Z",
  "gender": true,
  "password": "Password123!",
  "githubToken": "some_token_here"
}

Login Success Response:

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "githubToken": "some_token_here"
}

Change Password Request Body:

{
  "oldPassword": "CurrentPassword123!",
  "newPassword": "NewStrongPassword456!",
  "confirmNewPassword": "NewStrongPassword456!"
}

</details>

Users
Endpoint

Method

Authorization

Description

/api/users/me

GET

Yes

Fetches the current user's profile.

<details>
<summary>Click to see response example for Users</summary>

Get Profile Success Response:

{
  "id": 1,
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00",
  "gender": true,
  "imageUrl": null
}

</details>

SEO Analysis
Endpoint

Method

Authorization

Description

/api/seo/analyze

POST

Yes

Analyzes HTML content using an AI model.

<details>
<summary>Click to see request/response examples for SEO Analysis</summary>

Analyze HTML Request Body:

{
  "html": "<html>...</html>"
}

Analyze HTML Success Response:

{
  "seo_friendly": true,
  "probability": 0.987,
  "top_class": "Good"
}
