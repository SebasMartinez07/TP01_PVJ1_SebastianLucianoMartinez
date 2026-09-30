using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlatformsMovement : MonoBehaviour
{
    [SerializeField] private float speedZ = 2f;
    [SerializeField] private float limiteMinZ = 2f;
    [SerializeField] private float limiteMaxZ = 6.5f;


    void Update()
    {
        transform.Translate(0f, 0f, speedZ * Time.deltaTime, Space.World);
        if (transform.position.z <= limiteMinZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limiteMinZ);
            speedZ = Mathf.Abs(speedZ); // Asegura que speedZ sea positivo
        }
        else if (transform.position.z >= limiteMaxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limiteMaxZ);
            speedZ = -Mathf.Abs(speedZ); // Asegura que speedZ sea negativo
        }
        //MoveWallPlatforms();
    }

    /*public void MoveWallPlatforms()
    {
        //Si la posición de la WallPlatform es menor o igual a limiteMinZ o mayor o igual a limiteMaxZ, se invierte la dirección del movimiento.
        if (transform.position.z <= limiteMinZ || transform.position.z >= limiteMaxZ)
        {
            speedZ *= -1;
        }
        transform.Translate(0f, 0f, speedZ * Time.deltaTime);
    }*/
}
