using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private EnemyFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomSpawn());
    }

    private IEnumerator randomSpawn()
    {
        float time = 1;
        while (true)
        {
            int type = (int)(Random.value * 10) % 4 + 1;


            switch (type)
            {

                case 1:
                    factory.spawnEnemyShips("Shooter", 1);
                    yield return new WaitForSeconds(1f);
                    factory.spawnEnemyShips("Flyer", 10, 0.3f);
                    yield return new WaitForSeconds(1f);
                    factory.spawnEnemyShips("Shooter", 1);
                    yield return new WaitForSeconds(1f);
                    break;

                case 2:
                    factory.spawnEnemyShips("Flyer", 30, 0.3f);
                    break;
                    
                case 3:
                    factory.spawnEnemyShips("Shooter", 1);
                    yield return new WaitForSeconds(1f);
                    factory.spawnEnemyShips("Flyer", 8, 0.5f);
                    yield return new WaitForSeconds(0.5f);
                    factory.spawnEnemyShips("Flyer", 8, 0.3f);
                    yield return new WaitForSeconds(2f);
                    break;
                    
                case 4:
                    yield return new WaitForSeconds(1f);
                    factory.spawnEnemyShips("Flyer", 8, 0.1f);
                    yield return new WaitForSeconds(1f);
                    factory.spawnEnemyShips("Shooter", 1);
                    factory.spawnEnemyShips("Flyer", 10, 0.3f);
                    yield return new WaitForSeconds(1f);

                    break;

                default:
                    break;
            }
            if (time > 0)
            {
                yield return new WaitForSeconds(time);
                time -= 0.1f;
            }
        }
    }
    
}
