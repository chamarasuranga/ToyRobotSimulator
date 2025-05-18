
// CommandParser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ToyRobotSimulator.Infrastructure.Contracts;
using ToyRobotSimulator.Infrastructure.Parsing;


public static class CommandParser
{
    private static readonly Dictionary<string, Type> CommandTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .Select(t => new { Type = t, Attr = t.GetCustomAttribute<CommandKeywordAttribute>() })
        .Where(x => x.Attr != null)
        .ToDictionary(x => x.Attr.Keyword.ToUpper(), x => x.Type);

    public static ICommand Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;
        var trimmed = input.Trim();
        var spaceIdx = trimmed.IndexOf(' ');

        var keyword = spaceIdx == -1 ? trimmed.ToUpper() : trimmed[..spaceIdx].ToUpper();
        var args = spaceIdx == -1 ? "" : trimmed[(spaceIdx + 1)..];

        if (CommandTypes.TryGetValue(keyword, out var type))
        {
            var attr = type.GetCustomAttribute<CommandKeywordAttribute>();
            if (attr.HasArguments)
            {
                var method = type.GetMethod("FromArgs", BindingFlags.Public | BindingFlags.Static);
                return method?.Invoke(null, new object[] { args }) as ICommand;
            }
            return Activator.CreateInstance(type) as ICommand;
        }

        return null;
    }
}