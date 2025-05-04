int examAssignments = 5;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

int[] studentScores = new int[10];

string currentStudentLetterGrade = "";

Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;

    int sumExamScores = 0;
    int sumExtraCreditScores = 0;
    decimal sumOverallScores = 0;

    decimal currentExamScore = 0;
    decimal currentOverallScore = 0;
    decimal currentExtraAssignmentScore = 0;
    decimal currentExtraCreditPoint = 0;

    int gradedAssignments = 0;

    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
        {
            sumExamScores += score;
            sumOverallScores += score;
        }
        else
        {
            sumExtraCreditScores += score;
            sumOverallScores += (decimal)score / 10;
        }
    }

    currentExamScore = (decimal)sumExamScores / examAssignments;
    currentOverallScore = (decimal)sumOverallScores / examAssignments;

    if (sumExtraCreditScores != 0)
    {
        currentExtraAssignmentScore = (decimal)sumExtraCreditScores / (gradedAssignments - examAssignments);
        currentExtraCreditPoint = ((decimal)sumExtraCreditScores / 10) / examAssignments;
    }

    if (currentOverallScore >= 97)
        currentStudentLetterGrade = "A+";

    else if (currentOverallScore >= 93)
        currentStudentLetterGrade = "A";

    else if (currentOverallScore >= 90)
        currentStudentLetterGrade = "A-";

    else if (currentOverallScore >= 87)
        currentStudentLetterGrade = "B+";

    else if (currentOverallScore >= 83)
        currentStudentLetterGrade = "B";

    else if (currentOverallScore >= 80)
        currentStudentLetterGrade = "B-";

    else if (currentOverallScore >= 77)
        currentStudentLetterGrade = "C+";

    else if (currentOverallScore >= 73)
        currentStudentLetterGrade = "C";

    else if (currentOverallScore >= 70)
        currentStudentLetterGrade = "C-";

    else if (currentOverallScore >= 67)
        currentStudentLetterGrade = "D+";

    else if (currentOverallScore >= 63)
        currentStudentLetterGrade = "D";

    else if (currentOverallScore >= 60)
        currentStudentLetterGrade = "D-";

    else
        currentStudentLetterGrade = "F";

    Console.WriteLine($"{currentStudent}\t\t{currentExamScore}\t\t{currentOverallScore}\t{currentStudentLetterGrade}\t{currentExtraAssignmentScore} ({currentExtraCreditPoint} pts)");
}

Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();