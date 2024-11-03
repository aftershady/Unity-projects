using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private Material originalMaterial; // Assign your Blue material here
    [SerializeField] private Color highlightColor = Color.red;

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        int index = 0;

        while (true)
        {
                if (cubes[index] == null)
            {
                yield break; // Exit the coroutine if any cube is destroyed
            }
            // Change the color of the current cube to red
            Renderer currentRenderer = cubes[index].GetComponent<Renderer>();
            currentRenderer.material.color = highlightColor;

            // Wait for 1 second
            yield return new WaitForSeconds(1);

            // Change the material of the current cube back to the original
            currentRenderer.material = originalMaterial;

            // Move to the next cube in the array, loop back to 0 if needed
            index = (index + 1) % cubes.Length;
        }
    }
}
