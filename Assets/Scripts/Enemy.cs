using UnityEngine;
using System.Collections;

public class Enemy : Player
{
    public override void Kill()
    {
        Destroy(gameObject);
    }

}
