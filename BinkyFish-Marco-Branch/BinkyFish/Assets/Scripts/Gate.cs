using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject Fishe;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Fishe.GetComponent<PlayerController>().keysgot == 3f)
        {
            Destroy(gameObject);
        }
    }
}
