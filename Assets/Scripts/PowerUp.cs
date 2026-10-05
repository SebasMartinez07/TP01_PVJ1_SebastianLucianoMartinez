using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Collider powerUpCollider;
    [SerializeField] private float rotacionX = 30f;
    [SerializeField] private float rotacionY = 50f;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        powerUpCollider = GetComponent<Collider>();
    }

    void Update()
    {
        transform.Rotate(rotacionX * Time.deltaTime, rotacionY * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            if(movement!=null)
            {
                movement.ActivarTurbo();
                StartCoroutine(Reaparecer());
            }
        }
    }

    private IEnumerator Reaparecer()
    {
        meshRenderer.enabled = false;
        powerUpCollider.enabled = false;

        yield return new WaitForSeconds(10f);

        meshRenderer.enabled = true;
        powerUpCollider.enabled = true;
    }
}
