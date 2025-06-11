using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotionAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the animation
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("StartAnimation");
        }
    }

    IEnumerator AnimatePotion()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0, 0.2f, 0);
        float duration = 1f;
        while (true)
        {
            // Move up
            float elapsed = 0f;
            while (elapsed < duration)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = endPos;

            // Move down
            elapsed = 0f;
            while (elapsed < duration)
            {
                transform.position = Vector3.Lerp(endPos, startPos, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = startPos;
        }
    }

    void OnEnable()
    {
        StartCoroutine(AnimatePotion());
    }

}
