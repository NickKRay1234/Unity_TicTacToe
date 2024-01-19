using MVP.Model;
using SignFactory;
using UnityEngine;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class PlayerMoveCommand : BaseCommand
{
    public PlayerMoveCommand(CommandParameters parameters) : base(parameters)
    {
    }
    
    protected override PlayerMark GetPlayerMark() => PlayerMark.X;
}