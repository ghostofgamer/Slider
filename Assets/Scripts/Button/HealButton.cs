using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : AbstractButton
{
    [SerializeField] private Player _player;

    private readonly float _heal = 10f;

    protected override void OnButtonClick()
    {
        _player.AddHealth(_heal); 
    }
}
