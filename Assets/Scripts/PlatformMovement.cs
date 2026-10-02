using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speedZ = 2f;
    [SerializeField] private float limiteZ = 24f;
    [SerializeField] private float limiteX = -10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0,0,speedZ * Time.deltaTime);
        if(transform.position.z > limiteZ || transform.position.x < limiteX)
        {
            Destroy(gameObject);
        }
    }
}
