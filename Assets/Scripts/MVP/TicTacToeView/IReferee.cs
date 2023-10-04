using MVP.Model;

public interface IReferee : IService
{
    bool CheckDraw(PlayerMark player);
    bool CheckWinAndShowWin(PlayerMark player);
    bool ShowLoseScreen(PlayerMark player, bool IsAI);
}