using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    public Slider slider;
    public GameObject player;
    public PlayerHealthSystem hScript;
    // Start is called before the first frame update
    void Start()
    {
        hScript = player.GetComponent<PlayerHealthSystem>();
        slider.maxValue = hScript.getHealth();
        slider.value = hScript.getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hScript.getHealth();
    }
}
