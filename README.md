<div align="center">
<h1>ViraRank API - Backend Service 🚀</h1>
<p>
The official backend service for the ViraRank application, built with ASP.NET Core 8. It provides a robust REST API for user management, authentication, and AI-powered analysis for both SEO and viral trends.
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

AI Analysis

🤝 Contributing

🏁 Getting Started
Follow these steps to get the project up and running on your local machine for development and testing.

Prerequisites
.NET 8 SDK

SQL Server (Express edition is sufficient)

An API testing tool like Postman

🔧 Installation & Configuration
Clone the Repository:

git clone [https://github.com/Ahmed-Bahgat-Salama/ViraRank-Back-End.git](https://github.com/Ahmed-Bahgat-Salama/ViraRank-Back-End.git)

Create appsettings.json file:
This file is intentionally excluded from the repository to protect sensitive data. You must create it manually in the root project folder (ViraRankCleanApi). Copy the content below into it.

Note: Make sure the ConnectionStrings match your local SQL Server setup.

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
  "TrendModel": {
    "BaseUrl": "[https://omaraboelmaaty-viral-trend-detector.hf.space/](https://omaraboelmaaty-viral-trend-detector.hf.space/)"
  },
  "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning"}},
  "AllowedHosts": "*"
}

Create the Database:
Open the Package Manager Console in Visual Studio and run the following commands in order:

Add-Migration InitialCreate
Update-Database

Run the Project:
Open the solution in Visual Studio and press the green https run button to start the local development server.

🛠️ Technology Stack
Framework: ASP.NET Core 8

Database: SQL Server with Entity Framework Core 8

Authentication: JWT (JSON Web Tokens)

Architecture: REST API

📖 API Endpoint Documentation
Here are the main endpoints that the client application can consume.

Base URL: The root URL for all endpoints is your local server address (e.g., https://localhost:7224) or the public URL provided by a tunneling service like ngrok.

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
  "githubToken": "ghp_some_token_here"
}

Login Success Response:

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "githubToken": "ghp_some_token_here"
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

/api/users/me

PUT

Yes

Updates the current user's profile.

<details>
<summary>Click to see request/response examples for Users</summary>

Get Profile Success Response:

{
  "id": 1,
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00",
  "gender": true,
  "imageUrl": null
}

Update Profile Request Body (send only the fields you want to change):

{
  "userName": "new_username",
  "imageUrl": "[https://example.com/new_image.png](https://example.com/new_image.png)"
}

</details>

AI Analysis
Endpoint

Method

Authorization

Description

/api/seo/analyze

POST

Yes

Analyzes HTML content for SEO-friendliness.

/api/trend/analyze

POST

Yes

Predicts if a text post is likely to go viral.

<details>
<summary>Click to see request/response examples for AI Analysis</summary>

Analyze SEO Request Body:

{
  "html": "<html>...</html>"
}

Analyze SEO Success Response:

{
  "seo_friendly": true,
  "probability": 0.987,
  "top_class": "Good"
}

Analyze Trend Request Body:

{
  "text": "Everyone is talking about the new AI features, this is going to be huge!",
  "platform": "Twitter"
}

Analyze Trend Success Response:

{
  "viral": true,
  "probability": 0.8746
}
