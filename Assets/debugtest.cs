using UnityEngine;

public class debugtest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("SelectedP1"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
