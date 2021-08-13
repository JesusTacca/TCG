using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 70f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled2 = false;

    // Use this for initialization
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
        CameraDisabled2 = false;
    }


    void LateUpdate()
    {
        if (Input.GetMouseButtonUp(1))
            if (CameraDisabled2)
            {
                Debug.Log("Camara Activada");
                CameraDisabled2 = !CameraDisabled2;
            }
            else if (!CameraDisabled2)
            {
                Debug.Log("Camara Desactivada");
                CameraDisabled2 = true;
            }

        if (!CameraDisabled2)
        {
            //Debug.Log("afdagf");
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

            Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
            this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

            if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
            {
                this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
            }


            
        }
        //Actual Camera Rig Transformations
        
        //Debug.Log( (transform.position.x+57.34f).ToString() + " " + (transform.position.y-2f).ToString()  + " " + (transform.position.z+0.18f).ToString());
    }
}
