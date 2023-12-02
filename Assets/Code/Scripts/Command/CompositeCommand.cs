using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://refactoring.guru/design-patterns/composite")]
public sealed class CompositeCommand : ICommand
{
    private readonly List<ICommand> _commands = new();
    
    public CompositeCommand(params ICommand[] commands) =>
        _commands.AddRange(commands);

    public void Execute()
    {
        foreach (var command in _commands)
            command.Execute(); // Execute a series of commands.
    }

    public void Undo()
    {
        for (int i = _commands.Count - 1; i >= 0; i--)
            _commands[i].Undo(); // Undo a series of commands in reverse order.
    }
}