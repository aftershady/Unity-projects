using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private void Update()
    {
        // Vérifiez si l'utilisateur a cliqué sur le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // Crée un ray à partir de la position de la caméra vers la position de la souris
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Dessine le Ray pour le débogage
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);

            // Vérifiez si le ray touche un objet
            if (Physics.Raycast(ray, out hit, 50f))
            {
                hit.transform.gameObject.GetComponent<AudioSource>().enabled = true;
                // Exemple d'interaction : détruire l'objet touché
                Destroy(hit.transform.gameObject);
            }
        }
    }
}

