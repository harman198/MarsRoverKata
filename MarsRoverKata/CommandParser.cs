using static MarsRoverKata.Rover;

namespace MarsRoverKata;

public class CommandParser
{

    public static string DirectionEnumToString(DirectionEnum direction) => direction switch
    {
        DirectionEnum.North => "N",
        DirectionEnum.West => "W",
        DirectionEnum.South => "S",
        DirectionEnum.East => "E",
        _ => throw new NotSupportedException()
    };

    public static DirectionEnum ParseDirectionToken(string value)
        => value switch
        {
            "N" => DirectionEnum.North,
            "E" => DirectionEnum.East,
            "S" => DirectionEnum.South,
            "W" => DirectionEnum.West,
            _ => throw new NotSupportedException()
        };

}
