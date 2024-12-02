using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
    if (other.gameObject.tag == "Enemy")
    {
        other.GetComponent<Titan>().Attak();
    }
   }
}
