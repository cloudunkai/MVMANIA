using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //回転スピード
    public float speed = 1.0f;
    //回転座標
    public Vector3 axis;

    void Update()
    {
        float addToAngle = 0.0f;
        transform.Rotate(axis, addToAngle + speed);
    }
}
