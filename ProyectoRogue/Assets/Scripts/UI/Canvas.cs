using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public Image img_Weapon;
    public TextMeshProUGUI wepon_text;
    public PlayerMove player;
    public Color color1,color2,color3;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            img_Weapon.color = color1;
            wepon_text.text = "Weapon 1";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            img_Weapon.color = color2;
            wepon_text.text = "Weapon 2";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            img_Weapon.color = color3;
            wepon_text.text = "Weapon 3";
        }
    }
}
