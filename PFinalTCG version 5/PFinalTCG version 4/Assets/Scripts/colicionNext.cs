using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colicionNext : MonoBehaviour
{
    GameObject movementS;
    movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movementS = GameObject.Find("Sphere");
        movement = movement.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
