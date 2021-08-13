using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenu : MonoBehaviour
{
    public GameObject TABPanel;

    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        if (active)
        {
            TABPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (active)
            {
                TABPanel.SetActive(false);
                active = false;
                Debug.Log(active.ToString());
            }
            else if (!active)
            {
                TABPanel.SetActive(true);
                active = true;
                Debug.Log(active.ToString());
            }

        }

        
    }
}
