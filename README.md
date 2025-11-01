# Run tests with verbose output
dotnet test --logger "console;verbosity=detailed" tests/TDD.Tests/

# Run specific test project
dotnet test tests/TDD.Tests/

# Watch mode (runs tests on file changes)
dotnet watch test --project tests/TDD.Tests/
