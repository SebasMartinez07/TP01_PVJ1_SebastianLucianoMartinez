using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedX = 5f;
    [SerializeField] private float speedZ = 5f;
    [SerializeField] private float jump = 6f;
    public Transform CheckFloor;
    public LayerMask Floor;

    private bool isFloored;

    void Start()
    {
        
    }
    void Update()
    {
        //Movimiento WASD del Player
        transform.Translate(Input.GetAxis("Horizontal") * speedX * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * speedZ * Time.deltaTime);

        //Verifica si el Player esta en el suelo
        isFloored = Physics.CheckSphere(CheckFloor.position, 0.1f, Floor);

        //Salto del Player
        if (Input.GetKeyDown(KeyCode.Space) && isFloored)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }
}