using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    Player player;

    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();

    }

    private void UpdateHealth()
    {
            text.text = player.getHealth().ToString();
    }
}
