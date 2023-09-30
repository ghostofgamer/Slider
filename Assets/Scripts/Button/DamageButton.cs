using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : AbstractButton
{
    [SerializeField] private Player _player;

    private readonly float _damage = 10f;

    protected override void OnButtonClick()
    {
        _player.TakeDamage(_damage);
    }
}
