# RealTimeChatAPI

A real-time chat application built with ASP.NET Core Web API, SignalR, and SQL Server.

## GitHub Repository

[View RealTimeChatAPI on GitHub](https://github.com/moataz-madyan/RealTimeChatAPI)

## Features

- Send and receive messages in real time.
- Broadcast messages to connected clients using SignalR.
- Store messages in SQL Server.
- Retrieve saved messages through REST API endpoints.
- Validate message content and sender names.
- Simple HTML, CSS, and JavaScript chat interface.

## Technologies Used

- C#
- .NET 9
- ASP.NET Core Web API
- SignalR
- Entity Framework Core
- SQL Server
- Swagger
- HTML, CSS, and JavaScript

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Messages` | Retrieve all saved messages |
| POST | `/api/Messages` | Create and save a message |

## SignalR Hub

Hub URL: `/chatHub`

The `SendMessage` method saves each message to the database and broadcasts it to connected clients through the `ReceiveMessage` event.

## How to Run

1. Install the .NET 9 SDK and SQL Server Express.
2. Clone the repository:

   ```bash
   git clone https://github.com/moataz-madyan/RealTimeChatAPI.git
   ```

3. Open the project folder in VS Code.
4. Configure the SQL Server connection string in `appsettings.json`.
5. Run the application:

   ```bash
   dotnet restore
   dotnet run
   ```

6. Open `/swagger` using the local URL printed in the terminal.
7. Open `/chat.html` using the same local URL to test the chat.

## Testing

- Use Swagger to create messages with `POST /api/Messages`.
- Retrieve saved messages using `GET /api/Messages`.
- Open the chat page in two browser tabs to test real-time messaging.

## Author

**Moataz Madyan**

GitHub: [moataz-madyan](https://github.com/moataz-madyan)
