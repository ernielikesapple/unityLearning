using UnityEngine;
using UnityEngine.AI;
 
public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public float lookRadius = 10f;

    Transform target; // a reference to the player
    NavMeshAgent agent; // a reference to the enemy 

    public void TakeDamage(float damageAmount) {      // for the gun function to call when the enemy gets shots

        
        health -= damageAmount;

        Debug.Log(" ===damage===" + damageAmount + "---=health===" + health);
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
        // GameObject.FindGameObjectsWithTag()  ,  for search the player, we don't use this method, since if we do so, each enemy will start to search the player, it's a high cost for cpu
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   // moves the enemy towards the player
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
