# 🧸 Toy Robot Simulator (.NET 8 Console App)

This is a C# console application that simulates a toy robot moving on a 5x5 tabletop grid. The robot accepts textual commands to move and rotate on the grid, reporting its position when instructed. The app is built using clean architecture principles with MediatR, FluentValidation, and a pluggable command parser.

---

## ✅ Features

* Command input via console or file
* Supports commands: `PLACE`, `MOVE`, `LEFT`, `RIGHT`, `REPORT`
* Extensible command system using `[CommandKeyword]` attributes
* Input validation using FluentValidation
* Command dispatching via MediatR with pipeline validation behavior
* Dependency injection and logging via .NET `Microsoft.Extensions.*`

---

## 📦 Tech Stack

* .NET 8
* MediatR
* FluentValidation
* Microsoft.Extensions.Logging

---

## 📂 Folder Structure

```
/Commands         → All ICommand implementations (e.g., PlaceCommand)
/Handlers         → MediatR IRequestHandlers for commands
/Validators       → FluentValidation validators for commands
/Infrastructure
  ├── Parsing     → CommandParser and CommandKeywordAttribute
  └── Behaviors   → MediatR pipeline behaviors like ValidationBehavior
/Models           → Core domain models like Robot and Direction
```

---

## 🧪 Sample Input

From the console:

```
PLACE 0,0,NORTH
MOVE
REPORT
```

Output:

```
0,1,NORTH
```

You can also run test data by typing:

```
TESTDATA
```

Or run commands from a file:

```
FILE commands.txt
```

Where `commands.txt` contains:

```
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```

Expected Output:

```
3,3,NORTH
```

---

## ⚙️ Configuration

The tabletop size is configurable via `appsettings.json`:

```json
{
  "TableSettings": {
    "Size": 5
  }
}
```

---

## ✅ Validation Rules

* `PLACE` must include valid X, Y coordinates and a direction
* `MOVE` must keep the robot on the table
* `LEFT`, `RIGHT`, and `REPORT` require the robot to be placed first
* All invalid commands are logged but do not terminate the app

---

## 🚀 Running the Application

1. Restore dependencies:

```bash
dotnet restore
```

2. Run the app:

```bash
dotnet run
```

You can type commands directly or run `TESTDATA` or `FILE <filename>`.

---

## 📦 Required NuGet Packages

Install with:

```bash
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection

dotnet add package FluentValidation

dotnet add package FluentValidation.DependencyInjectionExtensions

dotnet add package Microsoft.Extensions.Logging.Console
```

---

## 🧠 Extending the Simulator

To add a new command:

1. Create a class that implements `ICommand`
2. Add `[CommandKeyword("NEWCOMMAND")]` attribute
3. Implement a `RequestHandler` for the command
4. Add an optional validator

No need to modify the parser — it uses reflection to discover command keywords.

---

## 👨‍💻 Author

Developed as part of a coding challenge to demonstrate clean, extensible C# design using modern .NET practices.
