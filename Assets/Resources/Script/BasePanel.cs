using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BasePanel 类是所有 UI 面板的基类，提供了基本的面板管理功能
public class BasePanel : MonoBehaviour
{
    // 是否已经标记为移除
    protected bool isRemove = false;

    // 面板的名称
    protected new string name;

    // 在面板被实例化时调用的虚方法
    protected virtual void Awake()
    {
        // 这里可以添加初始化逻辑
    }

    // 设置面板的激活状态
    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    // 打开面板并设置面板的名称
    public virtual void OpenPanel(string name)
    {
        this.name = name;
        SetActive(true);
    }

    // 关闭面板，并在需要时进行移除
    public virtual void ClosePanel()
    {
        // 标记为移除
        isRemove = true;

        // 设置面板不激活
        SetActive(false);

        // 销毁面板的 GameObject
        Destroy(gameObject);

        // 从 UIManager 的面板字典中移除对应的记录
        if (UIManager.Instance.panelDict.ContainsKey(name))
        {
            UIManager.Instance.panelDict.Remove(name);
        }
    }
}
