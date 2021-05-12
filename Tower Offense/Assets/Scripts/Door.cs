using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Locked
{
    public override void Open()
    {
        base.Open();
        Destroy(this.gameObject);
    }
}
