using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteAll(); // Delete all stored player preferences
        PlayerPrefs.Save(); // Save changes immediatly
    }
}
