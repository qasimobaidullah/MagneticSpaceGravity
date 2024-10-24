using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceVisualization : MonoBehaviour
{
    private Rigidbody playerRb;
    private Vector3 magneticForce;
    private Vector3 gravitationalForce;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gravitationalForce = playerRb.mass * Physics.gravity;
        magneticForce = playerRb.velocity * playerRb.mass / Time.fixedDeltaTime - gravitationalForce;
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), "Magnetic Force: " + magneticForce.ToString("F2"));
        GUI.Label(new Rect(10, 30, 300, 20), "gravitational Force: " + magneticForce.ToString("F2"));
        GUI.Label(new Rect(10, 50, 300, 20), "W/S: Move Forward " + magneticForce.ToString("F2"));
        GUI.Label(new Rect(10, 70, 300, 20), "A/D: Move Left/Right" + magneticForce.ToString("F2"));
        GUI.Label(new Rect(10, 100, 300, 20), "Space to jump" + magneticForce.ToString("F2"));


    }
}
