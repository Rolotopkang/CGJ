using UnityEngine;

/// <summary>
/// Bag Manager 类。
/// 维护了背包中所包含的物品。
/// 采用 Flags 技术。
/// </summary>
/// <author>LviatYi</author>
public class BagManager : MonoBehaviour {
    HeldItem heldItems;

    /// <summary>
    /// 向背包中增加物品。
    /// </summary>
    /// <param name="item">待添加的物品</param>
    public void addItemToBag(HeldItem item) {
        this.heldItems |= item;
    }

    /// <summary>
    /// 从背包中删除物品。
    /// </summary>
    /// <param name="item">待删除的物品</param>
    public void dropItemFromBag(HeldItem item) {
        this.heldItems ^= item;
    }

    /// <summary>
    /// 获取背包中包含的物品。
    /// </summary>
    /// <returns></returns>
    public HeldItem getHeldItems() {
        return this.heldItems;
    }

    /// <summary>
    /// 判断背包中是否包含指定物品。
    /// </summary>
    /// <param name="item">指定的物品</param>
    /// <returns></returns>
    public bool isHaveItem(HeldItem item) {
        return this.heldItems.HasFlag(item);
    }
}
