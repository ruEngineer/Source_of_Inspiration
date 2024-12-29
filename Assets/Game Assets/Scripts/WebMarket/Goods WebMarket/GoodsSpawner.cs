using UnityEngine;

public class GoodsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;

    public void SpawnGoods(GameObject goods)
    {
        Instantiate(goods, _spawnTransform.position, Quaternion.identity);
    }
}
