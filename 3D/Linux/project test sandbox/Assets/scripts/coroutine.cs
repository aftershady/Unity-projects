using System.Collections;
using UnityEngine;

// This CoroutineExample class demonstrates how to use a coroutine
// to alternate the color of multiple GameObjects (cubes).
public class CoroutineExample : MonoBehaviour
{
    // Reference to an array of GameObjects (cubes) to modify
    [SerializeField] private GameObject[] cubes;

    // Original material of the cubes (should be assigned in the Inspector)
    [SerializeField] private Material originalMaterial;

    // Highlight color used to change the cubes' color temporarily
    [SerializeField] private Color highlightColor = Color.red;

    // Method called on start, which initiates the coroutine MyCoroutine.
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // Coroutine that loops indefinitely through the cubes, changes their color, and resets it after a delay.
    IEnumerator MyCoroutine()
    {
        int index = 0; // Initializes the index to loop through the cubes

        while (true) // Infinite loop to alternate between the cubes
        {
            // Checks if the current cube still exists (hasn't been destroyed)
            if (cubes[index] == null)
            {
                yield break; // Exits the coroutine if any cube is destroyed
            }

            // Gets the Renderer of the current cube and changes its color to red
            Renderer currentRenderer = cubes[index].GetComponent<Renderer>();
            currentRenderer.material.color = highlightColor;

            // Waits for one second before moving to the next cube
            yield return new WaitForSeconds(1);

            // Resets the current cube's material to the original
            currentRenderer.material = originalMaterial;

            // Moves to the next cube in the array (loops back to the start if needed)
            index = (index + 1) % cubes.Length;
        }
    }
}
