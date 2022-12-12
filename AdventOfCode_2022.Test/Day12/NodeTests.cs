using AdventOfCode_2022.Console.Day12;

namespace AdventOfCode_2022.Test.Day12;
public class NodeTests
{
    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 1)]
    [InlineData('c', 1)]
    [InlineData('d', 1)]
    [InlineData('e', 1)]
    [InlineData('f', 1)]
    [InlineData('g', int.MaxValue)]
    [InlineData('h', int.MaxValue)]
    public void Node_Visit_Should_Result_In_Expected_Weight(char elevation, int expected)
    {
        Node currentNode = 'e';
        currentNode.Distance = 0;

        Node neighbour = elevation;

        neighbour.Visit(currentNode, (difference) => difference is <= 1);

        neighbour.Distance.Should().Be(expected);
    }

    [Theory]
    [InlineData('a', int.MaxValue)]
    [InlineData('b', int.MaxValue)]
    [InlineData('c', int.MaxValue)]
    [InlineData('d', 1)]
    [InlineData('e', 1)]
    [InlineData('f', 1)]
    [InlineData('g', 1)]
    [InlineData('h', 1)]
    [InlineData('i', 1)]
    public void Node_Visit_Should_Result_In_Expected_Weight_With_Reverse_Compare(char elevation, int expected)
    {
        Node currentNode = 'e';
        currentNode.Distance = 0;

        Node neighbour = elevation;

        neighbour.Visit(currentNode, (difference) => difference is >= -1);

        neighbour.Distance.Should().Be(expected);
    }


    [Theory]
    [InlineData('z', 'a', int.MaxValue)]
    [InlineData('z', 'x', int.MaxValue)]
    [InlineData('z', 'y', 1)]
    [InlineData('a', 'z', 1)]
    public void Node_Visit_Should_Result_In_Expected_Weight_With_Reverse_Compare_2(char current, char elevation, int expected)
    {
        Node currentNode = current;
        currentNode.Distance = 0;

        Node neighbour = elevation;

        neighbour.Visit(currentNode, (difference) => difference is >= -1);

        neighbour.Distance.Should().Be(expected);
    }
}
