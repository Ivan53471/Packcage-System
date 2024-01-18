using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PackageTable 类是一个 ScriptableObject，用于存储游戏中的包裹信息
[CreateAssetMenu(menuName = "My/PackageTable", fileName = "PackageTable")]
public class PackageTable : ScriptableObject
{
    // DataList 用于存储 PackageTableItem 对象的列表
    public List<PackageTableItem> DataList = new List<PackageTableItem>();
}

// PackageTableItem 类是 PackageTable 中存储的每个包裹项的数据结构
[System.Serializable]
public class PackageTableItem
{
    // 物品的唯一标识符
    public int id;
    // 物品的类型
    public int type;
    // 物品的等级
    public int level;
    // 物品的星级
    public int star;
    // 物品的名称
    public string name;
    // 物品的描述
    public string description;
    // 物品技能的描述
    public string skillDescription;
    // 物品的图片路径
    public string imagePath;
}
