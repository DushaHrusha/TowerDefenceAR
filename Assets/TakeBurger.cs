using UnityEngine;

public class TakeBurger : MonoBehaviour
{
    public Burger burger;
    public static int i = 6;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            i--;
            if (i == 0)
            {
                burger.GetPanel();
            }
            Destroy(this.gameObject);
        }
    }
}
