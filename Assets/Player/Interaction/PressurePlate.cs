using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public Vector3 openPosition;
    public float openSpeed = 3f;

    private Vector3 closedPosition;
    private bool isActivated = false;

    private void Start()
    {
        closedPosition = door.transform.position;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActivated = true;
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, openPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            door.transform.position = Vector3.Lerp(door.transform.position, closedPosition, Time.deltaTime * openSpeed);
        }
        
    }
}
