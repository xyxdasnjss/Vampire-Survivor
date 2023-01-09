using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class UpgdPanel : UI_Base
{
    int itemType;
    string itemName;
    enum Texts
    {
        UpgdTitleText,
        UpgdDescText
    }

    enum Images
    {
        UpgdImg,
        UpgdDescPanel,
    }
    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        gameObject.AddUIEvent(OnStatOrWeaponUp);
    }

    void OnStatOrWeaponUp(PointerEventData data)
    {
        string title =  Get<TextMeshProUGUI>((int)Texts.UpgdTitleText).text;
        Debug.Log($"{title} select!");
        Managers.Event.LevelUpOverEvent(itemType, itemName);
    }

    public void SetInfo(string title, string desc)
    {
        Get<TextMeshProUGUI>((int)Texts.UpgdTitleText).text = title;
        Get<TextMeshProUGUI>((int)Texts.UpgdDescText).text = desc;
    }

    internal void SetData(string[] data)
    {
        itemType = Int32.Parse(data[0]);
        itemName = data[1];
    }
}
