using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public int PrevSC;
    public int NextSC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNext()
    {
        Debug.Log("Cambiando escena....");
        if (NextSC < 9 && NextSC > 2)
        {
            Debug.Log("Adelante");
            SceneManager.LoadScene(NextSC);
        }
    }
    public void GoPrev()
    {
        Debug.Log("Cambiando escena....");
        if (PrevSC < 9 && PrevSC > 0)
        {
            Debug.Log("Atras");
            SceneManager.LoadScene(PrevSC);
        }
    }
}
