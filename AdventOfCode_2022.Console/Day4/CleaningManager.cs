namespace AdventOfCode_2022.Console.Day4;
public class CleaningManager
{
    public bool IsPairFullyOverlapping(int[] person1, int[] person2)
    {
        return HasFullOverlap(person1, person2) || HasFullOverlap(person2, person1);
    }

    public bool IsPartiallyOverlapping(int[] person1, int[] person2)
    {
        return person2[0] <= person1[1]
            && person1[0] <= person2[1];
    }

    private bool HasFullOverlap(int[] first, int[] second)
    {
        return second[0] <= first[1]
            && first[0] <= second[1]
            && first[0] <= second[0]
            && second[1] <= first[1];
    }
}
