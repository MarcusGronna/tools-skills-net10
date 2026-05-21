# Tools and Skills for .NET 10 — Learning Repository

A personal learning project for reading and coding along with the book
**"Tools and Skills for .NET 10"** by **Mark J. Price**.

## About the Book

This book covers the essential tools and skills needed for professional .NET development, including:

- Development environments and tooling (Visual Studio, VS Code, JetBrains Rider)
- .NET CLI and project management
- Testing, debugging, and diagnostics
- Containerisation with Docker
- Databases (SQL Server, etc.)
- Cloud and deployment workflows

## Useful Links

| Resource | Link |
|---|---|
| Official book repository | <https://github.com/markjprice/tools-skills-net10/> |
| All command lines from the book | <https://github.com/markjprice/tools-skills-net10/blob/main/docs/command-lines.md> |
| SQL Server container troubleshooting | <https://github.com/markjprice/tools-skills-net10/blob/main/docs/errata/sql-container-issues.md> |
| Docker `ps` command reference | <https://docs.docker.com/engine/reference/commandline/ps/> |

## Structure

Code and notes are organised by chapter as I work through the book.

## Getting Started

1. Install [.NET 10 SDK](https://dotnet.microsoft.com/download)
2. Clone this repository
3. Navigate to the relevant chapter folder and follow the instructions in the book

## Removing Docker Resources

When you have completed all the chapters in the book, or you plan to use a local SQL Server or Azure SQL Database in the cloud instead of a SQL Server container, and you want to remove all the Docker resources that it uses, then either use the Docker Desktop user interface or follow these steps:

1. Stop the `nw-container` container:
   ```
   docker stop nw-container
   ```

2. Remove the `nw-container` container:
   ```
   docker rm nw-container
   ```
   > **Warning!** Removing the container will delete all data inside it.

3. Remove the image to release its disk space:
   ```
   docker rmi mcr.microsoft.com/mssql/server:2025-latest
   ```
## Updating EF Core
If an old version is installed, then update the tool, as shown in the following command:
dotnet tool update --global dotnet-ef

## Removing EF Core
You can also remove the tool, as shown in the following command:

dotnet tool uninstall --global dotnet-ef

## Notes

Personal notes and observations are kept alongside the code in each chapter folder.
