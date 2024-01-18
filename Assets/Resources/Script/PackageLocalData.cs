using UnityEngine;
using System.Collections.Generic;

// PackageLocalData 类用于管理本地背包数据的保存和加载
public class PackageLocalData
{
    private static PackageLocalData _instance;

    // 获取 PackageLocalData 的单例实例
    public static PackageLocalData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PackageLocalData();
            }
            return _instance;
        }
    }

    // 背包中的物品列表
    public List<PackageLocalItem> items;

    // 将背包数据保存到 PlayerPrefs
    public void SavePackage()
    {
        // 将 PackageLocalData 对象转换为 JSON 字符串
        string inventoryJson = JsonUtility.ToJson(this);

        // 保存 JSON 字符串到 PlayerPrefs
        PlayerPrefs.SetString("PackageLocalData", inventoryJson);
        PlayerPrefs.Save();
    }

    // 从 PlayerPrefs 加载背包数据
    public List<PackageLocalItem> LoadPackage()
    {
        // 如果已经加载过数据，直接返回缓存的 items 列表
        if (items != null)
        {
            return items;
        }

        // 如果 PlayerPrefs 中存在背包数据，解析 JSON 字符串并返回物品列表
        if (PlayerPrefs.HasKey("PackageLocalData"))
        {
            string inventoryJson = PlayerPrefs.GetString("PackageLocalData");
            Debug.Log(inventoryJson);
            PackageLocalData packageLocalData = JsonUtility.FromJson<PackageLocalData>(inventoryJson);
            items = packageLocalData.items;
            return items;
        }
        else
        {
            // 如果 PlayerPrefs 中不存在背包数据，创建一个新的空列表并返回
            items = new List<PackageLocalItem>();
            return items;
        }
    }
}

// PackageLocalItem 类表示背包中的单个物品的数据结构
[System.Serializable]
public class PackageLocalItem
{
    // 物品的唯一标识符
    public string uid;
    // 物品的ID
    public int id;
    // 物品的数量
    public int num;
    // 物品的等级
    public int level;
    // 物品是否为新物品
    public bool isNew;
    // 重写 ToString 方法，用于输出物品信息的字符串表示
    public override string ToString()
    {
        return string.Format("[id]:{0} [num]:{1}", uid, num);
    }
}
