using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlatformMovement : MonoBehaviour
{
    [SerializeField] private float speedX = 3f;
    [SerializeField] private float limiteX = 8f;
    void Start()
    {
        
    }
    void Update()
    {
        MoveMiniPlatforms();
    }

    //Método para mover las MiniPlatforms de forma horizontal.
    public void MoveMiniPlatforms()
    {
        //Si la posición de la MiniPlatform es menor o igual a -limiteX o mayor o igual a limiteX, se invierte la dirección del movimiento.
        if (transform.position.x <= -limiteX || transform.position.x >= limiteX)
        {
            speedX *= -1;
        }
        transform.Translate(speedX * Time.deltaTime, 0f, 0f);
    }
}
