using Profile;
using UnityEngine;

public class FightWindowController : BaseController
{
    private FightWindowView _fightWindowViewInstance;
    private ProfilePlayer _profilePlayer;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;

    private Money _money;
    private Health _heath;
    private Power _power;

    private Enemy _enemy;

    public FightWindowController(Transform placeForUi, FightWindowView fightWindowView, 
        ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;

        _fightWindowViewInstance = Object.Instantiate(fightWindowView, placeForUi);
        AddGameObjects(_fightWindowViewInstance.gameObject);
    }

    public void RefreshView()
    {
        _enemy = new Enemy("Enemy Flappy");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _heath = new Health(nameof(Health));
        _heath.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        SubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _fightWindowViewInstance.AddCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _fightWindowViewInstance.MinusCoinsButton.onClick.AddListener(() => ChangeMoney(false));

        _fightWindowViewInstance.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _fightWindowViewInstance.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _fightWindowViewInstance.AddPowerButton.onClick.AddListener(() => ChangePower(true));
        _fightWindowViewInstance.MinusPowerButton.onClick.AddListener(() => ChangePower(false));

        _fightWindowViewInstance.FightButton.onClick.AddListener(Fight);
        _fightWindowViewInstance.LeaveFightButton.onClick.AddListener(LeaveFight);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power
        ? "<color=#07FF00>Win!!!</color>"
        : "<color=#FF0000>Lose!!!</color>");
    }

    private void LeaveFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _fightWindowViewInstance.CountMoneyText.text = $"Player Money {countChangeData}";
                _money.Money = countChangeData;
                break;

            case DataType.Health:
                _fightWindowViewInstance.CountHealthText.text = $"Player Health {countChangeData}";
                _heath.Health = countChangeData;
                break;

            case DataType.Power:
                _fightWindowViewInstance.CountPowerText.text = $"Player Power {countChangeData}";
                _power.Power = countChangeData;
                break;
        }

        _fightWindowViewInstance.CountPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
    }

    protected override void OnDispose()
    {
        _fightWindowViewInstance.AddCoinsButton.onClick.RemoveAllListeners();
        _fightWindowViewInstance.MinusCoinsButton.onClick.RemoveAllListeners();

        _fightWindowViewInstance.AddHealthButton.onClick.RemoveAllListeners();
        _fightWindowViewInstance.MinusHealthButton.onClick.RemoveAllListeners();

        _fightWindowViewInstance.AddPowerButton.onClick.RemoveAllListeners();
        _fightWindowViewInstance.MinusPowerButton.onClick.RemoveAllListeners();

        _fightWindowViewInstance.FightButton.onClick.RemoveAllListeners();
        _fightWindowViewInstance.LeaveFightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _power.Detach(_enemy);

        base.OnDispose();
    }
}
