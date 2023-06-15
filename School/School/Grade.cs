using System;

public enum WorkType
{ Homework = 1, Control, Test, Exam, FinalExam }

public enum SubjectType
{ Alchemy = 1, Transfiguration, Spells, Herbology, Numerology, Astronomy }

public class Grade
{
    private SubjectType subject = SubjectType.Alchemy;
    public SubjectType Subject
    {
        get
        {
            return subject;
        }
        private set
        {
            subject = value;
        }
    }
    private int grade;
    public int GradeValue
    {
        get
        {
            return grade;
        }
        private set
        {
            grade = value;
        }
    }

    private WorkType workType;
    public WorkType WorkTypeGrade
    {
        get
        {
            return workType;
        }
        private set
        {
            workType = value;
        }
    }
    public Grade(SubjectType subject = SubjectType.Spells, int grade = 0, WorkType workType = WorkType.Homework)
    {
        if ( grade < 0 || grade > 12 || (int)subject > Enum.GetNames(typeof(SubjectType)).Length || (int)subject < 1 || (int)workType > Enum.GetNames(typeof(WorkType)).Length || (int)workType < 1)
        {
            throw new ArgumentException("Некоректная оценка");
        }
        this.subject = subject;
        this.grade = grade;
        this.workType = workType;
    }

    public string Info()
    {
        return $"Предмет: {subject}, Оценка {grade}, Вид работы: {workType}";
    }

}

