using Profile;
using System.Linq;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField]
    private UnityAdsTools _unityAdsTools;

    [SerializeField]
    private ItemConfig[] _itemConfigs;


    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _itemConfigs.ToList());
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
