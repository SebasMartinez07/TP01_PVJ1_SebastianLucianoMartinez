using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement2 : MonoBehaviour
{
    [SerializeField] private float speedZ = 2f;
    [SerializeField] private float limiteZ = 33f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0,0,speedZ * Time.deltaTime);
        if(transform.position.z > limiteZ)
        {
            Destroy(gameObject);
        }
    }
}
