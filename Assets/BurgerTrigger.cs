using UnityEngine;

public class BurgerTrigger : MonoBehaviour
{
    public Burger burger;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            burger.GetPanel();
            Destroy(this.gameObject);
        }
    }
}
