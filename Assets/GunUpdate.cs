using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUpdate : MonoBehaviour
{
    public GameObject DoubleGun;
    public GameObject OneGun;
    public GameObject ButtonDoubleGun;
    public GameObject ButtonOneGun;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        StartCoroutine(enumerator());

    }
    public void UpdateGun()
    {
        DoubleGun.SetActive(true);
        OneGun.SetActive(false);
        button.enabled = true;
        ButtonOneGun.SetActive(false);
        ButtonDoubleGun.SetActive(true);
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(45f);
        button.interactable = true;
    }

}
