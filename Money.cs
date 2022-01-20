public class Money : DataPlayer
{
    private int _countMoney;

    public int CountMoney
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                Notifier(DataType.Money);
            }
        }
    }
}
