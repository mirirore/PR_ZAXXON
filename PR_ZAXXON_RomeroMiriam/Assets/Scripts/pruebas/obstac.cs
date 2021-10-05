using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstac : MonoBehaviour
{

   [SerializeField] GameObject meteor;
 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("randomObs");
       
    }

        // Update is called once per frame
        void Update()
    {
        
    }


    IEnumerator randomObs()
    {

        float separacion = Random.Range(-20, 20);
        yield return new WaitForSeconds(0.3f);

        Vector3 newPos = new Vector3(separacion, separacion, transform.position.z);

        for (int n = 0; ; n++)
        {
            Instantiate(meteor, newPos, Quaternion.identity);

        }


    }
}
