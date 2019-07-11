﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int Damage { get => damage; set => damage = value; }

    public void hit ()
    {
        Destroy(gameObject);
    }
}
