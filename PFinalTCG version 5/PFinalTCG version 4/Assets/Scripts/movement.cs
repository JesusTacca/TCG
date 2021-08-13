using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    //public GameObject InpVi;
    //public GameObject InpVf;
    //public GameObject InpAc;
    //public GameObject InpDr;


    public Text ObjtDis;
    public GameObject Vinicial;
    public GameObject Vfinal;
    public GameObject Aceleracion;
    public GameObject Angul;
    public GameObject Potencia;
    public GameObject TimeInput;
    //borrar
    public GameObject SecBall;
    public GameObject Pointer;
    public GameObject Container;
    public GameObject Objective;
    bool PrPuntero = false;

    bool DrawLineA = false;
    bool Activedraw = true;

    float Vini;
    float Vfin;
    float Acel;
    float Angle;

    Vector3 direccion = Vector3.zero;

    float PosX;
    float PosY;
    float PosZ;
    float Dis;
    float Pot = 0f;


    float VelX = 5f;
    float VelY = 5f;
    float VelZ = 0f;
    float AceX = 0f;
    float AceY = -10f;
    float AceZ = 0f;


    float h = 0.01f;
    int cont = 100;

    //recorrido
    coords[] CORDS;
    int cordNum = 0;
    int interval = 5;
    Vector3 PosIni2;
    Vector3 PunPos;
    bool freeze = true;

    bool empezar = false;
    Vector3 PosIni;


    // Start is called before the first frame update
    void Start()
    {
        //borrar
        PosIni2 = SecBall.transform.position;
        PunPos = Pointer.transform.position;
        //borrar -<
        PosIni = transform.position;
        CORDS = new coords[200];
        CORDS[cordNum] = new coords(PosIni2.x, PosIni2.y, PosIni2.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (freeze)
        {
            SecBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        //click izquierdo
        if (Input.GetKeyUp("q"))
        {
            DrawLineA = !DrawLineA;
        }
        //click izquierdo
        if (Input.GetKeyUp("space"))
        {
            Debug.Log(direccion.x.ToString() + " " + direccion.y.ToString() + " " + direccion.z.ToString());
            SecBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Vector3 lanzamiento = SecBall.transform.position - Pointer.transform.position;
            SecBall.GetComponent<Rigidbody>().AddForce(direccion * Pot);
            
            freeze = false;
        }
        if (Input.GetKeyUp("l"))
        {
            Debug.Log(direccion.x.ToString() + " " + direccion.y.ToString() + " " + direccion.z.ToString());
            SecBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Vector3 lanzamiento = SecBall.transform.position - Pointer.transform.position;
            SecBall.GetComponent<Rigidbody>().AddForce(lanzamiento*-1 * Pot);

            freeze = false;
        }
        if (!freeze )
        {
            //Container.transform.position = SecBall.transform.position;
            Vector3 pos = SecBall.transform.position;
            PosX = pos.x;
            PosY = pos.y;
            PosZ = pos.z;

            cont = cont - 1;
            interval--;
            if (interval == 0)
            {
                cordNum++;
                CORDS[cordNum] = new coords(PosX, PosY, PosZ);
            }

            //Debug.Log(cont.ToString());
            if (cont <= 0)
            {
                freeze = true;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            CORDS = new coords[200];
            cordNum = 0;
            if (Activedraw)
            {
                Activedraw = false;
            }
            else if(Activedraw==false)
            {
                Activedraw = true;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (PrPuntero)
            {
                PrPuntero = !PrPuntero;
            }
            else if (!PrPuntero)
            {
                PrPuntero = true;
            }
        }
        
    }

    void printTray()
    {
        string txt = "";
        for(int x = 0; x < cordNum; x++)
        {
            txt = txt + CORDS[x].x.ToString() + " " + CORDS[x].y.ToString() + " " + CORDS[x].z.ToString() + " \n";
        }
        //Debug.Log(txt);
    }

    public void AgregarValores()
    {
        Vini = float.Parse(Vinicial.GetComponent<Text>().text);
        Vfin = float.Parse(Vfinal.GetComponent<Text>().text);
        Acel = float.Parse(Aceleracion.GetComponent<Text>().text);
        Angle = float.Parse(Angul.GetComponent<Text>().text);
        Pot = float.Parse(Potencia.GetComponent<Text>().text);

        Debug.Log(Vini.ToString() + " " + Vfin.ToString() + " " + Acel.ToString() + " " + Angle.ToString() + " " + Pot.ToString() + " ");
        SetAngle();
        empezar = true;
    }
    public void restart()
    {
        Pointer.SetActive(true);
        //borrar
        SecBall.transform.position = PosIni2;
        SecBall.transform.rotation = Quaternion.identity;
        SecBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        SecBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        freeze = true;
        //  SecBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //borrar -<
        empezar = false;
        cont = 100;
        transform.position = PosIni;
        interval = 5;
        CORDS = new coords[200];
        cordNum = 0;
        CORDS[cordNum] = new coords(PosIni2.x, PosIni2.y, PosIni2.z);
    }
    public void setTime()
    {
        cont = int.Parse(TimeInput.GetComponent<Text>().text);
        //Debug.Log("Time " + cont.ToString());
    }
    public void SetAngle()
    {
        
        Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, Angle) * Vector2.right);
        Debug.Log(dir.x.ToString() + " " + dir.y.ToString());
        direccion = new Vector3(dir.x, dir.y, 0f);
    }



    void OnDrawGizmos()
    {
        //ObjtDis.GetComponent<Text>().text = dis.ToString();

        if (DrawLineA)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(SecBall.transform.position, Objective.transform.position);
            float dist = Vector3.Distance(SecBall.transform.position, Objective.transform.position);
            try
            {
                //Debug.Log("distancia: "+dist.ToString());
                ObjtDis.text = dist.ToString();
            }
            catch (Exception e)
            {
                print("error");
            }
        }

        if (Activedraw)
        {
            for (int x = 0; x < cordNum; x++)
            {
                printTray();
                Gizmos.color = Color.red;
                Vector3 pos = new Vector3(CORDS[x].x, CORDS[x].y, CORDS[x].z);
                //Gizmos.DrawCube(pos, new Vector3(0.2f, 0.2f, 0.2f));
                Gizmos.DrawLine(new Vector3(CORDS[x].x, CORDS[x].y, CORDS[x].z), new Vector3(CORDS[x + 1].x, CORDS[x + 1].y, CORDS[x + 1].z));
                if (interval == 0)
                {
                    interval = 5;
                }
            }
        }

    }

    struct coords
    {
        public float x;
        public float y;
        public float z;
        public coords(float px, float py, float pz)
        {
            x = px;
            y = py;
            z = pz;
        }

    }
}


