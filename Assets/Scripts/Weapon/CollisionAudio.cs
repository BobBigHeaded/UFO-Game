using UnityEngine;

public class CollisionAudio : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }
}
