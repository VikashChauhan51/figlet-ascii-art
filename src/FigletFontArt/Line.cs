
namespace FigletFontArt;

internal readonly struct Line
{
    public string Content { get; }
    public byte SpaceBefore { get; }
    public byte SpaceAfter { get; }

    public char FrontChar => Content.Length == SpaceBefore ? ' ' : Content[SpaceBefore];
    public char BackChar => Content.Length == SpaceAfter ? ' ' : Content[Content.Length - SpaceAfter - 1];

    public Line(string content, byte spaceBefore, byte spaceAfter)
    {
        Content = content;
        SpaceBefore = spaceBefore;
        SpaceAfter = spaceAfter;
    }
}

internal sealed class FiggleCharacter
{
    public IReadOnlyList<Line> Lines { get; }
    public FiggleCharacter(IReadOnlyList<Line> lines) => Lines = lines;
}


public enum FiggleTextDirection
{
    /// <summary>Text flows from the left to the right.</summary>
    LeftToRight = 0,
    /// <summary>Text flows from the right to the left.</summary>
    RightToLeft = 1
}


