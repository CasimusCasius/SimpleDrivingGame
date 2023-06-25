using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float turnSpeed = 200f;
    private static float timeToStart = 3f;
    private static float timer = 0f;
    private static bool isCarRunning = false;

    private int steerValue;

    private void Start()
    {
        timer = timeToStart;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            isCarRunning = false;
            return;
        }
        isCarRunning = true;
        speed += (acceleration * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

    }

    public void Steer(int value)
    {
        steerValue = value;
    }

    public bool GetIsCarRunning() => isCarRunning;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
