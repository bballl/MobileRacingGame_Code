using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItemConfig", menuName = "UpgradeItemConfig")]
public class UpgradeItemConfig : ScriptableObject
{
    [SerializeField]
    private ItemConfig _itemConfig;

    [SerializeField]
    private UpgradeType _upgradeType;

    [SerializeField]
    private float _valueUpgrade;

    public int Id => _itemConfig.Id;
    public UpgradeType UpgradeType => _upgradeType;
    public float ValueUpgrade => _valueUpgrade;
}
