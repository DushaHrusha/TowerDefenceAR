using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBall : MonoBehaviour
{
    public GameObject tpPoint;
    public GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ball.transform.position = tpPoint.transform.position;
        }
    }
}
