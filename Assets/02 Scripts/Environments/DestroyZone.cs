using System;
using UnityEngine;

public class DestrotZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Pool로 총알 반환
        if (other.gameObject.CompareTag("Bullet") || other.GetComponent<Bullet>() != null)
        {
            other.gameObject.SetActive(false);
        }
        
        // Pool로 Enemy 반환
        else if (other.gameObject.CompareTag("Enemy") || other.GetComponent<Enemy>() != null)
        {
            other.gameObject.SetActive(false);
        }
        // Pool로 Item 반환
        else if (other.gameObject.CompareTag("Item") || other.GetComponent<Item>() != null)
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}