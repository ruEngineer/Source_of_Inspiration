using UnityEngine;

[CreateAssetMenu(fileName = "Goods Data", menuName = "Internet Goods/Goods Data", order = 1)]
public class InternetGoods : ScriptableObject
{
    public string GoodsNameRu;
    public string GoodsNameEn;
    public Sprite GoodsIcon;
    [Range(1, 6)]
    public int DayFromAvailable;
    public GameObject GoodsPrefab;
}
