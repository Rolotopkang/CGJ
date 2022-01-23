using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Bag Manager 类。
/// 维护了背包中所包含的物品。
/// 采用 Flags 技术。
/// </summary>
/// <author>LviatYi</author>
public class BagManager : MonoBehaviour {
    HeldItem heldItems;

    [Header("Ui")]
    [SerializeField]
    GameObject bagUi;

    List<Image> images;

    private void Start() {
        images = new List<Image>(bagUi.GetComponentsInChildren<Image>());
    }

    private void Update() {
        int i = 0;
        foreach (HeldItem item in Enum.GetValues(typeof(HeldItem))) {
            if (i >= images.Count) {
                continue;
            }

            if (IsHaveItem(item)) {
                images[i].enabled = true;
            } else {
                images[i].enabled = false;
            }
            i++;
        }
    }

    /// <summary>
    /// 向背包中增加物品。
    /// </summary>
    /// <param name="item">待添加的物品</param>
    public void AddItemToBag(HeldItem item) {
        this.heldItems |= item;
    }

    /// <summary>
    /// 从背包中删除物品。
    /// </summary>
    /// <param name="item">待删除的物品</param>
    public void DropItemFromBag(HeldItem item) {
        this.heldItems ^= item;
    }

    /// <summary>
    /// 获取背包中包含的物品。
    /// </summary>
    /// <returns></returns>
    public HeldItem GetHeldItems() {
        return this.heldItems;
    }

    /// <summary>
    /// 判断背包中是否包含指定物品。
    /// </summary>
    /// <param name="item">指定的物品</param>
    /// <returns></returns>
    public bool IsHaveItem(HeldItem item) {
        return this.heldItems.HasFlag(item);
    }
}
