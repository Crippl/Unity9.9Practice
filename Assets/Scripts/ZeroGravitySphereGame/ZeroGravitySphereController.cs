using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravitySphereController : MonoBehaviour
{
    private void OnTriggerEnter(Collider concreteCollider)
    {
        concreteCollider.gameObject.GetComponent<Rigidbody>().useGravity = false;
        concreteCollider.gameObject.GetComponent<Rigidbody>().drag = 1f;
    }

    private void OnTriggerExit(Collider concreteCollider)
    {
        concreteCollider.gameObject.GetComponent<Rigidbody>().useGravity = true;
        concreteCollider.gameObject.GetComponent<Rigidbody>().drag = 0.5f;
    }
}
