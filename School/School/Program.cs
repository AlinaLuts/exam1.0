using System;

public class Exam
{
    public static bool IsArrayMinSize(string[] inputArray, int minSize)
    { 
        return inputArray.Length >= minSize;
    }

    public static void LogErrorData()
    {
        Console.WriteLine("Вы ввели некорректные данные.\n");
    }

    public static void LogStudentNotFound()
    {
        Console.WriteLine("Такого студента не существует\n");
    }

    public static void LogTeacherNotFound()
    {
        Console.WriteLine("Такого учителя не существует\n");
    }


    static void Main(string[] args)
    {
        School school = new School();
        
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("Введите AddStudent Ф_И_О возраст рост номер_класса, чтобы добавить ученика");
        Console.WriteLine("Введите StudentInfo Ф_И_О, чтобы посмотреть информацию о нужном ученике");
        Console.WriteLine("Введите ShowAllStudents, чтобы посмотреть информацию о всех учениках");
        Console.WriteLine("Введите ShowListOfSubject, чтобы посмотреть список предметов");
        Console.WriteLine("Введите ShowListOfWorkType, чтобы посмотреть список типов работ");
        Console.WriteLine("Введите AddTeacher Ф_И_О возраст рост предмет(от 1 до 6), чтобы добавить учителя");
        Console.WriteLine("Введите TeacherInfo Ф_И_О, чтобы посмотреть информацию о нужном учителе");
        Console.WriteLine("Введите AddTeacherToStudent Ф_И_О учителя Ф_И_О ученика, чтобы добавить добавить учителю ученика");
        Console.WriteLine("Введите ShowAllTeachers, чтобы посмотреть информацию о всех учителях");
        Console.WriteLine("Введите AddGrade Ф_И_О ученика предмет(от 1 до 6) балл тип_работы(от 1 до 5), чтобы добавить оценку ученику");
        Console.WriteLine("Введите ShowAllStudentMarks Ф_И_О ученика, чтобы посмотреть все оценки ученика");
        Console.WriteLine("Введите ShowGradeBySubject Ф_И_О ученика предмет(от 1 до 6), чтобы посмотреть оценки ученика по определенному предмету");
        Console.WriteLine("Введите ShowGradeByWorkType Ф_И_О ученика тип_работы(от 1 до 5), чтобы посмотреть оценки ученика по типу работы");
        Console.WriteLine("Введите FinalGrade Ф_И_О ученика предмет(от 1 до 6), чтобы посмотреть итоговую оценку ученика");
        Console.WriteLine("Введите AverageTeacherMark Ф_И_О учителя, чтобы найти среднюю оценку из тех, что выставлял этот учитель");
        Console.WriteLine("Введите ShowAllTeacherMarks Ф_И_О учителя, чтобы посмотреть все оценки, которые выставлял этот учитель");
        Console.WriteLine("Введите exit, чтобы выйти\n");

        Console.ResetColor();

        while (true)
        {
            string userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            switch (inputArray[0])
            {
                case "AddStudent":
                    //Console.WriteLine("Напишите Ф_И_О возраст рост номер_класса"); 
                    if(!IsArrayMinSize(inputArray, 5))
                    {
                        LogErrorData();
                        break;
                    }
                       
                    string name = inputArray[1];                    

                    bool ageSuccess = int.TryParse(inputArray[2], out int age);
                    bool heightSuccess = double.TryParse(inputArray[3], out double height);
                    bool classNumberSuccess = int.TryParse(inputArray[4], out  int classNumber);
            
                    if (ageSuccess && heightSuccess && classNumberSuccess)
                    {
                        Student student = new Student(name, age, height, classNumber);
                        school.AddStudent(student);                      
                        Console.WriteLine($"Вы добавили ученика\n");
                    }
                    else
                    {
                        LogErrorData();
                    }

                    break;

                case "StudentInfo":
                    // Console.WriteLine("Напишите Ф_И_О студента");
                    Student studentByName = school.TryGetStudentByName(inputArray[1]);
                    if(studentByName != null)
                    {
                        Console.WriteLine($"{studentByName.Info()}\n");
                    }
                    else
                    {
                        LogStudentNotFound();
                    }

                    break;       
                    
                case "ShowAllStudents":
                    Console.WriteLine(school.GetAllStudentsInfo());
                    break;

                case "AddTeacher":
                    if (!IsArrayMinSize(inputArray, 5))
                    {
                        LogErrorData();
                        break;
                    }

                    string nameTeacher = inputArray[1];

                    bool ageTeacherSuccess = int.TryParse(inputArray[2], out int ageTeacher);
                    bool heightTeacherSuccess = double.TryParse(inputArray[3], out double heightTeacher);
                    bool subjectSuccess = int.TryParse(inputArray[4], out int subject);

                    if (ageTeacherSuccess && heightTeacherSuccess && subjectSuccess)
                    {
                        Teacher teacher = new Teacher(nameTeacher, ageTeacher, heightTeacher, (SubjectType)subject); 
                        school.AddTeacher(teacher);
                        Console.WriteLine($"Вы добавили учителя\n");
                    }
                    else
                    {
                        LogErrorData();
                    }
                    break;

                case "TeacherInfo":
                    Teacher teacherByName = school.TryGetTeacherByName(inputArray[1]);
                    if (teacherByName != null)
                    {
                        Console.WriteLine($"{teacherByName.Info()}\n");
                    }
                    else
                    {
                        LogTeacherNotFound();
                    }
                    break;

                case "AddTeacherToStudent":
                    //Console.WriteLine(Введите учитель ученик);
                    Teacher teacherToAddStudent = school.TryGetTeacherByName(inputArray[1]);
                    if (teacherToAddStudent == null)
                    {
                        LogTeacherNotFound();
                        break;
                    }

                    Student studentForTeacher = school.TryGetStudentByName(inputArray[2]);
                    if (studentForTeacher == null)
                    {
                        LogStudentNotFound();
                        break;
                    }

                    teacherToAddStudent.AddStudent(studentForTeacher);
                    Console.WriteLine("Вы успешно присвоили ученика учителю\n");
                    break;

                case "ShowAllTeachers":
                    Console.WriteLine(school.GetAllTeachersInfo());
                    break;

                case "AddGrade":
                    //Console.WriteLine("Напишите Студент предмет бал тип_работы");
                    //Console.WriteLine(" 0: Алхимия\n 1: Трансфигурация\n 2: Заклинания\n 3: Гербология\n 4: Нумерология\n 5: Астрономия");
                    if (!IsArrayMinSize(inputArray, 5))
                    {
                        LogErrorData();
                        break;
                    }

                    Student studentForGrade = school.TryGetStudentByName(inputArray[1]);
                    if (studentForGrade == null)
                    {
                        LogStudentNotFound();
                        break;
                    }

                    bool studentSubjectSuccess = int.TryParse(inputArray[2], out int studentSubject);
                    bool scoreSuccess = int.TryParse(inputArray[3], out int score);
                    bool studentSubjectTypeSuccess = int.TryParse(inputArray[4], out int studentSubjectType);

                    if(studentSubjectSuccess && scoreSuccess && studentSubjectTypeSuccess)
                    {
                        Grade mark = new Grade((SubjectType)studentSubject, score, (WorkType)studentSubjectType);

                        studentForGrade.AddGrade(mark);
                        Console.WriteLine("Вы добавили оценку ученику\n");
                    }
                    else
                    {
                        LogErrorData();
                    }
                    
                    break;

                case "ShowAllStudentMarks":
                    //команда студент
                    Student studentMarks = school.TryGetStudentByName(inputArray[1]);
                    if (studentMarks == null)
                    {
                        LogStudentNotFound();
                        break;
                    }
                    Console.WriteLine(studentMarks.AllGradesInfo());
                    break;

                case "ShowGradeBySubject":
                    //команда студент предмет
                    if (!IsArrayMinSize(inputArray, 3))
                    {
                        LogErrorData();
                        break;
                    }

                    Student studentMarksBySubject = school.TryGetStudentByName(inputArray[1]);
                    if (studentMarksBySubject == null)
                    {
                        LogStudentNotFound();
                        break;
                    }

                    bool subjectTypeSuccess = int.TryParse(inputArray[2], out int subjectType);
                    if (subjectTypeSuccess)
                    {
                        Console.WriteLine(studentMarksBySubject.GetGradesInfoBySubject((SubjectType)subjectType));
                    }
                    break;

                case "ShowGradeByWorkType":
                    if (!IsArrayMinSize(inputArray, 3))
                    {
                        LogErrorData();
                        break;
                    }

                    Student studentMarksByWork = school.TryGetStudentByName(inputArray[1]);
                    if (studentMarksByWork == null)
                    {
                        LogStudentNotFound();
                        break;
                    }

                    bool workTypeSuccess = int.TryParse(inputArray[2], out int workType);
                    if (workTypeSuccess)
                    {
                        Console.WriteLine(studentMarksByWork.GetGradesInfoByWork((WorkType)workType));
                    }
                    break;

                case "FinalGrade":
                    if (!IsArrayMinSize(inputArray, 3))
                    {
                        LogErrorData();
                        break;
                    }

                    Student studentFinalGrade = school.TryGetStudentByName(inputArray[1]);
                    if (studentFinalGrade == null)
                    {
                        LogStudentNotFound();
                        break;
                    }

                    bool subjectFinalSuccess = int.TryParse(inputArray[2], out int subjectFinal);
                    if (subjectFinalSuccess)
                    {
                        Console.WriteLine($"Итоговая оценка: {studentFinalGrade.FinalGrade((SubjectType)subjectFinal)}\n");
                    }
                    break;

                case "AverageTeacherMark":
                    Teacher teacherAllMarksAverage = school.TryGetTeacherByName(inputArray[1]);
                    if (teacherAllMarksAverage == null)
                    {
                        LogTeacherNotFound();
                        break;
                    }
                    Console.WriteLine($"Cредняя оценка выставленная учителем: \n{teacherAllMarksAverage.GetAllMarksAverage()}\n");
                    break;

                case "ShowAllTeacherMarks":
                    Teacher teacherAllMarks = school.TryGetTeacherByName(inputArray[1]);
                    if (teacherAllMarks == null)
                    {
                        LogTeacherNotFound();
                        break;
                    }
                    Console.WriteLine($"Все оценки выставленные учителем: \n{teacherAllMarks.GetAllTeacherMarksInfo()}");
                    break;

                case "ShowListOfSubject":
                    Console.WriteLine(" 1: Алхимия\n 2: Трансфигурация\n 3: Заклинания\n 4: Гербология\n 5: Нумерология\n 6: Астрономия\n");
                    break;

                case "ShowListOfWorkType":
                    Console.WriteLine(" 1: Домашняя работа\n 2: Контрольная\n 3: Тест\n 4: Экзамен\n 5: Финальный экзамен\n");
                    break;

                case "exit":
                    return;
            }
        }
    }
}
