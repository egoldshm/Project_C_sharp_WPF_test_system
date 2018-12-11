using System;

public class Tester
{
    private int id;//has to appear
    private string? lastName;
    private string? firstName;
    private DateTime dateOfBirth;
    private Gender gender;
    private long phoneNumber;
    private string address;
    private int yearsOfExperience;
    private int maxWeeklyTests;
    private CarType carType;
    private bool [,] workDays = new bool [5, 6];
    private float maxDistance;

    public Tester()
    {

    }

    public override string ToString()
    {
            return firstName + " " + familyName;
     }
}
