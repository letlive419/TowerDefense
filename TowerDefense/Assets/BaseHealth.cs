using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]int health = 20;
    [SerializeField]Text healthBar;
    int currentHealth = 1;

    private void Start()
    {
        healthBar.text = health.ToString();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        health -= currentHealth;
        print(health);
        healthBar.text = health.ToString();
    }
}
