using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] GameObject Bola;
    MovernavePrueba movernavePrueba;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        Bola = GameObject.Find("nave");
        movernavePrueba = Bola.GetComponent<MovernavePrueba>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = movernavePrueba.desplSpeed;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
