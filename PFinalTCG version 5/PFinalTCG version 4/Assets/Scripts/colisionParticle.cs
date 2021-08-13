using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class colisionParticle : MonoBehaviour
{
    public GameObject particle;
    int time = 100;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time = time - 1;
            if (time == 0)
            {
                time = 100;
                active = !active;
                particle.SetActive(false);
            }
        }
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            try
            {
                active = true;
            }
            catch (Exception e)
            {
                print("error de pintado - ignorar");
            }
        }
    }
}
