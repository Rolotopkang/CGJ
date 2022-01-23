using System;
/// <summary>
/// 定义可持有物品。
/// </summary>
/// <author>LviatYi</author>
[Flags]
public enum HeldItem {
    /// <summary>
    /// 武器 1
    /// </summary>
    Gaozi = 1,
    /// <summary>
    /// 武器 2
    /// </summary>
    Fuzi = 2,
    /// <summary>
    /// 食物
    /// </summary>
    Food = 4,
    /// <summary>
    /// 石头
    /// </summary>
    Stone = 8,
    /// <summary>
    /// 床单做的绳子
    /// </summary>
    SheetRope = 16,
}
