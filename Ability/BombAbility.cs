using UnityEngine;

public class BombAbility : IAbility
{
    private readonly AbilityItemConfig _config;
    public BombAbility(AbilityItemConfig config)
    {
        _config = config;
    }

    public void Apply(IAbilityActivator activator)
    {
        var bombRigidbody = Object.Instantiate(_config.View).GetComponent<Rigidbody2D>();
        bombRigidbody.AddForce(Vector2.one, ForceMode2D.Force);
    }
}
