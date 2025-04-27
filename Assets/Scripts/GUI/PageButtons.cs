using UnityEngine;
using UnityEngine.UI;

public class PageButtons : MonoBehaviour
{
    public GameObject[] pages;  // Array to store pages in inspector
    private int PageIndex = 0; // Current page starting at 0

    void Start()
    {
        UpdatePages();
    }

    public void PreviousPage()
    {
        PageIndex = (PageIndex - 1 + pages.Length) % pages.Length;  // Loops backward, keeps index in range
        UpdatePages();
    }

    public void NextPage()
    {
        PageIndex = (PageIndex + 1) % pages.Length;  // Loops forward
        UpdatePages();
    }

    private void UpdatePages()
    {
        for (int i = 0; i < pages.Length; i++) // Loops through each page
        {
            pages[i].SetActive(i == PageIndex); // Set only the PageIndex active
        }
    }
}
