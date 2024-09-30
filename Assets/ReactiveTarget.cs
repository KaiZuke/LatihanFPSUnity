using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
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
