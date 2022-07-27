using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{

    [SerializeField] private string applyDamageToTag;

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag(applyDamageToTag))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
               health.Damage(1); 
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
