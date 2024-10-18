using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    

    public float speedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el objeto indefinidamente en el eje Y local del padre
        transform.Translate(Vector3.up * speedObject * Time.deltaTime);
    }

    

   

}
