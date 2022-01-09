using Profile;
using Tools;

public class ProfilePlayer
{
    public ProfilePlayer(float speedCar, UnityAdsTools unityAdsTools)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speedCar);
        AnalyticTools = new UnityAnalyticTools();
        AdsShower = unityAdsTools;
    }

    public SubscriptionProperty<GameState> CurrentState { get; }

    public Car CurrentCar { get; }

    public IAnalyticTools AnalyticTools { get; }

    public IAdsShower AdsShower { get; }
}

