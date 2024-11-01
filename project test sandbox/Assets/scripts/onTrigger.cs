using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
        void OnTriggerEnter(Collider col)
    {
        if(col.name == "character")
        {
            print("Vous êtes entré dans de la zone");
        }
    }
        void OnTriggerExit(Collider col)
    {
        if(col.name == "character")
        {
            print("Vous êtes sortis de la zone");
        }
    }
    void OnTriggerStay(Collider col)
    {
        if(col.name == "character")
        {
            print("Vous êtes dans la zone");
        }
    }
}
