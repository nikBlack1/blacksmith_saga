using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMinable : ToolHit
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
