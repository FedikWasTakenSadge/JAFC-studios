using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int playerHealth = 8;
    public Text health;
    public static int enemyHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        health.text = "health" + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "health" + playerHealth;
    }
}
