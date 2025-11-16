using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    public TextMeshPro textMeshPro;

        void Start()
    {
        StartCoroutine(ChangeTextCoroutine());
    }
        public IEnumerator ChangeTextCoroutine()
    {
        //while variable isInvicible is true, the graphics alpha of character altern from 0 to 1 every xf time
        while(true)
        {
            textMeshPro.text = "YOU";
            yield return new WaitForSeconds(1f);
            textMeshPro.text = "WIN";
            yield return new WaitForSeconds(1f);
        }
    }

}
