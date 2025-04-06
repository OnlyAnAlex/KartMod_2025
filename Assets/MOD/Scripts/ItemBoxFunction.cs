using UnityEngine;

public class ItemBoxFunction : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string name;
        public Sprite icon;
        public GameObject prefab;
        public float chance; // Chance de aparecer
    }

    public Item[] items;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Item selectedItem = GetRandomItem();
            player.ReceiveItem(selectedItem);
            Destroy(gameObject); // Destruir a caixa após pegar o item
        }
    }

    private Item GetRandomItem()
    {
        float totalChance = 0f;
        foreach (Item item in items)
            totalChance += item.chance;

        float randomValue = Random.Range(0, totalChance);
        float cumulativeChance = 0f;

        foreach (Item item in items)
        {
            cumulativeChance += item.chance;
            if (randomValue <= cumulativeChance)
                return item;
        }

        return null; // Caso nenhuma seja selecionada (não deveria acontecer se configurado corretamente)
    }
}
