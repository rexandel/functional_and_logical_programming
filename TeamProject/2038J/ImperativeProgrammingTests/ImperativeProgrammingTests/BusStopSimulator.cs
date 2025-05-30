using System;
using System.Text;

public class BusStopSimulator
{
    public static string ProcessEvents(string input)
    {
        var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length == 0) return string.Empty;

        long w = 0;
        var output = new StringBuilder();
        int t = int.Parse(lines[0]);

        for (int i = 1; i <= t && i < lines.Length; i++)
        {
            var parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;

            string s = parts[0];
            if (!long.TryParse(parts[1], out long x)) continue;

            if (s == "B")
            {
                w -= x;
                if (output.Length > 0) output.Append(" ");
                output.Append(w < 0 ? "YES" : "NO");
                w = Math.Max(w, 0);
            }
            else if (s == "P")
            {
                w += x;
            }
        }

        return output.ToString();
    }
}