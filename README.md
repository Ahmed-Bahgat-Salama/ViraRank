<div align="center">
<h1>ViraRank API - Backend Service 🚀</h1>
<p>
The official backend service for the ViraRank application, built with ASP.NET Core 8. It provides a robust REST API for user management, authentication, and AI-powered analysis for both SEO and viral trends.
</p>

<p>
<img src="https://img.shields.io/badge/.NET-8.0-blueviolet" alt=".NET 8.0">
<img src="https://img.shields.io/badge/Entity%20Framework-Core-blue" alt="EF Core">
<img src="https://img.shields.io/badge/SQL%20Server-Used-red" alt="SQL Server">
<img src="https://img.shields.io/badge/Authentication-JWT-green" alt="JWT Authentication">
</p>
</div>

---

📋 **Table of Contents**
- [Getting Started](#-getting-started)
- [Prerequisites](#prerequisites)
- [Installation & Configuration](#-installation--configuration)
- [Technology Stack](#️-technology-stack)
- [API Endpoint Documentation](#-api-endpoint-documentation)
  - [Authentication](#authentication)
  - [Users](#users)
  - [AI Analysis](#ai-analysis)
- [Contributing](#-contributing)

---

## 🏁 Getting Started
Follow these steps to get the project up and running on your local machine for development and testing.

### Prerequisites
- .NET 8 SDK  
- SQL Server (Express edition is sufficient)  
- An API testing tool like Postman  

---

## 🔧 Installation & Configuration

**1. Clone the Repository:**
```bash
git clone https://github.com/Ahmed-Bahgat-Salama/ViraRank-Back-End.git
```

**2. Create `appsettings.json`:**  
This file is excluded from the repository. You must create it manually in the root project folder (`ViraRankCleanApi`).  

Example:
```json
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
    "BaseUrl": "https://omaraboelmaaty-seo-rank-classifier.hf.space/"
  },
  "TrendModel": {
    "BaseUrl": "https://omaraboelmaaty-viral-trend-detector.hf.space/"
  },
  "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning"}},
  "AllowedHosts": "*"
}
```

**3. Create the Database:**  
In Visual Studio → Package Manager Console:
```bash
Add-Migration InitialCreate
Update-Database
```

**4. Run the Project:**  
Open the solution in Visual Studio and press the green **https run** button.

---

## 🛠️ Technology Stack
- **Framework:** ASP.NET Core 8  
- **Database:** SQL Server with Entity Framework Core 8  
- **Authentication:** JWT (JSON Web Tokens)  
- **Architecture:** REST API  

---

## 📖 API Endpoint Documentation
Base URL: `https://localhost:7224` (or via tunneling like ngrok)

---

### 🔑 Authentication
| Endpoint | Method | Auth | Description |
|----------|--------|------|-------------|
| `/api/auth/register` | POST | ❌ | Registers a new user |
| `/api/auth/login` | POST | ❌ | Logs in a user and returns a JWT |
| `/api/auth/change-password` | POST | ✅ | Changes the current user's password |

<details>
<summary>Request/Response Examples</summary>

**Register Request**
```json
{
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00Z",
  "gender": true,
  "password": "Password123!",
  "githubToken": "ghp_some_token_here"
}
```

**Login Response**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "githubToken": "ghp_some_token_here"
}
```

**Change Password Request**
```json
{
  "oldPassword": "CurrentPassword123!",
  "newPassword": "NewStrongPassword456!",
  "confirmNewPassword": "NewStrongPassword456!"
}
```
</details>

---

### 👤 Users
| Endpoint | Method | Auth | Description |
|----------|--------|------|-------------|
| `/api/users/me` | GET | ✅ | Fetch current user profile |
| `/api/users/me` | PUT | ✅ | Update current user profile |

<details>
<summary>Request/Response Examples</summary>

**Get Profile Response**
```json
{
  "id": 1,
  "userName": "test_user",
  "email": "test@example.com",
  "birthDate": "2000-01-01T00:00:00",
  "gender": true,
  "imageUrl": null
}
```

**Update Profile Request**
```json
{
  "userName": "new_username",
  "imageUrl": "https://example.com/new_image.png"
}
```
</details>

---

### 🤖 AI Analysis
| Endpoint | Method | Auth | Description |
|----------|--------|------|-------------|
| `/api/seo/analyze` | POST | ✅ | Analyzes HTML content for SEO |
| `/api/trend/analyze` | POST | ✅ | Predicts if text post is likely to go viral |

<details>
<summary>Request/Response Examples</summary>

**SEO Request**
```json
{
  "html": "<html>...</html>"
}
```

**SEO Response**
```json
{
  "seo_friendly": true,
  "probability": 0.987,
  "top_class": "Good"
}
```

**Trend Request**
```json
{
  "text": "Everyone is talking about the new AI features, this is going to be huge!",
  "platform": "Twitter"
}
```

**Trend Response**
```json
{
  "viral": true,
  "probability": 0.8746
}
```
</details>

---

## 🤝 Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
