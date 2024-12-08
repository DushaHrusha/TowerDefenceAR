using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    public EnemyHealth towerHealth;
   void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.tag == "Titan")
        {
            other.GetComponent<Titan>().Attak();
        }

        if (other.gameObject.tag == "Airship")
        {
            other.GetComponent<СargoAirship>().Attak();
        }

        if (other.gameObject.tag == "projecttile")
        {
            towerHealth.TakeDamage(3);
        }
   }
}