// LE BASURE 


//GENERACION DE OBJETOS
//var NewObj = GameObject.Instantiate(Objeto, new Vector3(x, 0, y), Quaternion.identity);
//NewObj.AddComponent<BoxCollider>();
//NewObj.transform.parent = GameObject.Find(obj).transform;


//ROTACION DE PUNTERO
/*
         if (Input.GetMouseButtonUp(1))
        {
            if (act_rotacion)
            {
                act_rotacion = false;
            }
            else if (!act_rotacion)
            {
                act_rotacion = true;
            }
        }
        if (act_rotacion)
        {
            //Debug.Log("tamo");
            //Quaternion punteroAngX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 1f, Vector3.up);
            //Quaternion punteroAngY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * 1f, Vector3.up);
            
            //PointerOffset = punteroAngX * PointerOffset;

            //Debug.Log(PointerOffset.x + " " + PointerOffset.y + " " + PointerOffset.z);

            //Vector3 NewPos = SecBall.transform.position + PointerOffset;

            //Pointer.transform.position = Vector3.Slerp(Pointer.transform.position, NewPos, 100);

            //Pointer.transform.position = new Vector3(pitch, yaw, 0.0f);
            //yaw += 1f * Input.GetAxis("Mouse X");
            //pitch -= 1f * Input.GetAxis("Mouse Y");

        }
 
 */