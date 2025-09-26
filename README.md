# PurgoMalumAPI Test Suite

## Overview

This project tests the PurgoMalumAPI service, which provides profanity filtering for text via JSON, XML, and plain endpoints. The test suite uses [Reqnroll](https://reqnroll.net/) (a fork of SpecFlow) for BDD-style feature testing, integrated with MSTest as the test runner. Tests are written in Gherkin syntax and cover core functionality, error handling, and optional parameters.

## Running the Tests

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 (recommended)
- All referenced NuGet packages restored

### Steps

1. Open the solution in Visual Studio 2022.
2. Build the solution to restore dependencies.
3. Open the **Test Explorer** window.
4. Click **Run All** to execute the test suite.

Alternatively, you can run tests from the command line:
