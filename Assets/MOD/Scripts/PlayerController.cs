using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("HUD Settings")]
    public Image hudItemDisplay; // Referência ao ícone na HUD
    public float rouletteSpeed = 0.1f; // Velocidade da roleta em segundos

    private ItemBoxFunction.Item currentItem; // Item atual do jogador
    private bool isRouletteActive = false; // Controle para evitar sobreposição de roletas

    private void Update()
    {
        // Verifica se o jogador pressionou espaço para usar o item
        if (Input.GetKeyDown(KeyCode.Space) && currentItem != null && !isRouletteActive)
        {
            UseItem();
        }
    }

    /// <summary>
    /// Recebe um item da caixa de itens e inicia a roleta.
    /// </summary>
    /// <param name="item">O item final recebido.</param>
    public void ReceiveItem(ItemBoxFunction.Item item)
    {
        if (!isRouletteActive)
        {
            StartCoroutine(ShowItemRoulette(item));
        }
    }

    /// <summary>
    /// Mostra a roleta de itens antes de definir o item final.
    /// </summary>
    /// <param name="finalItem">O item final que será atribuído ao jogador.</param>
    private IEnumerator ShowItemRoulette(ItemBoxFunction.Item finalItem)
    {
        isRouletteActive = true;
        float timer = 0f;

        // Mostra ícones aleatórios na HUD
        while (timer < 2f) // Exibe a roleta por 2 segundos
        {
            hudItemDisplay.sprite = GetRandomItemIcon();
            yield return new WaitForSeconds(rouletteSpeed);
            timer += rouletteSpeed;
        }

        // Exibe o item final
        hudItemDisplay.sprite = finalItem.icon;
        currentItem = finalItem;
        isRouletteActive = false;
    }

    /// <summary>
    /// Retorna um ícone aleatório (usado na roleta).
    /// </summary>
    /// <returns>Sprite de um item aleatório.</returns>
    private Sprite GetRandomItemIcon()
    {
        // Evita usar currentItem se for nulo
        if (currentItem == null || currentItem.icon == null)
            return null;

        return currentItem.icon; // Retorna o ícone do item atual como exemplo
    }

    /// <summary>
    /// Usa o item atual do jogador e executa sua funcionalidade.
    /// </summary>
    private void UseItem()
    {
        if (currentItem != null && currentItem.prefab != null)
        {
            // Instancia o prefab do item na frente do jogador
            Instantiate(currentItem.prefab, transform.position + transform.forward, transform.rotation);

            //Instantiate(currentItem.prefab, transform.position + transform.forward, Quaternion.identity);

            // Limpa o item atual e a HUD
            currentItem = null;
            hudItemDisplay.sprite = null;
        }
    }
}
