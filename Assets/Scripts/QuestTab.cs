using UnityEngine;

public class QuestTab : MonoBehaviour
{
    [SerializeField] GameObject questTab;
    private bool QuestisOpen = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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

    }

    public void OpenQuests()
    {

    }
}
