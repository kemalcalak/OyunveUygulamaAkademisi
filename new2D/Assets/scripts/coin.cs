using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    private int score = 0;
    Collider2D _collider;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            Debug.Log(score);
            score++;
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
