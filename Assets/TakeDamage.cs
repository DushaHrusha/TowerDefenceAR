using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float damage;
    public ParticleSystem particleSystem;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Titan"))
        {
            particleSystem.Play();
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject, 2f);
        }
        if (other.gameObject.CompareTag("Airship"))
        {
            particleSystem.Play();
            other.GetComponent<СargoAirshipHealth>().TakeDamage(damage);
            Destroy(this.gameObject, 2f);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            particleSystem.Play();
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject, 2f);
        }
    }
}
