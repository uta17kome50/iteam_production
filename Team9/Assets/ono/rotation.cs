using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float RotationZ;
    public float RotationX;
    public float RotationY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(RotationX, RotationY, RotationZ));


        //if (Input.GetKey(KeyCode.I) || Input.GetButton("Rotate1"))
        //{
        //    transform.Rotate(new Vector3(RotationX, RotationY, RotationZ));

        //}

        //if (Input.GetKey(KeyCode.U) || Input.GetButton("Rotate2"))
        //{
        //    transform.Rotate(new Vector3(RotationX, -RotationY, RotationZ));

        //}
    }

}
