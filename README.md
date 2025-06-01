JwtAuthProvider
JwtAuthProvider is a .NET 8 Web API project that provides JWT (JSON Web Token) authentication services. It is designed to help secure your applications by issuing and validating JWT tokens, making it easy to implement authentication and authorization in your .NET solutions.
Features
•	Built with .NET 8
•	JWT token generation and validation
•	RESTful API endpoints for authentication
•	Integration with Swashbuckle (Swagger) for API documentation
•	Unit and integration tests using xUnit and Moq
Getting Started
1.	Clone the repository
Use your preferred method to clone this repository to your local machine.
2.	Restore dependencies
Run dotnet restore in the project directory to install all required NuGet packages.
3.	Configure settings
Update the appsettings.json file with your JWT settings and other configuration as needed.
4.	Run the application
Use dotnet run or start the project in Visual Studio 2022.
5.	Access API documentation
Once running, navigate to the Swagger UI (usually at /swagger) to explore and test the API endpoints.
Project Structure
•	Controllers: API endpoints for authentication and token management
•	Infrastructure/Authentication: Core JWT logic and interfaces
•	Properties: Launch settings for development
•	appsettings.json: Application configuration
•	Tests: Unit and integration tests in the JwtAuthProvider.Tests project
Testing
This project uses xUnit and Moq for testing. To run tests, use the following command in the test project directory:
dotnet test
Dependencies
•	Microsoft.NET.Test.Sdk
•	Moq
•	Swashbuckle.AspNetCore
•	System.IdentityModel.Tokens.Jwt
•	xunit
•	xunit.runner.visualstudio
Contributing
Contributions are welcome! Please open issues or submit pull requests for any improvements or bug fixes.
License
This project is licensed under the MIT License.
