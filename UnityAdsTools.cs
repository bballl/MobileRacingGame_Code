using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower
{
    private string _gameId = "4527508";
    private string _bannerPlacementId = "Banner_Android";
    private string _interstitialPlacementId = "Interstitial_Android";

    private void Awake()
    {
        Advertisement.Initialize(_gameId);
    }

    public void ShowInterstitialVideo()
    {
        Advertisement.Show(_interstitialPlacementId);
    }

    public void ShowRewardVideo()
    {
        //Advertisement.Show(_rewardPlacementId);
    }
    
    public void ShowBanner()
    {
        Advertisement.Show(_bannerPlacementId);
    }
}
