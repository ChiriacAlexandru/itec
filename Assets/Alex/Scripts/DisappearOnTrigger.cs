using UnityEngine;

public class DisappearOnTrigger : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (prefabToSpawn != null)
            {
                Instantiate(prefabToSpawn, spawnPoint != null ? spawnPoint.position : transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
    
}
