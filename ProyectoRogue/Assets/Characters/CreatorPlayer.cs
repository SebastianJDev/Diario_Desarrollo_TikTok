using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewCharacter", menuName = "Creator_Character", order =0)]
public class CreatorPlayer : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _DashVelocity;
    [SerializeField] private int _health;
    [SerializeField] private string _name;

    // Current Health
    public int GetHealth() { return _health; }
    public void SetHealth(int health) { _health = health; }

    //Speed
    public float GetSpeed() { return _speed; }
    public void SetSpeed(float speed) { _speed = speed; }

    // Tomar Daño
    public void TomarDañoPlayer(int damage) { _health -= damage; }

    // DashVelocity
    public float GetDashVelocity() { return _DashVelocity; }
    
    //Dash

    public void Dash(Rigidbody2D rb,Vector2 moveInput)
    {
        rb.velocity += moveInput.normalized * _DashVelocity;
    }

}
