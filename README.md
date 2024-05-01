# Git Instruction API

This C# .NET 6 minimal API provides a structured way to learn Git commands and collaboration techniques. It is designed specifically for FIRST Robotics Competition (FRC) teams to enhance their software development and version control skills. The API serves different sets of instructions based on the endpoint accessed.

## Overview

The API has endpoints that return instructional content for Git operations, from basic to more advanced scenarios, including handling merge conflicts. Each endpoint corresponds to a set of instructions, numbered from 1 to 4.

## API Endpoints

The API contains the following endpoints, each serving tailored instructions to practice and learn Git:

- **GET `/instructions/1`**
  - Returns basic instructions for creating a new branch and making initial commits.
- **GET `/instructions/2`**
  - Guides through the process of opening and merging a pull request without conflicts.
- **GET `/instructions/3`**
  - Offers a walkthrough on creating a pull request that will result in a merge conflict, and how to resolve it.
- **GET `/instructions/4`**
  - Provides advanced scenarios that involve multiple branches and merging strategies to handle complex workflows.

## Getting Started

To use this API, follow the steps below to set it up on your local machine:

### Prerequisites

- .NET 6 SDK
- A preferred IDE (Visual Studio, VS Code, etc.)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/gatlinfarrington/GitLesson.git
   cd GitLesson
2. Navigate to the API project directory:
   ```bash
   cd instructions
3. Build and run
   ```bash
   dotnet build
   dotnet run
4. Expose API via [NGROK](ngrok.com)
   ```bash
   ngrok http \<port\>
  Where port is the prot that the project is running

the API will start running locally and can be accessed via making a request to localhost from the machine that it is running on, or through the URL that is provided by ngrok. These requestrs are most commonly made through curl in the command line.

   
