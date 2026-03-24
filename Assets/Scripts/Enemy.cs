using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage(int damage)
    {
        health -= damage;
        print($"{name} took {damage} damage!!");

        if ( health <= 0 )
        {
            Destroy(gameObject, 1);
        }
    }
}
