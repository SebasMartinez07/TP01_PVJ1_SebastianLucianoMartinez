using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedX = 5f;
    [SerializeField] private float speedZ = 5f;
    void Start()
    {
        
    }
    void Update()
    {
        //Movimiento WASD del Player
        transform.Translate(Input.GetAxis("Horizontal") * speedX * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * speedZ * Time.deltaTime);
    }
}