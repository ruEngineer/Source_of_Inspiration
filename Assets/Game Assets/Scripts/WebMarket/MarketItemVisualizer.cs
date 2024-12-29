using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketItemVisualizer : MonoBehaviour
{    
    [SerializeField] private MarketItemSlot _marketItemSlot;
    [SerializeField] private GoodsButtonBought _goodsBoughtButton;
    [SerializeField] private TMP_Text _goodsText;

    [SerializeField] private Image _goodsImage;

    [SerializeField] private AudioSource _succesfulSound;
    [SerializeField] private AudioSource _invalidSound;

    private void OnEnable()
    {
        _marketItemSlot.OnIsAvailablePurchaseStateChanged += UpdateUI;
        _goodsBoughtButton.OnInvalidBought += PlayInvalidBoughtSound;
        _goodsBoughtButton.OnSuccesfulBought += PlaySuccesfulBoughtSound;
    }

    private void OnDisable()
    {
        _marketItemSlot.OnIsAvailablePurchaseStateChanged -= UpdateUI;
        _goodsBoughtButton.OnInvalidBought -= PlayInvalidBoughtSound;
        _goodsBoughtButton.OnSuccesfulBought -= PlaySuccesfulBoughtSound;
    }

    private void UpdateUI(bool isAvailableForPurchase)
    {
        UpdateGoodsText(isAvailableForPurchase);
        UpdateGoodsImage(isAvailableForPurchase);
    }

    private void UpdateGoodsText(bool isAvailableForPurchase)
    {
        if(isAvailableForPurchase == true)
        {
            if(GameLanguage.Instance.GetLanguage() == "ru")
            {
                _goodsText.text = _marketItemSlot.GoodsNameRu;
            }
            else if(GameLanguage.Instance.GetLanguage() == "en")
            {
                _goodsText.text = _marketItemSlot.GoodsNameEn;
            }
        }
        else if(isAvailableForPurchase == false)
        {
            if(GameLanguage.Instance.GetLanguage() == "ru")
            {
                _goodsText.text = "Закрыто";
            }
            else if(GameLanguage.Instance.GetLanguage() == "en")
            {
                _goodsText.text = "Closed";
            }
        }
    }

    private void UpdateGoodsImage(bool isAvailableForPurchase)
    {
        _goodsImage.sprite = _marketItemSlot.Goods.GoodsIcon;
        if(isAvailableForPurchase == true)
        {
            _goodsImage.color = Color.white;
        }

        else
        {
            _goodsImage.color = Color.grey;
        }
    }

    private void PlayInvalidBoughtSound()
    {
        _invalidSound.PlayOneShot(_invalidSound.clip);
    }

    private void PlaySuccesfulBoughtSound()
    {
        _succesfulSound.PlayOneShot(_succesfulSound.clip);
    }
}
