using Leopotam.Ecs.Game.Components;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private UserView _user;
    [SerializeField] private BotView _bot;
    [SerializeField] private Image _figureImage;
    [SerializeField] private Sprite[] _contents;
    public int PlayerID = -1;
    public bool IsUserView = false;

    public void SetBotDif(Bot b)
    {
        Debug.Log("Where");
        _user.gameObject.SetActive(false);
        _bot.SetBotDif(b);
        _bot.gameObject.SetActive(true);
    }

    public void UpdateUserStats(Stat s)
    {
        _bot.gameObject.SetActive(false);
        _user.UpdateStats(s);
        _user.gameObject.SetActive(true);
    }

    public void SetFigure(int contentIndex)
    {
        _figureImage.sprite = _contents[contentIndex];
    }
}