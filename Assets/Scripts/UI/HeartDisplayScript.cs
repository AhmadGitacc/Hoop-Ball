using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    public GameObject heart;
    public Transform container;
    private List<GameObject> hearts = new List<GameObject>();

    public void UpdateHealth(int currentHealth)
    {
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();

        for (int i = 0; i < currentHealth; i++)
        {
            GameObject newHeart = Instantiate(heart, container);
            hearts.Add(newHeart);
        }
    }
}
