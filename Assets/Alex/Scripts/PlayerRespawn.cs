using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; 
    public LayerMask groundLayer; 

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
    }
}
