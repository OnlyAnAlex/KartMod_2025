using UnityEngine;
using Cinemachine;

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

    public CinemachineVirtualCamera virtualCamera; // Referência à Cinemachine Virtual Camera
    private GameObject spawnedVehicle; // O veículo instanciado

    void Start()
    {
        // Lê a escolha do veículo a partir do PlayerPrefs
        int selectedVehicleIndex = PlayerPrefs.GetInt("SelectedP2", 0); // Padrão para 0 se não encontrado

        // Checa se o índice é válido
        if (selectedVehicleIndex >= 0 && selectedVehicleIndex < vehicles.Length)
        {
            // Instancia o veículo escolhido na posição do spawner
            spawnedVehicle = Instantiate(vehicles[selectedVehicleIndex], transform.position, transform.rotation);

            // Configura a Cinemachine Virtual Camera para seguir o veículo
            if (virtualCamera != null)
            {
                // Atribui o veículo como o alvo de Follow e Look At da Cinemachine
                virtualCamera.Follow = spawnedVehicle.transform;
                virtualCamera.LookAt = spawnedVehicle.transform;
            }
        }
        else
        {
            Debug.LogError("Índice de veículo inválido.");
        }
    }
}
