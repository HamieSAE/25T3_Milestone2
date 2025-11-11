using UnityEngine;

public class GameManager : MonoBehaviour
{

    private TargetHP[] targets;
    void Awake()
    {
        targets = FindObjectsByType<TargetHP>(FindObjectsSortMode.None);

        BubbleSort();
    }

    void BubbleSort()
    {
        int n = targets.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - j - 1; j++)
            {
                if (targets[j].GetHealthPoints() < targets[j + 1].GetHealthPoints())
                {
                    TargetHP tempTargte = targets[j];
                    targets[j] = targets[j + 1];
                    targets[j + 1] = tempTargte;
                }
            }
        }
    }

    public TargetHP[] GetSortedTargets()
    {
        return targets;
    }
}
