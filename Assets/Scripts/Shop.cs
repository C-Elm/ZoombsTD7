using UnityEngine;

public class Shop : MonoBehaviour
{
    public SoldierBlueprint standardSoldier;
    public SoldierBlueprint tank;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardSoldier()
    {
        buildManager.SelectSoldierToBuild(standardSoldier);
    }
    public void SelectTank()
    {
        buildManager.SelectSoldierToBuild(tank);
    }


}
