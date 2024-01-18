using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

// GameManager 类负责管理游戏中的全局数据和逻辑
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private PackageTable packageTable;

    // 在 Awake 方法中进行单例的初始化和对象的不销毁设置
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 获取 GameManager 的单例实例
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // 游戏开始时调用，打开初始界面并输出背包本地数据和包裹表数据的数量
    void Start()
    {
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);
        //print(GetPackageLocalData().Count);
        //print(GetPackageTable().DataList.Count);
    }

    // 获取数据，数据存储在本地
    public PackageTable GetPackageTable()
    {
        if (packageTable == null)
        {
            packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        }
        return packageTable;
    }

    // 获取背包本地数据
    public List<PackageLocalItem> GetPackageLocalData()
    {
        return PackageLocalData.Instance.LoadPackage();
    }

    // 根据物品ID获取包裹表中的物品数据
    public PackageTableItem GetPackageItemById(int id)
    {
        List<PackageTableItem> packageDataList = GetPackageTable().DataList;
        foreach (PackageTableItem item in packageDataList)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;
    }

    // 根据唯一标识符获取背包本地数据中的物品数据
    public PackageLocalItem GetPackageLocalItemByUId(string uid)
    {
        List<PackageLocalItem> packageDataList = GetPackageLocalData();
        foreach (PackageLocalItem item in packageDataList)
        {
            if (item.uid == uid)
            {
                return item;
            }
        }
        return null;
    }

    // 获取排序后的背包本地数据
    public List<PackageLocalItem> GetSortPackageLocalData()
    {
        List<PackageLocalItem> localItems = PackageLocalData.Instance.LoadPackage();
        localItems.Sort(new PackageItemComparer());
        return localItems;
    }
}

// PackageItemComparer 类实现了 IComparer 接口，用于比较 PackageLocalItem 对象的排序规则
public class PackageItemComparer : IComparer<PackageLocalItem>
{
    // 比较方法，首先按照包裹表中的星级、ID和等级进行排序
    public int Compare(PackageLocalItem a, PackageLocalItem b)
    {
        PackageTableItem x = GameManager.Instance.GetPackageItemById(a.id);
        PackageTableItem y = GameManager.Instance.GetPackageItemById(b.id);

        // 首先按 star 从大到小排序
        int starComparison = y.star.CompareTo(x.star);

        // 如果 star 相同，则按 id 从小到大排序
        if (starComparison == 0)
        {
            int idComparison = x.id.CompareTo(y.id);
            if (idComparison == 0)
            {
                // 如果 id 也相同，则按等级从大到小排序
                return b.level.CompareTo(a.level);
            }
            return idComparison;
        }

        return starComparison;
    }
}
