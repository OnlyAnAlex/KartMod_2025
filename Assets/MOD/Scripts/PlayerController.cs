using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("HUD Settings")]
    public float rouletteSpeed = 0.1f;

    public Image hudItemDisplay; // O componente Image será encontrado automaticamente
    public ItemBoxFunction.Item currentItem;
    public bool isRouletteActive = false;

    private void Start()
    {
        // Procura o GameObject chamado "HUD" e obtém o componente Image dentro dele
        GameObject hud = GameObject.Find("HUD");

        if (hud != null)
        {
            hudItemDisplay = hud.GetComponentInChildren<Image>();
        }
        else
        {
            Debug.LogError("GameObject 'HUD' não foi encontrado na cena!");
        }

        if (hudItemDisplay == null)
        {
            Debug.LogError("HUD Item Display (Image) não foi encontrado dentro do GameObject 'HUD'!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentItem != null && !isRouletteActive)
        {
            UseItem();
        }
    }

    public void ReceiveItem(ItemBoxFunction.Item item)
    {
        if (!isRouletteActive)
        {
            StartCoroutine(ShowItemRoulette(item));
        }
    }

    private IEnumerator ShowItemRoulette(ItemBoxFunction.Item finalItem)
    {
        isRouletteActive = true;
        float timer = 0f;

        while (timer < 2f)
        {
            hudItemDisplay.sprite = GetRandomItemIcon();
            yield return new WaitForSeconds(rouletteSpeed);
            timer += rouletteSpeed;
        }

        hudItemDisplay.sprite = finalItem.icon;
        currentItem = finalItem;
        isRouletteActive = false;
    }

    private Sprite GetRandomItemIcon()
    {
        if (currentItem == null || currentItem.icon == null)
            return null;

        return currentItem.icon; // Retorna o ícone do item atual como exemplo
    }

    private void UseItem()
    {
        if (currentItem != null && currentItem.prefab != null)
        {
            Instantiate(currentItem.prefab, transform.position + transform.forward, transform.rotation);

            // Limpa o item atual e a HUD
            currentItem = null;
            hudItemDisplay.sprite = null;
        }
    }
}
