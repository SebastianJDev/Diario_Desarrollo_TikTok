using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Creator_Bullet info;
    private float _startingTime;
    private SpriteRenderer _render;
    void Awake()
    {
        _render = GetComponent<SpriteRenderer>();    
    }
    void Start()
    {
        _startingTime = Time.time;

        Destroy(this.gameObject, info.livingTime);
    }
    void Update()
    {
        float _timeSinceStarted = Time.time - _startingTime;
        float _percentCompleted  = _timeSinceStarted / info.livingTime;

        _render.color = Color.Lerp(info.initialColor,info.finalColor,_percentCompleted);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject); 
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
        }
    }
}
