using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public int health;
    public int maxDamage;
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit");
        if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.gameObject.GetComponent<Bullet>().maxDamage);
        }
    }

    public void TakeDamage(int DamageTaken)
    {
        health -= DamageTaken;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //play death animation etc....
        Destroy(this.gameObject);
    }

    

}
