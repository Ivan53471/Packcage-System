using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PackagePanel 类继承自 BasePanel，负责管理背包界面的显示和交互逻辑
public class PackagePanel : BasePanel
{
    // UI元素的引用
    private Transform UIMenu;
    private Transform UIMenuWeapon;
    private Transform UIMenuFood;
    private Transform UITabName;
    private Transform UICloseBtn;
    private Transform UICenter;
    private Transform UIScrollView;
    private Transform UIDetailPanel;
    private Transform UILeftBtn;
    private Transform UIRightBtn;
    private Transform UIDeletePanel;
    private Transform UIDeleteBackBtn;
    private Transform UIDeleteInfoText;
    private Transform UIDeleteConfirmBtn;
    private Transform UIBottomMenus;
    private Transform UIDeleteBtn;
    private Transform UIDetailBtn;

    // PackageUIItemPrefab 是用于实例化背包物品项的预制体
    public GameObject PackageUIItemPrefab;

    // 在 Awake 方法中初始化 UI 元素
    override protected void Awake()
    {
        base.Awake();
        InitUI();
    }

    // 在 Start 方法中刷新 UI
    private void Start()
    {
        RefreshUI();
    }

    // 初始化 UI 元素
    private void InitUI()
    {
        InitUIName();
        InitClick();
    }

    // 刷新整个 UI
    private void RefreshUI()
    {
        RefreshScroll();
    }

    // 刷新滚动区域
    private void RefreshScroll()
    {
        // 清理滚动容器中原本的物品
        RectTransform scrollContent = UIScrollView.GetComponent<ScrollRect>().content;
        for (int i = 0; i < scrollContent.childCount; i++)
        {
            Destroy(scrollContent.GetChild(i).gameObject);
        }

        // 遍历排序后的背包数据，实例化并刷新每个 PackageUIItem
        foreach (PackageLocalItem localData in GameManager.Instance.GetSortPackageLocalData())
        {
            Transform PackageUIItem = Instantiate(PackageUIItemPrefab.transform, scrollContent) as Transform;
            PackageCell packageCell = PackageUIItem.GetComponent<PackageCell>();
            Debug.Log(packageCell);
            packageCell.Refresh(localData, this);
        }
    }

    // 初始化 UI 元素的名称
    private void InitUIName()
    {
        UIMenu = transform.Find("TopCenter/Menu");
        UIMenuWeapon = transform.Find("TopCenter/Menus/Weapon");
        UIMenuFood = transform.Find("TopCenter/Menus/Food");
        UITabName = transform.Find("LeftTop/TabName");
        UICloseBtn = transform.Find("RightTop/Close");
        UICenter = transform.Find("Center");
        UIScrollView = transform.Find("Center/Scroll View");
        UIDetailPanel = transform.Find("Center/DetailPanel");
        UILeftBtn = transform.Find("Left/Button");
        UIRightBtn = transform.Find("Right/Button");

        UIDeletePanel = transform.Find("Bottom/DeletePanel");
        UIDeleteBackBtn = transform.Find("Bottom/DeletePanel/Back");
        UIDeleteInfoText = transform.Find("Bottom/DeletePanel/InfoText");
        UIDeleteConfirmBtn = transform.Find("Bottom/DeletePanel/ConfirmBtn");
        UIBottomMenus = transform.Find("Bottom/BottomMenus");
        UIDeleteBtn = transform.Find("Bottom/BottomMenus/DeleteBtn");
        UIDetailBtn = transform.Find("Bottom/BottomMenus/DetailBtn");

        // 初始化删除面板为隐藏状态
        UIDeletePanel.gameObject.SetActive(false);
        // 初始化底部菜单为显示状态
        UIBottomMenus.gameObject.SetActive(true);
    }

    // 初始化按钮的点击事件
    private void InitClick()
    {
        UIMenuWeapon.GetComponent<Button>().onClick.AddListener(OnClickWeapon);
        UIMenuFood.GetComponent<Button>().onClick.AddListener(OnClickFood);
        UICloseBtn.GetComponent<Button>().onClick.AddListener(OnClickClose);
        UILeftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
        UIRightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);

        UIDeleteBackBtn.GetComponent<Button>().onClick.AddListener(OnDeleteBack);
        UIDeleteConfirmBtn.GetComponent<Button>().onClick.AddListener(OnDeleteConfirm);
        UIDeleteBtn.GetComponent<Button>().onClick.AddListener(OnDelete);
        UIDetailBtn.GetComponent<Button>().onClick.AddListener(OnDetail);
    }

    // 按钮点击事件
    private void OnClickWeapon()
    {
        print("OnClickWeapon");
    }

    private void OnClickFood()
    {
        print("OnClickFood");
    }

    private void OnClickClose()
    {
        print("OnClickClose");
        ClosePanel();
    }

    private void OnClickLeft()
    {
        print("OnClickLeft");
    }

    private void OnClickRight()
    {
        print("OnClickRight");
    }

    private void OnDeleteBack()
    {
        print("OnDeleteBack");
    }

    private void OnDeleteConfirm()
    {
        print("OnDeleteConfirm");
    }

    private void OnDelete()
    {
        print("OnDelete");
    }

    private void OnDetail()
    {
        print("OnDetail");
    }
}
