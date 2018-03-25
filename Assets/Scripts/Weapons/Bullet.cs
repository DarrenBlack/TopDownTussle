using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int maxDamage;
    public float speed;
    public float lifetime;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
        lifetime -= Time.deltaTime;
    }

    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
