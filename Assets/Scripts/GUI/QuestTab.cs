using UnityEngine;

public class QuestTab : MonoBehaviour
{
    [SerializeField] GameObject questTab;

    private bool QuestisOpen = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale > 0)
        {
            if (QuestisOpen)
            {
                CloseQuests();
            }
            else
            {
                OpenQuests();
            }
        }
    }
    public void CloseQuests()
    {
        questTab.SetActive(false);
        QuestisOpen = false;
    }

    public void OpenQuests()
    {
        questTab.SetActive(true);
        QuestisOpen = true;
    }
}
