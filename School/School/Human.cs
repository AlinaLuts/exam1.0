using System;

public class Human
{
    private string fullname;
    public string Fullname
    {
        get
        {
            return fullname;
        }
        private set
        {
            fullname = value;
        }
    }

    private int age;
    public int Age
    {
        get
        {
            return age;
        }
        private set
        {
            age = value;
        }
    }

    private double height;
    public double Height
    {
        get
        {
            return height;
        }
        private set
        {
            height = value;
        }
    }

    public Human()
    {
        fullname = "Без имени";
        age = 0;
        height = 0;
    } 

    public Human(string fullname, int age, double height)
    {
        if (age < 0 || height < 0)
        {
            throw new ArgumentException("Неправильные данные");
        }
        this.fullname = fullname;
        this.age = age;
        this.height = height;
    }

    public virtual string Info()
    {
        string nameCorrected = fullname.Replace("_", " ");
        return $"ФИО: {nameCorrected} Возраст: {age} Рост: {height}";
    }
}
    
