using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Missionary";
        job1._company = "The Church of Jesus Christ of Latter-day Saints";
        job1._startYear = 2017;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Deli Associate";
        job2._company = "Broulims – Driggs, ID";
        job2._startYear = 2021;
        job2._endYear = 2022;

        Job job3 = new Job();
        job3._jobTitle = "Crossroads and Chick-fil-A";
        job3._company = "Crossroads and Chick-fil-A";
        job3._startYear = 2023;
        job3._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "John Brown";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();
    }
}