using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// GMCmd 类包含一些用于编辑器中的快捷命令的静态方法
public class GMCmd
{
    // 用于在编辑器中创建一个 "读取表格" 的菜单项
    [MenuItem("CMCmd/读取表格")]
    public static void ReadTable()
    {
        // 从Resources加载PackageTable
        PackageTable packageTable = Resources.Load<PackageTable>("TableData/PackageTable");

        // 遍历PackageTable中的每个PackageTableItem并输出信息
        foreach (PackageTableItem packageItem in packageTable.DataList)
        {
            Debug.Log(string.Format("【id】:{0}, 【name】:{1}", packageItem.id, packageItem.name));
        }
    }

   // 用于在编辑器中创建一个 "创建背包测试数据" 的菜单项
   [MenuItem("CMCmd/创建背包测试数据")]
    public static void CreateLocalPackageData()
    {
        // 初始化 PackageLocalData 的实例并设置测试数据
        PackageLocalData.Instance.items = new List<PackageLocalItem>();
        for (int i = 1; i < 9; i++)
        {
            PackageLocalItem packageLocalItem = new PackageLocalItem()
            {
                uid = Guid.NewGuid().ToString(),
                id = UnityEngine.Random.Range(1, 9),
                num = UnityEngine.Random.Range(1, 11),
                level = UnityEngine.Random.Range(1, 30),
                isNew = i % 2 == 1
            };
            PackageLocalData.Instance.items.Add(packageLocalItem);
        }

        // 保存测试数据
        PackageLocalData.Instance.SavePackage();
    }

    // 用于在编辑器中创建一个 "读取背包测试数据" 的菜单项
    [MenuItem("CMCmd/读取背包测试数据")]
    public static void ReadLocalPackageData()
    {
        // 读取 PackageLocalData 中的背包测试数据
        List<PackageLocalItem> readItems = PackageLocalData.Instance.LoadPackage();

        // 遍历读取到的数据并输出信息
        foreach (PackageLocalItem item in readItems)
        {
            Debug.Log(item);
        }
    }

    // 用于在编辑器中创建一个 "打开背包主界面" 的菜单项
    [MenuItem("CMCmd/打开背包主界面")]
    public static void OpenPackagePanel()
    {
        // 使用 UIManager 打开背包主界面
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);
    }
}
