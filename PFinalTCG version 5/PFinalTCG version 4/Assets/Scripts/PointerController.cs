using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointerController : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 1f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public Text Angulox;
    public Text Anguloy;
    public Text Anguloz;

    public bool CameraDisabled = false;

    // Use this for initialization
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
        CameraDisabled = true;
    }


    void LateUpdate()
    {
        if (Input.GetMouseButtonUp(1))
            if (CameraDisabled)
            {
                CameraDisabled = !CameraDisabled;
            }
            else if (!CameraDisabled)
            {
                CameraDisabled = true;
            }

        if (!CameraDisabled)
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp the y Rotation to horizon and not flipping over at the top
                if (_LocalRotation.y < 0f)
                    _LocalRotation.y = 0f;
                else if (_LocalRotation.y > 90f)
                    _LocalRotation.y = 90f;
            }
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }

        Debug.Log(this._XForm_Camera.position.x.ToString()+" "+ this._XForm_Camera.position.y.ToString()+" "+ this._XForm_Camera.position.z.ToString());
        Angulox.text = this._XForm_Camera.position.x.ToString();
        Anguloy.text = this._XForm_Camera.position.y.ToString();
        Anguloz.text = this._XForm_Camera.position.z.ToString();
        
        //Debug.Log( (transform.position.x+57.34f).ToString() + " " + (transform.position.y-2f).ToString()  + " " + (transform.position.z+0.18f).ToString());
    }
    //public Vector3 GetPos()
    //{
    //    return this._XForm_Camera.localPosition;
    //}
}

//LE BASURE
/*
             if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

                ScrollAmount *= (this._CameraDistance * 0.3f);

                this._CameraDistance += ScrollAmount * -1f;

                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
            }
 
 */
