using UnityEngine;
using Cinemachine;
using KartGame.KartSystems;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] vehicles; // Array de ve�culos que podem ser spawnados
    /*
     * 0 - Turbina
     * 1 - Azul�o
     * 2 - Mega F1
     * 3 - Burno Kart
     * 4 - Ariate
     * 
     */

    public CinemachineVirtualCamera virtualCamera; // Refer�ncia � Cinemachine Virtual Camera
    private GameObject spawnedVehicle; // O ve�culo instanciado

    void Awake()
    {
        // L� a escolha do ve�culo a partir do PlayerPrefs
        int selectedVehicleIndex = PlayerPrefs.GetInt("SelectedP1", 0); // Padr�o para 0 se n�o encontrado

        // Checa se o �ndice � v�lido
        if (selectedVehicleIndex >= 0 && selectedVehicleIndex < vehicles.Length)
        {
            // Instancia o ve�culo escolhido na posi��o do spawner
            spawnedVehicle = Instantiate(vehicles[selectedVehicleIndex], transform.position, transform.rotation);


            spawnedVehicle.GetComponent<KeyboardInput>().TurnInputName = "HorizontalP1";
            spawnedVehicle.GetComponent<KeyboardInput>().AccelerateButtonName = "VerticalUpP1";
            spawnedVehicle.GetComponent<KeyboardInput>().BrakeButtonName = "VerticalDownP1";
            //spawnedVehicle2.GetComponent<PlayerPowers>().inputToUsePower = "UsePowerP2";

            // Coloca as c�meras para seguirem os karts.


            virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = spawnedVehicle.transform;
            virtualCamera.GetComponent<CinemachineVirtualCamera>().LookAt = spawnedVehicle.transform;


            // Configura a Cinemachine Virtual Camera para seguir o ve�culo
            if (virtualCamera != null)
            {
                // Atribui o ve�culo como o alvo de Follow e Look At da Cinemachine
                //virtualCamera.Follow = spawnedVehicle.transform;
                //virtualCamera.LookAt = spawnedVehicle.transform;
            }
        }
        else
        {
            Debug.LogError("�ndice de ve�culo inv�lido.");
        }
    }
}
