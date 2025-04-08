using UnityEngine;
using Cinemachine;
using KartGame.KartSystems;

public class CarSpawnerMP : MonoBehaviour
{
    public GameObject[] vehicles; // Array de veículos que podem ser spawnados
    /*
     * 0 - Turbina
     * 1 - Azulão
     * 2 - Mega F1
     * 3 - Burno Kart
     * 4 - Ariate
     * 
     */

    public CinemachineVirtualCamera virtualCamera2;
    private GameObject spawnedVehicle2;

    void Awake()
    {
       
        int selectedVehicleIndex2 = PlayerPrefs.GetInt("SelectedP2", 0); 

        if (selectedVehicleIndex2 >= 0 && selectedVehicleIndex2 < vehicles.Length)
        {
         
            spawnedVehicle2 = Instantiate(vehicles[selectedVehicleIndex2], transform.position, transform.rotation);



            spawnedVehicle2.GetComponent<KeyboardInput>().TurnInputName = "HorizontalP2";
            spawnedVehicle2.GetComponent<KeyboardInput>().AccelerateButtonName = "VerticalUpP2";
            spawnedVehicle2.GetComponent<KeyboardInput>().BrakeButtonName = "VerticalDownP2";
            //spawnedVehicle2.GetComponent<PlayerPowers>().inputToUsePower = "UsePowerP2";

            // Coloca as câmeras para seguirem os karts.


            virtualCamera2.GetComponent<CinemachineVirtualCamera>().Follow = spawnedVehicle2.transform;
            virtualCamera2.GetComponent<CinemachineVirtualCamera>().LookAt = spawnedVehicle2.transform;



            if (virtualCamera2 != null)
            {
             
                //virtualCamera2.Follow = spawnedVehicle2.transform;
                //virtualCamera2.LookAt = spawnedVehicle2.transform;
            }
        }
        else
        {
            Debug.LogError("sem carro lol.");
        }
    }
}
