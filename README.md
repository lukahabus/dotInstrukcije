# dotInstrukcije

This project is a web API for managing professors and subjects in an educational institution. It provides features for registering and logging in professors, creating subjects, retrieving subjects by URL, and scheduling instruction sessions.

Entities
• Professor: Represents a professor in the institution. Fields include Id, Email, Name, Surname, Password, ProfilePictureUrl, and Subjects.
• Subject: Represents a subject taught in the institution. Fields include Id, Title, Url, and Description.
• InstructionSession: Represents a scheduled instruction session. Fields include Id, Date, and ProfessorId.

Setup and Running

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Install the necessary dependencies with dotnet restore.
4. Set up the database with dotnet ef database update.
5. Run the project with dotnet run.

Features
• JWT Authentication: Professors must authenticate with a JSON Web Token (JWT) to access certain routes.
• Professor Registration: New professors can be registered.
• Professor Login: Registered professors can log in.
• Subject Creation: New subjects can be created with a unique title.
• Subject Retrieval: Subjects can be retrieved by their unique URL.
• Instruction Scheduling: Instruction sessions can be scheduled with a specific professor.
