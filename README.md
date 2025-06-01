## 🔐 JwtAuthProvider
JwtAuthProvider is a .NET 8 Web API project that provides robust JWT (JSON Web Token) authentication services. It is designed to help secure your applications by issuing and validating JWT tokens, simplifying the implementation of authentication and authorization in your .NET solutions.

🚀 Features
✅ Built with .NET 8
🔐 JWT token generation and validation
📡 RESTful API endpoints for authentication
📘 Integrated with Swashbuckle (Swagger) for API documentation
🧪 Unit and integration tests using xUnit and Moq
🛠️ Getting Started
1. Clone the Repository
bash
git clone https://github.com/your-username/JwtAuthProvider.git
cd JwtAuthProvider
2. Restore Dependencies
bash
dotnet restore
3. Configure Settings
Update the appsettings.json file with your JWT configuration and other necessary settings.

4. Run the Application
bash
dotnet run
Or open the project in Visual Studio 2022 and start debugging.

5. Access API Documentation
Once running, navigate to:

Code
https://localhost:{port}/swagger
Explore and test the API endpoints using Swagger UI.

📁 Project Structure
Code
JwtAuthProvider/
├── Controllers/               # API endpoints for authentication and token management
├── Infrastructure/
│   └── Authentication/        # Core JWT logic and interfaces
├── Properties/                # Launch settings for development
├── appsettings.json           # Application configuration
├── JwtAuthProvider.Tests/     # Unit and integration tests
🧪 Testing
This project uses xUnit and Moq for unit and integration testing.

To run the tests:

bash
cd JwtAuthProvider.Tests
dotnet test
📦 Dependencies
Microsoft.NET.Test.Sdk
Moq
Swashbuckle.AspNetCore
System.IdentityModel.Tokens.Jwt
xunit
xunit.runner.visualstudio
🤝 Contributing
Contributions are welcome! Feel free to:

Open issues
Submit pull requests
📄 License
This project is licensed under the MIT License.
