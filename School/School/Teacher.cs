using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Teacher : Human
{
    private SubjectType subject;
    private List<Student> studentList = new List<Student>();
    public List<Student> StudentList
    {
        get
        {
            return studentList;
        }
        private set
        {
            studentList = value;
        }
    }
    public Teacher(string fullname = "Без имени", int age = 0, double height = 0, SubjectType subject = SubjectType.Spells) : base(fullname, age, height)
    {
        if ((int)subject > Enum.GetNames(typeof(SubjectType)).Length || (int)subject < 1)
        {
            throw new ArgumentException("Неправильные данные");
        }

        this.subject = subject;
    }

    public double GetAllMarksAverage()
    {
        double result = 0;
        int count = 0;
        //У Студента взять оценки по тому предмету который ведет нужный нам учитель
        foreach (Student student in studentList)
        {
            foreach (Grade grade in student.GradesList.Where(x => x.Subject == subject))
            {
                result += grade.GradeValue;
                count++;
            }

            /*
            for(int j = 0; j < studentList.Count; j++)
            {
                for(int i = 0; i < studentList[j].GradeList.Count; i++)
                {
                    if(studentList[j].GradeList[i].Subject == subject)
                    {
                        result += studentList[j].GradeList[i].GradeValue;
                        count++;
                    }
                }
            }
            */
        }

        if (count != 0)
        {
            result /= count;
        }
        return result;
    }

    public void AddStudent(Student student) //добавляет одного студенту в студентЛист учителя
    {
        studentList.Add(student);
    }

    public void AddStudentsList(List<Student> studentList) // добавляет в студентЛист учителя сразу список(массивчик) студентов
    {
        this.studentList.AddRange(studentList);
    }

    public void AssignStudentList(List<Student> studentList) // меняет старых студентов на новых, переприсваивает студентЛист
    {
        this.studentList = studentList;
    }

    public override string Info()
    {
        return base.Info() + "  Предмет: " + subject;
    }

    public string GetAllTeacherMarksInfo()
    {
        StringBuilder result = new StringBuilder();

        foreach (Student student in studentList)
        {
            foreach (Grade grade in student.GradesList.Where(x => x.Subject == subject))
            {
                result.Append($"{grade.Info()}\n");
            }           
        }

        if(result == null)
        {
            result.Append("Учитель не выставлял оценок\n");
        }

        return result.ToString();
    }

}
