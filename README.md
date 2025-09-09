ViraRank API - Backend
Welcome to the backend for the ViraRank application. This project is built with ASP.NET Core 8 and provides an API for user management, authentication, and AI-powered SEO analysis.

🚀 Getting Started
To run this project on your local machine, follow these steps in order.

Prerequisites
.NET 8 SDK

SQL Server (Express edition is sufficient)

An API testing tool like Postman

Installation & Configuration
Clone the Repository:
Clone this repository to your local machine using the following command:

git clone [https://github.com/Ahmed-Bahgat-Salama/ViraRank.git](https://github.com/Ahmed-Bahgat-Salama/ViraRank.git)

Create appsettings.json file:
This file is intentionally excluded from the repository to protect sensitive information. You must create it manually in the root project folder (ViraRankCleanApi). Copy and paste the following content into it:

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
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Important Note: Make sure the ConnectionStrings match your local SQL Server configuration.

Create the Database:
Open the Package Manager Console in Visual Studio and run the following commands in order:

Add-Migration InitialCreate
Update-Database

Run the Project:
Open the project in Visual Studio and press the green https run button.

📖 API Endpoint Documentation
These are the main endpoints that the Flutter client application can consume.

Authentication
1. Register a New User
Method: POST

URL: /api/auth/register

Body (JSON):

{
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00Z",
  "gender": true,
  "password": "Password123!",
  "githubToken": "some_token_here"
}

2. Log In
Method: POST

URL: /api/auth/login

Body (JSON):

{
  "email": "test@example.com",
  "password": "Password123!"
}

Success Response (200 OK):

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "githubToken": "some_token_here"
}

3. Change Password
Method: POST

URL: /api/auth/change-password

Authorization: Bearer <Your_JWT_Token> (Required)

Body (JSON):

{
  "oldPassword": "CurrentPassword123!",
  "newPassword": "NewStrongPassword456!",
  "confirmNewPassword": "NewStrongPassword456!"
}

Success Response: 204 No Content

Users
1. Get Current User Profile
Method: GET

URL: /api/users/me

Authorization: Bearer <Your_JWT_Token> (Required)

Success Response (200 OK):

{
  "id": 1,
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00",
  "gender": true,
  "imageUrl": null
}

SEO Analysis
1. Analyze HTML Content
Method: POST

URL: /api/seo/analyze

Authorization: Bearer <Your_JWT_Token> (Required)

Body (JSON):

{
  "html": "<html>...</html>"
}

Success Response (200 OK):

{
    "seo_friendly": true,
    "probability": 0.987,
    "top_class": "Good"
}
