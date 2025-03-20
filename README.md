

<h1>👂 Hello My Name is Saba Burduli and this is my first time ever doing Online Exam ASP.NET Web API </h1>
<br>
Whats Cool in this project is im gonna create 3 type of role ...<br>

and they have different tokens (accses). We dont have actually many entity classes manually but we actually creating meny join tables using configuration querys .<br>

there is many different type of Relations like : Many => Many , Many => One and also ofc One to One ......<br>
Add some Controlers and tokens .<br>


Imgonna use token for SuperAdmin(can change and create anything) also for teacher (he/she can write points for student result and actualy can see..also can see exams papers early) and the last one student(he/she can 

only write a exam and can only see resuly).<br>

This Is Project Full Description :<br>


<br>

<main aling="center">
	
<h1 aling="center" style="color=🟨">here is Online Exam Description in Text Format : </h1>


 
<h1>✅Online Exam System</h1>




 
![Screenshot 2025-03-05 203539](https://github.com/user-attachments/assets/89e289be-2423-4290-89f0-321fef03d3c0)
<br>

![Screenshot 2025-03-05 203533](https://github.com/user-attachments/assets/b73acdbd-3937-421c-a37a-1a51819d5580)
<br>

![Screenshot 2025-03-05 203526](https://github.com/user-attachments/assets/a88c98cc-493b-4d5e-98c0-c1c3ac76fb11)
<br>

![Screenshot 2025-03-05 203519](https://github.com/user-attachments/assets/8e2f31b1-1b8e-42d0-839d-2eb6fcfece0f)
<br>

![Screenshot 2025-03-05 203544](https://github.com/user-attachments/assets/f8509629-f8b8-4dc1-9d61-089de9357bf0)
<br>

***Project Overview*** :


Develop an online examination system that allows administrators to manage exams, questions, and results. Students can take exams and view their scores.



	<h2>🙋User</h2>
	 	UserId: int
		Username: string
		PasswordHash: string
		Email: string
		RegistrationDate: datetime
		PersonId: int
		ICollection<Exam> Exams 
		ICollection<Result> Results



	<h2👏>Role</h2>
		RoleId: int
		RoleName: string (admin, teacher, student)
		


	<h2>📚Exam</h2>
		ExamId: int
		Title: string
		UserId: int (Teacher)
		Questions: ICollection<Question>
		Results: ICollection<Result>


	<h2>⁉️Question</h2>
		Id: int
		Content: string
		CorrectAnswer: string
		ExamId: int (foreign key)
		Exam: Exam (navigation property)
		Options: ICollection<string> (optional, if multiple choice is needed)


  
  	<h2>💢Option</h2>
	 	Id: int
		Content: string
		IsCorrect: bool
		QuestionId: int (foreign key)


 
	<h2>✅Result</h2>
		Id: int
		StudentId: int (foreign key)
		Student: User (navigation property)
		ExamId: int (foreign key)
		Exam: Exam (navigation property)
		Score: decimal(8,2)
		DateTaken: DateTime



	<h2>📚🙋ExamParticipant</h2>
		Id: int
		ExamId: int (foreign key)
		UserId: int (foreign key)





<br>

<br>



<h1>💢Interfaces</h1>
<br>

<h2>⚪IUserService </h2>

<ol>

<li> void AddUser(User user);</li>

<li> User Login(string username, string password);</li>

<li> void AssignRole(int userId, int roleId);</li>

<li> User GetUserById(int userId);</li>

</ol>



<h2>⚪IExamService</h2>


<ol>

	
<li> void CreateExam(Exam exam);</li>


	
<li> void AddQuestion(int examId, Question question);</li>



<li> Exam GetExam(int examId);<li>


	
<li> IEnumerable<Exam> GetExamsByTeacher(int teacherId);</li>
		
</ol>		



<br>

<h2>⚪IResultService </h2>

<ol>
	
<li> void SubmitResult(Result result);</li>

	
<li> IEnumerable<Result> GetResultsByStudent(int studentId);</li>

	
<li> Result GetResult(int examId, int studentId);</li>

</ol>


<br>

<h1>💢Services</h1>

<ol>
	
 <li> ✅UserService</li>
	Handles user authentication and role assignment.


<li> ✅ExamrService</li>
	Manages exam creation, question addition, and retrieval.

<li> ✅ResultService</li>
	Handles result submission and retrieval
 
</ol>



<br>

</main>


<br>


Online Exam API The Online Exam API is built using ASP.NET Core and Entity Framework, designed to manage online exams efficiently. This API provides endpoints for handling user authentication, exam creation, question management, result tracking, and more.


 Key Features & Functionalities :
 

1. **User Management User authentication and authorization (JWT-based).** Role-based access control (Admin, Instructor, Student). Profile management.


   **Exam Management Instructors can create, update, and delete exams.** Define exam settings like duration, passing criteria, and question randomization. Assign exams to specific students or groups.

   

3. **Question & Answer Management Create multiple-choice, true/false, and open-ended questions.** Support for different question difficulty levels. Options for shuffling questions per exam session.
4. 

   
5. **Exam Attempt & Submission Students can start, pause, and submit exams within a given time frame.**  Auto-save feature to prevent data loss. Timer management for live exams.



6. **Result & Evaluation System Auto-evaluation for multiple-choice and true/false questions.** Instructors can manually grade open-ended questions. Generate exam reports, scores, and performance analysis.


7. **Entity Framework & Database Management Uses Entity Framework Core for database interactions.** Supports MSSQL with migrations for schema updates. Well-structured entity relationships (User ↔ Exam ↔ Question ↔ Result).


8. **Security & Scalability JWT authentication for secure API access. Role-based authorization to control access to different endpoints.** Designed for scalability, supporting future integrations with mobile apps or external LMS platforms.


<br>

--------------------------------------------------------------------------------------------------------------------------------------------------------------

<br>
<br>
   From Comic Solvency (Me) 👽
<br>
<br>

 📥  If you want to learn more about This Project you can actually contact me on Mail : **sabagg790@gmail.com**


