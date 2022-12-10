using AdventOfCode_2022.Console.Day6;

namespace AdventOfCode_2022.Test.Day6;
public class CommunicationDeviceTests
{

    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    public void FirstMarkerPosition_ShouldReturnCorrectPosition_ForPackageSizeFour(string message, int expected)
    {
        var sut = new CommunicationDevice();
        // Act
        int actual = sut.FirstMarkerPosition(message, 4);

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void FirstMarkerPosition_ShouldReturnCorrectPosition_ForPackageSizeFourteen(string message, int expected)
    {
        var sut = new CommunicationDevice();
        // Act
        int actual = sut.FirstMarkerPosition(message, 14);

        // Assert
        actual.Should().Be(expected);
    }
}
