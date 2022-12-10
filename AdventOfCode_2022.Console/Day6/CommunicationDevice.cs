using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day6;
public class CommunicationDevice
{
    public int FirstMarkerPosition(string message, int packageSize)
    {
        var packages = message.ToCharArray().Window(packageSize);
        int index = packageSize;
        foreach (var package in packages)
        {
            if (package.Distinct().Count() == packageSize)
            {
                return index;
            }
            index++;
        }
        return -1;
    }
}
