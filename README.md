Hello My Name is Saba Burduli and this is my first time ever doing Online Exam ASP.NET Web API . Whats cool in this project is im gonna create 3 type of role ..
and they have different tokens (accses). We dont have actually many entity classes manually but we actually creating meny join tables using configuration querys .
there is many different type of Relations like : Many => Many , Many => One and also ofc One to One ......
Add some Contorlers and tokens .
Imgonna use token for SuperAdmin(can change and create anything) also for teacher (he/she can write points for student result and actualy can see..also can see exams papers early) and the last one student(he/she can only write a exam and can only see resuly).
This Is Project Full Description :
![image](https://github.com/user-attachments/assets/f3f78388-7aff-4703-b678-c66068e61746)
![image](https://github.com/user-attachments/assets/3f918441-dc24-4cea-aa49-173b588fa838)



Hello My Name is Saba Burduli and this is my first time ever doing Online Exam ASP.NET Web API . Whats cool in this project is im gonna create 3 type of role .. and they have different tokens (accses). We dont have actually many entity classes manually but we actually creating meny join tables using configuration querys . there is many different type of Relations like : Many => Many , Many => One and also ofc One to One ...... Add some Contorlers and tokens . Imgonna use token for SuperAdmin(can change and create anything) also for teacher (he/she can write points for student result and actualy can see..also can see exams papers early) and the last one student(he/she can only write a exam and can only see resuly).

Online Exam API The Online Exam API is built using ASP.NET Core and Entity Framework, designed to manage online exams efficiently. This API provides endpoints for handling user authentication, exam creation, question management, result tracking, and more.

Key Features & Functionalities

1. User Management User authentication and authorization (JWT-based). Role-based access control (Admin, Instructor, Student). Profile management.

2. Exam Management Instructors can create, update, and delete exams. Define exam settings like duration, passing criteria, and question randomization. Assign exams to specific students or groups.

3. Question & Answer Management Create multiple-choice, true/false, and open-ended questions. Support for different question difficulty levels. Options for shuffling questions per exam session.

4. Exam Attempt & Submission Students can start, pause, and submit exams within a given time frame. Auto-save feature to prevent data loss. Timer management for live exams.

5. Result & Evaluation System Auto-evaluation for multiple-choice and true/false questions. Instructors can manually grade open-ended questions. Generate exam reports, scores, and performance analysis.

6. Entity Framework & Database Management Uses Entity Framework Core for database interactions. Supports MSSQL with migrations for schema updates. Well-structured entity relationships (User ↔ Exam ↔ Question ↔ Result).

7. Security & Scalability JWT authentication for secure API access. Role-based authorization to control access to different endpoints. Designed for scalability, supporting future integrations with mobile apps or external LMS platforms.
