using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotations : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime*RotationSpeed* Input.GetAxis("Mouse X"), 0);
        var Value = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if(Value > 180)
        {
            Value -= 360;
        }
        Value = Mathf.Clamp(Value, -30, 15);
        CameraAxisTransform.localEulerAngles = new Vector3(Value, 0, 0);
;    }
}
