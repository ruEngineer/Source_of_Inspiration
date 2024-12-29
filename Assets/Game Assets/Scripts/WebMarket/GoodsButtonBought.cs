using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GoodsButtonBought : MonoBehaviour
{
    [SerializeField] private MarketItemSlot _marketItemSlot;
    [SerializeField] private GoodsSpawner _goodsSpawner;
    
    private Button _boughtButton;

    public Action OnSuccesfulBought;
    public Action OnInvalidBought;

    private void OnEnable()
    {
        _boughtButton = GetComponent<Button>();
        _boughtButton.AddEventOnClick(BoughtGoods);
    }

    private void OnDisable()
    {
        _boughtButton.RemoveEventOnClick(BoughtGoods);
    }

    private void BoughtGoods()
    {
        if(_marketItemSlot.IsAvailableForPurchase == true)
        {
            _goodsSpawner.SpawnGoods(_marketItemSlot.Goods.GoodsPrefab);
            _boughtButton.RemoveEventOnClick(BoughtGoods);
            OnSuccesfulBought?.Invoke();
            Destroy(this);
        }

        else
        {
            OnInvalidBought?.Invoke();
        }
    }
}
 