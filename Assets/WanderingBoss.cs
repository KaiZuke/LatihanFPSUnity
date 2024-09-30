using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingBoss : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Boss Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            ReactToHit();
        }
    }

    public void ReactToHit()
    {
        WanderingAI behaviour = GetComponent<WanderingAI>();
        if (behaviour != null)
        {
            behaviour.setAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(0, 0, 75);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
