using MVP.Model;

public interface IReferee : IService
{
    bool CheckDraw(PlayerMark player);
    bool CheckWin(PlayerMark player);
}