using TMPro;
using UnityEngine;

public class Banana: EvolutionItem
{
    [SerializeField] private TMP_Text interactText;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(playerInRange == true)
        {
            interactText.gameObject.SetActive(true);
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (playerInRange == false)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            GiveEvolutionPoints();
        }
        
    }
}