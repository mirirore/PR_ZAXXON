using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    
    //Variables suavizado
    [SerializeField] float smoothVelocity = 0.3f;
    [SerializeField] Vector3 camaraVelocity = Vector3.zero;


   

    // Update is called once per frame
    void Update()
    {
        
            Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y + 1.5f, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
        
    }
}
