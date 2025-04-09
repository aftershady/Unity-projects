using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnBossDeath : MonoBehaviour
{
    public GameObject boss;
    public bool isBossDead = false;
    public bool isPlayerDead = false;

    void Update()
    {
        if (PlayerHealth.instance.currentHealth <= 0)
        {
            isPlayerDead = true;
        }

        if (boss == null && !isBossDead && !isPlayerDead)
        {
            isBossDead = true;
            StartCoroutine(SmoothTransition(new Vector3(5f, 4f, 0f), 2f));
        }
    }

    private IEnumerator SmoothTransition(Vector3 targetPosition, float duration)
    {
        yield return new WaitForSeconds(1f);
        if(PlayerHealth.instance.currentHealth <= 0)
        {
            yield break; // Exit if the player is dead
        }
        AudioManager.instance.bossIsDead = true;
        isBossDead = true;
        yield return new WaitForSeconds(7.5f);

        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the final position is set
    }
}
