public class ContactFood : EvolutionItem
{
    void Update()
    {
        if(playerInRange == true)
        {
            GiveEvolutionPoints();
        }
    }
}
