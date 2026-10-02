using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPlatform : MonoBehaviour
{
    [SerializeField] private GameObject PlatformMove;
    
    void Start()
    {
        InvokeRepeating("GeneratePlatform", 0f, 4f);
    }


    void Update()
    {
        
    }

    public void GeneratePlatform()
    {
        Instantiate(PlatformMove, transform.position, transform.rotation);
    }
}
