using TMPro;
using UnityEngine;

public class CountKills : MonoBehaviour
{
    public TMP_Text kill_Text;

    void Update()
    {
        updateKill();
    }

    public void updateKill()
    {
        kill_Text.text = "Kill: " + EnemyHealth.countKillEnemy;
    }
}
