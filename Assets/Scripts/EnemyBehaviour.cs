using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject EnemyBallMove;
    void Start()
    {
        InvokeRepeating("ShootBall", 0f, 3.5f);
    }

    void Update()
    {
        
    }

    public void ShootBall()
    {
        Instantiate(EnemyBallMove, transform.position, transform.rotation);
    }
}
