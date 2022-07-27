using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] protected Rigidbody rigidBody;
    [SerializeField] protected float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidBody.velocity = transform.forward * speed;
    }

    
}
