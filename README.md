# Flashcard Management System

## Description
This Flashcard Management System is a C# console application for creating and managing stacks of flashcards. Ideal for study purposes, it allows users to create customized flashcards, organize them into stacks, and conduct study sessions. The application uses SQL Server for robust data management and demonstrates the practical use of Data Transfer Objects (DTOs) in a C# environment.

## Features
- **Create and Manage Flashcard Stacks:** Users can create stacks with unique names and manage flashcards within them.
- **Study Sessions:** Facilitates study sessions with flashcards, including tracking and storage of session data like date and score.
- **Data Consistency:** Implements cascading delete operations; removing a stack also deletes related flashcards and study sessions.
- **DTOs Usage:** Employs DTOs for presenting flashcard data without exposing internal identifiers.

## Getting Started

### Prerequisites
- .NET SDK
- SQL Server (not SQL Server EXPRESS)

### Installation
1. Clone the repository:
   ```
   git clone [repository-url]
   ```
2. Navigate to the project directory:
   ```
   cd YourProjectName
   ```
3. Build the project:
   ```
   dotnet build
   ```

### Running the Application
Run the application using the .NET CLI:
```
dotnet run
```

## Usage
After launching the application, follow the on-screen instructions to navigate through the menu. You can create flashcard stacks, add flashcards to them, and initiate study sessions.
