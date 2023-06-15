using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student : Human
{
    private List<Grade> gradesList = new List<Grade>();
    public List<Grade> GradesList
    {
        get
        {
            return gradesList;
        }
        private set
        {
            gradesList = value;
        }
    }

    private int classNumber;
    public int ClassNumber
    {
        get
        {
            return classNumber;
        }
        private set
        {
            classNumber = value;
        }
    }

    public Student(string fullname = "Без имени", int age = 0, double height = 0, int classNumber = 0) : base(fullname, age, height)
    {
        if (classNumber < 0 || classNumber > 12)
        {
            throw new ArgumentException("Неправильные данные");
        }
             
        this.classNumber = classNumber;

    }

    public int FinalGrade(SubjectType subjectType)
    {
        double result = 0;
        double[] coefficient = { 0.2, 0.2, 0.1, 0.2, 0.3 };
        int workTypesCount = Enum.GetNames(typeof(WorkType)).Length; // находит длину енума SubjectGradeType
        for (int i = 0; i < workTypesCount; i++)
        {
            double averageValue = AverageGradeByType((WorkType)i+1, subjectType); //Получить значения енума по индексу, например Контрол0 по математике, потом хо
            averageValue *= coefficient[i];
            result += averageValue;
        }
        return (int)Math.Round(result);
    }

    public double AverageGradeByType(WorkType workType, SubjectType subjectType)
    {
        double result = 0;
        int count = 0;
        foreach (Grade item in gradesList.Where(x => x.WorkTypeGrade == workType && x.Subject == subjectType)) //выбирает в списке оценок оценки по тем предметам и типу который мы указали
        {
            result += item.GradeValue;
            count++;
        }

        if (count != 0)
        {
            result /= count;
        }

        return result;
    }

    public void AddGrade(Grade mark)
    {
        gradesList.Add(mark);
    }


    public override string Info()
    {
        return base.Info() + "  Класс: " + classNumber;
    }

    public string AllGradesInfo()
    {
        StringBuilder result = new StringBuilder();

        foreach (Grade grade in gradesList)
        {
            result.Append($"{grade.Info()}\n");
        }

        return result.ToString();
    }

    public string GetGradesInfoBySubject(SubjectType subject)
    {
        StringBuilder result = new StringBuilder();

        foreach (Grade grade in gradesList.Where(x => x.Subject == subject))
        {
            result.Append($"{grade.Info()}\n");
        }

        return result.ToString();
    }

    public string GetGradesInfoByWork(WorkType work)
    {
        StringBuilder result = new StringBuilder();

        foreach (Grade grade in gradesList.Where(x => x.WorkTypeGrade == work))
        {
            result.Append($"{grade.Info()}\n");
        }

        return result.ToString();
    }

}

