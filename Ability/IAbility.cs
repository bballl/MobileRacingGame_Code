using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityActivator
{
    GameObject GetViewObject();
}

public interface IAbility
{
    void Apply(IAbilityActivator activator);
}

public interface IAbilitiesController
{
    void ShowAbilities();
}
