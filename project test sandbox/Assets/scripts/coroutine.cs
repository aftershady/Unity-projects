using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject three;
    [SerializeField] private GameObject four;
    [SerializeField] private GameObject five;
    [SerializeField] private GameObject six;
    [SerializeField] private GameObject seven;
    [SerializeField] private GameObject height;
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        Destroy(one);
        yield return new WaitForSeconds(1);
        Destroy(two);
        yield return new WaitForSeconds(1);
        Destroy(three);
        yield return new WaitForSeconds(1);
        Destroy(four);
        yield return new WaitForSeconds(1);
        Destroy(five);
        yield return new WaitForSeconds(1);
        Destroy(six);
        yield return new WaitForSeconds(1);
        Destroy(seven);
        yield return new WaitForSeconds(1);
        Destroy(height);
    }
}
