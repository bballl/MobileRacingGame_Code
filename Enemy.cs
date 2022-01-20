using UnityEngine;

public class Enemy : IEnemy
{
    private string _name;

    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;

    public double Power
    {
        get
        {
            var power = (_moneyPlayer + _healthPlayer) * 0.8 - _powerPlayer * 0.7;
            return power;
        }
    }

    public double Aggression
    {
        get
        {
            var agression = _moneyPlayer * 0.71;
            return agression;
        }
    }

    public Enemy(string name)
    {
        _name = name;
    }
    
    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                var dataHealth = (Health)dataPlayer;
                _healthPlayer = dataHealth.CountHealth;
                break;

            case DataType.Money:
                var dataMoney = (Money)dataPlayer;
                _moneyPlayer = dataMoney.CountMoney;
                break;

            case DataType.Power:
                var dataPower = (Power)dataPlayer;
                _powerPlayer = dataPower.CountPower;
                break;
        }

        Debug.Log($"Enemy {_name}, change {dataType}");
    }
}
