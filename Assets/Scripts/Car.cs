using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;
   
    void Update()
    {
        speed += (acceleration * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

    }

    public void Steer(int value)
    {
        steerValue = value;
    }

}
