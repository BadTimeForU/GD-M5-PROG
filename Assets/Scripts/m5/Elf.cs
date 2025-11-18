using System.Collections;
using UnityEngine;

public class Elfs : EnemyParent
{
    private Renderer rend;

    void Start()
    {
        health = 2;
        speed = 4f;
        rend = GetComponent<Renderer>();
        StartCoroutine(ToggleVisibility());
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            rend.enabled = false;
            yield return new WaitForSeconds(0.5f);
            rend.enabled = true;
        }
    }
}