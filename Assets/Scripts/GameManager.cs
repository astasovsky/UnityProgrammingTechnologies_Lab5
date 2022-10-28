using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Target[] targets;

    private const float SpawnRate = 1;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
        }
    }
}