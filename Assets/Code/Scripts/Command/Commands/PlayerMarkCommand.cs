using MVP.Model;
using UnityEngine;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class PlayerMarkCommand : BaseCommand
{
    public PlayerMarkCommand(CommandParameters parameters) : base(parameters) { }
    
    protected override PlayerMark GetPlayerMark() => _designDataContainer.CurrentPlayer;
}