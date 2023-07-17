using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPooledObjectAfterRandomSeconds : GetPooledObjectAfterSeconds
{
    [SerializeField] private float _randomSecondsFloor;
    [SerializeField] private float _randomSecondsCeiling;

    public override void GetPooledObject()
    {
        base.GetPooledObject();
        base._timer = UnityEngine.Random.Range(_randomSecondsFloor, _randomSecondsCeiling);
    }
}
