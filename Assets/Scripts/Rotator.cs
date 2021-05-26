using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Rotation Speed")]
    public float speed = 100f;
    void Update()
    {
        //               X  Y  Z
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
