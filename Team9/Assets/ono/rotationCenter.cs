using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCenter : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float rotateSpeed = 360.0f;//1秒で360°
    [SerializeField] float circleRadius = 1.0f;

    [SerializeField] GameObject PlayerController;

    Transform target;

    void Start()
    {
        target = PlayerController.transform;
    }

    void Update()
    {
        float rad = rotateSpeed * Mathf.Deg2Rad * Time.time;//Sinの引数はラジアンなのでRad2DegではなくDeg2Radを使う

        transform.position = target.position + new Vector3(Mathf.Cos(rad) * circleRadius * 1.5f, Mathf.Sin(rad) * circleRadius * 0.6f);

        if (circleRadius > 0f) circleRadius -= moveSpeed * Time.deltaTime;//半径を小さくしていく
    }
}
