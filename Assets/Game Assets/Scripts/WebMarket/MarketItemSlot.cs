using System;
using UnityEngine;

public class MarketItemSlot : MonoBehaviour
{
    public bool IsAvailableForPurchase { private set; get; }
    public Sprite GoodsSprite { private set; get; }
    public string GoodsNameRu { private set; get; }
    public string GoodsNameEn { private set; get; }
    public InternetGoods Goods;
    [SerializeField] private GameDayHandler _gameDayHandler;

    public event Action<bool> OnIsAvailablePurchaseStateChanged;

    private void OnEnable()
    {
        _gameDayHandler.OnCurrentDayChanged += CheckForPurchaseAvailable;
    }

    private void OnDisable()
    {
        _gameDayHandler.OnCurrentDayChanged -= CheckForPurchaseAvailable;
    }

    public void Init()
    {
        GoodsSprite = Goods.GoodsIcon;

        GoodsNameRu = Goods.GoodsNameRu;
        GoodsNameEn = Goods.GoodsNameEn;

        CheckForPurchaseAvailable(1);
    }

    private void CheckForPurchaseAvailable(int currentDay)
    {
        IsAvailableForPurchase = Goods.DayFromAvailable == currentDay;
        OnIsAvailablePurchaseStateChanged?.Invoke(IsAvailableForPurchase);
    }
}
