public class Person
{
    private int HiddenData = 0;
    public string Id { get; }
    public string Name { get; }
    public string LastName { get; }
    public string FullName => $"{Name} {LastName}";
    public int Age => HiddenData >> 4;
    public Sex Sex => (Sex) ((HiddenData & 15) >> 3);
    public Status Status => (Status) ((HiddenData & 7) >> 2);
    public AcademicGrade Grade => (AcademicGrade) (HiddenData & 3);
    public string Password { get; }

    public Person(in string id, in string names, in string lastNames, in int data, in string password)
    {
        Id = id;
        Name = names;
        LastName = lastNames;
        HiddenData = data;
        Password = password;
    }

    public static Person CreateFromLine(string line)
    {
        string[] data = line.Split(";");
        return new Person(data[0], data[1], data[2], int.Parse(data[3]), decimal.Parse(data[4]), data[5]);
    }

    public override string ToString()
    {
        return $"Id: {id}; Name: {FullName}; Age: {Age}; Sex: {Sex}; Status: {Status}; Grade: {Grade}; Password: {Password}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other){
            return id.Equals(other.id);
        }
        return false;
    }

    public string ToWrite()
    {
        return $"{ID};{Name};{LastName};{HiddenData};{Password}";
    }
}

public enum Sex
{
    Male = 0,
    Female = 1
}

public enum Estatus
{
    Single = 0,
    Married = 1
}

public enum Grade
{
    Initial = 0,
    Media = 1,
    Grade = 2,
    PostGrade = 3
}