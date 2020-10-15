using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private Enemy shooter;
    [SerializeField]
    private Enemy flyer;


    public void spawnEnemyShips(string type, int amount, float wait = 0)
    {
        StartCoroutine(startSpawning(type, amount, wait));
    }

    private IEnumerator startSpawning(string type, int amount, float wait = 0)
    {
        for (int i = 0; i < amount; i++)
        {
            createEnemy(type);
            yield return new WaitForSeconds(wait);
        }
    }    


    private Enemy createEnemy(string enemyType)
    {
        Enemy shipToReturn = null;

        switch (enemyType)
        {
            case "Shooter":
                shipToReturn = Instantiate(shooter);
                break;
            case "Flyer":
                shipToReturn = Instantiate(flyer);
                break;
            default:
                Debug.LogWarning("!! There is no enemy ship of type \"" + enemyType + "\"");
                break;
        }

        shipToReturn.randomSpawn();
        return shipToReturn;
    }
}
