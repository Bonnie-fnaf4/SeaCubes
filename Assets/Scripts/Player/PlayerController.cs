using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();
    private Rigidbody componentRigidbody;

    public FixedJoystick fixedJoystick;
    public float speedForse, ForseToMagnits;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.tag == "Cube")
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null && other.tag == "Cube")
        {
            affectedBodies.Remove(other.attachedRigidbody);
        }
    }

    void StikController()
    {
        Vector3 direction = transform.forward * fixedJoystick.Vertical + transform.right * fixedJoystick.Horizontal;
        componentRigidbody.AddForce(direction * speedForse * 1.5f);
    }

    private void Update()
    {
        StikController();

        componentRigidbody.velocity = new Vector3(transform.forward.x * speedForse, transform.forward.y * speedForse, transform.forward.z * speedForse);

        foreach (Rigidbody body in affectedBodies)
        {
            Vector3 forceDirection = (transform.position - body.position).normalized;
            //float distanceSqr = (transform.position - body.position).sqrMagnitude;
            //float strength = 10 * componentRigidbody.mass * body.mass / distanceSqr;

            body.AddForce(forceDirection * ForseToMagnits);
        }
    }

    private void FixedUpdate()
    {
        //StikController();

        //componentRigidbody.velocity = new Vector3(transform.forward.x * speedForse, transform.forward.y * speedForse, transform.forward.z * speedForse);

        //foreach (Rigidbody body in affectedBodies)
        //{
        //    Vector3 forceDirection = (transform.position - body.position).normalized;
        //    //float distanceSqr = (transform.position - body.position).sqrMagnitude;
        //    //float strength = 10 * componentRigidbody.mass * body.mass / distanceSqr;

        //    body.AddForce(forceDirection * ForseToMagnits);
        //}
        if (Input.GetKey(KeyCode.W))
        {
            componentRigidbody.AddForce(transform.forward * speedForse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            componentRigidbody.AddForce(-transform.forward * speedForse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            componentRigidbody.AddForce(-transform.right * speedForse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            componentRigidbody.AddForce(transform.right * speedForse);
        }
    }
}
