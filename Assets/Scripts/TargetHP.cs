using UnityEngine;

public class TargetHP : MonoBehaviour
{
    /*  HP value serialized so you can edit it in the Inspector 
     *  while keeping the HP Value Private so
     *  Other scripts don't accidentally change its value    
    */
    [SerializeField] private int HP;

    /* Method to get the target's HP value 
     * - This will be used by GameManager 
     * To gather all the HPs in the game
     * So it can be sorted from Highest to the Lowest
     * -------------------------------------
     * You need to make sure you make the method an int method so it returns an integer
     */
    public int GetHealthPoints()
    {
        return HP;
    }
}
