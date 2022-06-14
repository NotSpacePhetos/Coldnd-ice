using System;
using UnityEngine;
using IJunior.TypedScenes;

public class EntityBase : MonoBehaviour
{
    [SerializeField] private int _HP = 100;

    public int hp
    {
        get { return _HP; }
        private set { _HP = value; }
    }

    public void Hit(int damage)
    {
        if (damage <= 0)
        {
            throw new Exception("Thats no damage");
        }

        hp -= damage;

        if (hp <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        Coldnd_ice.Load();
    }
}
