using Profile;
using Profile.Analytic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField]
    private FightWindowView _fightWindowView;

    [SerializeField]
    private StartFightView _startFightView;

    [SerializeField]
    private DailyRewardView _dailyRewardView;

    [SerializeField]
    private CurrencyView _currencyView;

    private MainController _mainController;

    private void Awake()
    {
        ProfilePlayer profilePlayer = new ProfilePlayer(15f, new UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _fightWindowView, 
            _startFightView, _dailyRewardView, _currencyView);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
