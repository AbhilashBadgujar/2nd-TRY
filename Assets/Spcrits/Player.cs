﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    [SerializeField] int maxHealth = 100;

    [SyncVar]
    int currentHealth;

    private void Awake()
    {
        SetDefults();
    }

    private void SetDefults()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int ammount)
    {
        currentHealth -= ammount;
        print(currentHealth);
        print(transform.name + "now has " + currentHealth + "health.");
    }
}
