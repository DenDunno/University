using System.Collections.Generic;

public static class DatabaseTypesName
{
    public const string INT = nameof(INT);
    public const string STRING = nameof(STRING);
    public const string COLOR = nameof(COLOR);
    public const string DATE = nameof(DATE);
    public const string CHAR = nameof(CHAR);
    public const string REAL = nameof(REAL);

    public static IEnumerable<string> Types => new[] { INT, STRING, COLOR, DATE, CHAR, REAL };
}