using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damageAmount) {      // for the gun function to call when the enemy gets shots
        health -= damageAmount;
        if (health <= 0f) {
            EnemyDie();
        }

    }



    void EnemyDie()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
