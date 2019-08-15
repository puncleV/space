using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    private Text healthBar;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Text>();
        player = FindObjectOfType<Player>();
        healthBar.text = player.GetHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.text = player.GetHealth().ToString();
    }
}
