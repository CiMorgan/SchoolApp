## SchoolApp

### The School WebAPI provides school administrators and staff access to their student and teacher records and links them to courses, extracurricular activities, and discipline records.

#### Table of Contents
1. Description
1. Installation
1. Usage
1. Credits
1. License

#### 1. Description
The School WebAPI allows school administrators and staff to connect their students and teachers with courses, extracurricular activities, and disciplinary infractions. The user will be able to see all students and their grade level, and view the details (name, grade level, courses, and extracurricular activities) for a specific student. The users can also view all teachers and their departments, along with the details (name, department, courses taught, and extracurricular activities) for a specific teacher. For courses, the user will be able to see a list of all courses plus, for a specific course, determine the students enrolled in that course and the teacher(s) that teach the course. For extracurricular activities, the user will be able to see a list of all extracurricular activities and their duration (season), and for a specific activity, view a list of participating students and the lead teacher. For discipline, the user will be able to retrieve the number of each type of infraction, view the details of a specific infraction, and view infraction(s) by date. All major features allow the user to identify trends, determine potential shortfalls, and respond appropriately to best meet the needs of the school environment. 

The School WebAPI connects five data tables: Student, Teacher, Course, Activity, and Discipline.

#### 2. Installation 
SchoolApp is a .NET Framework web application built using Visual Studio with Entity Framework 6, Bootstrap, and jquery. Endpoints were tested using Postman. It uses C#, Javascript, and HTML.

#### 3. Usage: 
The following endpoints are used to add, update, delete, and retrieve information from the various databases.

* Student Database
  * (Post) api/Student - This endpoint creates a new student. In the body, it requires Id (int), FirstName (string), LastName (string), and GradeLevel.
  * (Get) api/Student - This endpoint returns a list of all students with the student id, name, and grade level.
  * (Get) api/Student - This endpoint returns the student id, name, grade level, list of courses, and list of activities for a specific student. It requires the Id (int) in the uri.
  * (Put) api/Student - This endpoint updates a student. The body requires Id (int), FirstName (string), LastName (string), and GradeLevel.
  * (Delete) api/Student/{id} - This endpoint allows the user to delete a student. It requires the (student) Id (int) in the uri.
   
* Teacher Database
  * (Post) api/Teacher - This endpoint creates a teacher. In the body, it requires TeacherId (int), FirstName (string), LastName (string), and Department (enum). The user can also add TeacherActivity (string) and/or TeacherCourse (string) to include the activities and/or courses in which the teacher is involved.
  * (Get) api/Teacher - This endpoint returns a list of all teachers with teacher id, teacher name, and department.
  * (Get) api/Teacher/{id} - This endpoint returns the teacher id, name, department, course list, and activity list for a specific teacher. It requires the TeacherId (int) in the uri.
  * (Put) api/Teacher - This endpoint updates a teacher. In the body, it requires TeacherId (int), FirstName (string), LastName (string), and Department (enum). The user can also add ActivityLead (int) and/or ListOfCourses (int) to update the activities and/or courses in which the teacher is involved.
  * (Put) api/Teacher/{id}/Course - This endpoint adds course(s) to a teacher. The uri requires the TeacherId (int), while the body requires TeacherCourseList (int).
  * (Delete) api/Teacher/{id} - This endpoint allows the user to delete a teacher. It requires the TeacherId (int) in the uri.
  
* Course Database
  * (Post) api/Course - This endpoint creates a course, allowing the user to choose a name for the course and placing it into an established department. The user has the option of adding teachers and/ or students at this time. The body requires Id (int), Name (string), and Department (enum). The user can also add TeacherList (int) and/or StudentList (int) to enter the teacher(s) for the course and/or the students enrolled in the course. 
  * (Get) api/Course - This endpoint returns a list of all courses with the course id, name, and its department.
  * (Get) api/Course/{id} - This endpoint returns returns the course id, name, department, list of teachers, and list of teachers for a specific course. It requires the CourseId (int) in the uri.
  * (Put) api/Course - This endpoint updates a course's name and/or department. The user has the option of adding teachers and/or students at this time. The body requires CourseId (int), CourseName (string), and CourseDepartment (enum). The user can also add CourseTeacher (int) and/or CourseStudent (int) to enter the teacher(s) for the course and/or the students enrolled in the course.
  * (Put) api/Course/{id}/Student - This endpoint adds a student(s) to a course that exists. The uri requires the CourseId (int), while the body requires StudentCourseList (int). 
  * (Put) api/Course/{id}/Teacher - This endpoint adds a teacher(s) to a course that exists. The uri requires the CourseId (int), while the body requires TeacherCourseList (int). 
  * (Delete) api/Course/{id} - This endpoint allows the user to delete a course. It requires the CourseId (int) in the uri.
  
* Activity Database
  * (Post) api/Activity - This endpoint creates an activity. The body requires Id (int), Name (enum), and Duration (enum) of the activity.  
  * (Get) api/Activity - This endpoint returns a list of all activities with the activity id, name, and the season in which the activity occurs.
  * (Get) api/Activity/{id} - This endpoint returns the activity id, name, the season in which the activity occurs, the lead teacher, and a list of students incolved in the activity.  It requires the ActiviyId (int) in the uri.
  * (Put) api/Activity - This endpoint allows the user to update an already created activity. In the body, it requires an ActivityId (int), ActivityName (enum) and ActivityDuration (enum) and can also be used to add a teacher (ActivityTeacherId, an int).
  * (Put) api/Activity/{id}/Student - This endpoint allows the user to add students to an activity.  The uri requires the ActivityId (int), while the body requires StudentActivityList (int).
  * (Put) api/Activity/{id}/Teacher - This endpoint adds a teacher to an activity that exists. The uri requires the ActivityId (int), while the body requires TeacherActivityList (int).
  * (Delete) api/Activity/{id} - This endpoint allows the user to delete an activity. It requires the CourseId (int) in the uri.
  
* Discipline Database
  * (Post) api/Discipline - This endpoint creates a discipline record. In the body, it requires a DisciplineId (int), StudentId (int), Comment (string), Expelled (bool), DisciplineType (enum). It will also create a DateTime for when is was entered.
  * (Get) api/Discipline - This endpoint returns id, student name, comment, discipline type, expuilsion status, and time.
  * (Get) api/Discipline/{id} - This endpoint returns id, student name, comment, discipline type, expuilsion status, and time. It requires DisciplineId (int) in the uri.
  * (Put) api/Discipline - This endpoint updates a discipline record. In the body, it requires a DisciplineId (int), Comment (string), Expelled (bool), DisciplineType (enum). It will also create a DateTime for when is was modified.
  * (Put) api/Discipline/{id}/Student - This endpoint updates a discipline record. It requires a DisciplineId (int) in both the uri and the body.
  * (Delete) api/Discipline/{id} - This endpoint allows the user to delete a discipline. It requires the DisciplineId (int) in the uri.

#### 4. Credits: School web application for administrators built by Team Room 11 for completion of Blue Badge at Eleven Fifty Academy.
* Members of Team 11:
  * Nikki Grostefon
  * Cindy Morgan
  * Ben Thomas

* References used include:
  *  https://docs.microsoft.com/en-us/aspnet/overview
  *  https://docs.microsoft.com/en-us/ef/
  *  https://www.entityframeworktutorial.net/

#### 5. License
Although it is operational, this project is not yet ready for primetime.
