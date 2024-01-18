using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PackageCell 类用于管理背包界面中的每个物品项
public class PackageCell : MonoBehaviour
{
    // UI元素的引用
    private Transform UIIcon;
    private Transform UIHead;
    private Transform UINew;
    private Transform UISelect;
    private Transform UILevel;
    private Transform UIStars;
    private Transform UIDeleteSelect;

    // 包裹本地数据、包裹表数据和 UI 父类的引用
    private PackageLocalItem packageLocalData;
    private PackageTableItem packageTableItem;
    private PackagePanel uiParent;

    // 在 Awake 方法中初始化 UI 元素
    private void Awake()
    {
        InitUIName();
    }

    // 初始化 UI 元素的名称
    private void InitUIName()
    {
        UIIcon = transform.Find("Top/icon");
        UIHead = transform.Find("Top/Head");
        UINew = transform.Find("Top/New");
        UILevel = transform.Find("Bottom/LevelText");
        UIStars = transform.Find("Bottom/Stars");
        UISelect = transform.Find("Select");
        UIDeleteSelect = transform.Find("DeleteSelect");

        // 初始化删除选中状态为隐藏状态
        UIDeleteSelect.gameObject.SetActive(false);
    }

    // 刷新 PackageCell 的显示内容
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // 数据初始化
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;

        // 等级信息
        UILevel.GetComponent<Text>().text = "Lv." + this.packageLocalData.level.ToString();
        // 是否是新获得
        UINew.gameObject.SetActive(this.packageLocalData.isNew);
        // 物品的图片
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIIcon.GetComponent<Image>().sprite = temp;

        // 刷新星级
        RefreshStars();
    }

    // 刷新星级显示
    public void RefreshStars()
    {
        for (int i = 0; i < UIStars.childCount; i++)
        {
            Transform star = UIStars.GetChild(i);
            if (this.packageTableItem.star > i)
            {
                star.gameObject.SetActive(true);
            }
            else
            {
                star.gameObject.SetActive(false);
            }
        }
    }
}
