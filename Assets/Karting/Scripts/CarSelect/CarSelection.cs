using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class CarSelection : MonoBehaviour
{
    private int currentCar;

    public TMP_Text carName;

    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        SelectCar(0);
    }

    void Update()
    {
        Debug.Log("sim");
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeCart(1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeCart(-1);
        }
    }

    private void SelectCar(int _index) {

        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);

        //Debug.Log(_index);

        if (this.gameObject.transform.childCount > _index)
        {
         
            for (int i = 0; 1 < transform.childCount; i++){
           
                transform.GetChild(i).gameObject.SetActive(i == _index);

                if (i == _index)
                {
                    carName.text = transform.GetChild(i).gameObject.name;
                }

            }
               
            
        }
    
    }

    

    public void ChangeCart(int _change) {
        currentCar += _change;
        SelectCar(currentCar);
       
    }
}
