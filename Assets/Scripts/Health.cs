using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHP;
    private float currentHP;
    [SerializeField] private GameObject deathParticlePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void Damage(float amount)
    {
        if (currentHP <= 0)
        {
            return;
        }

        float newHP = currentHP - amount;
        currentHP = Mathf.Clamp(newHP, 0, maxHP);

        if (currentHP == 0)
        {
            if (deathParticlePrefab != null)
            {
                Instantiate(deathParticlePrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

}
