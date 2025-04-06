using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class TrackSelection: MonoBehaviour
{
    private int currentTrack;

    public TMP_Text trackName;

    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        SelectTrack(0);
    }

    private void SelectTrack(int _index) {

        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);

        //Debug.Log(_index);

        if (this.gameObject.transform.childCount > _index)
        {
         
            for (int i = 0; 1 < transform.childCount; i++){
           
                transform.GetChild(i).gameObject.SetActive(i == _index);

                if (i == _index)
                {
                    trackName.text = transform.GetChild(i).gameObject.name;
                }

            }
               
            
        }
    
    }

    
    public void ChangeTrack(int _change) {
        currentTrack += _change;
        SelectTrack(currentTrack);
       
    }

    /*public void OnVehicleSelectedSinglePlayer()
    {   
        
        PlayerPrefs.SetInt("SelectedTrack", currentTrack);

        //Debug.Log(currentCar);

        //SceneManager.LoadScene("MainScene"); 
    }*/



    public void GoToTrack() {
        if (currentTrack == 0) {
            SceneManager.LoadScene("Pista1");
        } else if (currentTrack == 1) {
            SceneManager.LoadScene("Pista2");
        }


        
    }
}
