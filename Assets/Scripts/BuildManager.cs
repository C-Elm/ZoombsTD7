using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject standardSoldierPrefab;
    public GameObject tankPrefab;

    public bool CanBuild { get { return soldierToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= soldierToBuild.cost; } }

    public void BuildSoldierOn(Node node)
    {
        if(PlayerStats.Money < soldierToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= soldierToBuild.cost;

        GameObject soldier = (GameObject)Instantiate(soldierToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
      node.soldier = soldier;


    }
   

    private SoldierBlueprint soldierToBuild;


   public void SelectSoldierToBuild (SoldierBlueprint soldier)
    {
        soldierToBuild = soldier;
    }
}