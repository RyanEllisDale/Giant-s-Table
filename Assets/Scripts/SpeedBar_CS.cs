using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar_CS : MonoBehaviour
{
    [SerializeField] private Player_CS Player;
    [SerializeField] private Slider Slider;
    [SerializeField] private TextMeshProUGUI Text;

    private void Awake()
    {
        Player = FindAnyObjectByType<Player_CS>();
        Slider = gameObject.GetComponent<Slider>();
    }

    private void OnValidate()
    {
        Player = FindAnyObjectByType<Player_CS>();
        Slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        Slider.value = Player.BuiltSpeed / Player.MaxSpeed;

        Text.enabled = Slider.value > 0.5;
        
        if (Slider.value < 0.55)
        {
            Text.text = "Knock It Off";
        }
        else if (Slider.value < 0.65)
        {
            Text.text = "Knock It Off!";
        }
        else if (Slider.value < 0.75)
        {
            Text.text = "Knock It Off!!";
        }
        else if (Slider.value < 0.95)
        {
            Text.text = "Knock It Off!!!";
        }

    }



}
