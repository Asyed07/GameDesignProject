using UnityEngine;
using UnityEngine.UI;

public class PageButtons : MonoBehaviour
{
    public GameObject[] pages;  // Assign all your pages in the Inspector
    private int PageIndex = 0;

    void Start()
    {
        UpdatePages();
    }

    public void PreviousPage()
    {
        PageIndex = (PageIndex - 1 + pages.Length) % pages.Length;  // Loops backward
        UpdatePages();
    }

    public void NextPage()
    {
        PageIndex = (PageIndex + 1) % pages.Length;  // Loops forward
        UpdatePages();
    }

    private void UpdatePages()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == PageIndex);
        }
    }
}