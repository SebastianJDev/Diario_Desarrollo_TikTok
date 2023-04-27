using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public List<Image> img_Powers = new List<Image>();
    public List<TextMeshProUGUI> Powers_text = new List<TextMeshProUGUI>();
    public PlayerMove player;
    [SerializeField] List<Ability> Habilidades = new List<Ability>();

    private void Start()
    {
        Powers_text[0].text = "Left Shift";
        Powers_text[1].text = "Right Click";
        Powers_text[2].text = "E";
    }
}
