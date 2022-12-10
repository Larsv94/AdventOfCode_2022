using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day6;

public class Day6Solution : ISolution
{
    public int Day => 6;
    public object SolvePartOne(string[] input)
    {

        var communicationDevice = new CommunicationDevice();
        return communicationDevice.FirstMarkerPosition(input.First(), 4);
    }

    public object SolvePartTwo(string[] input)
    {

        var communicationDevice = new CommunicationDevice();
        return communicationDevice.FirstMarkerPosition(input.First(), 14);
    }
}