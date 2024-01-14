using MVP.Model;

public interface IReferee
{
    bool CheckDraw(PlayerMark player);
    bool CheckWin(PlayerMark player, bool isAI);
}