public static class ExpressionFixer
{
    public static string FixExpression(string input)
    {
        if (input.Length != 3)
            throw new ArgumentException("Input must be 3 characters long");

        char[] chars = input.ToCharArray();

        if (chars[0] < chars[2])
        {
            chars[1] = '<';
        }
        else if (chars[0] > chars[2])
        {
            chars[1] = '>';
        }
        else
        {
            chars[1] = '=';
        }

        return new string(chars);
    }
}