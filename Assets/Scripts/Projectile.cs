using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidBody.velocity = transform.forward * speed;
    }

    
}
