using Unity.VisualScripting;
using UnityEngine;

public class TernaryCondition : MonoBehaviour
{
    private int counter = 0;
    private int counter2 = 2;

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "character" && counter != 3)
        {
            counter++;
            if(counter >= 3)
            {
                Debug.Log("The portal is destroyed");
                return;
            }
            Debug.Log("The portal will disappear if you touch it " + counter2 + " mores times");
            counter2--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 3)
        {
            gameObject.SetActive(false);
        }
    }
}
