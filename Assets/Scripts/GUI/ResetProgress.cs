using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
