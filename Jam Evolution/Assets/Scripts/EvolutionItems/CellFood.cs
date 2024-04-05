public class CellFood: EvolutionItem
{
    void Update()
    {
        if(playerInRange == true)
        {
            GiveEvolutionPoints();
        }
    }
}
