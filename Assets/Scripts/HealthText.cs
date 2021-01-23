using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthText : MonoBehaviour
{
    Player player;
    Text healthText;
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
