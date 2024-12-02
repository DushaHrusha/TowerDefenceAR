using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackObject : MonoBehaviour
{
    public GameObject point;

    public GameObject objectGame;

    public void goBack()
    {
        objectGame.transform.position = point.transform.position;
    }
}
