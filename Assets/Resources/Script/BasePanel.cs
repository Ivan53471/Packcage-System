using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BasePanel �������� UI ���Ļ��࣬�ṩ�˻�������������
public class BasePanel : MonoBehaviour
{
    // �Ƿ��Ѿ����Ϊ�Ƴ�
    protected bool isRemove = false;

    // ��������
    protected new string name;

    // ����屻ʵ����ʱ���õ��鷽��
    protected virtual void Awake()
    {
        // ���������ӳ�ʼ���߼�
    }

    // �������ļ���״̬
    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    // ����岢������������
    public virtual void OpenPanel(string name)
    {
        this.name = name;
        SetActive(true);
    }

    // �ر���壬������Ҫʱ�����Ƴ�
    public virtual void ClosePanel()
    {
        // ���Ϊ�Ƴ�
        isRemove = true;

        // ������岻����
        SetActive(false);

        // �������� GameObject
        Destroy(gameObject);

        // �� UIManager ������ֵ����Ƴ���Ӧ�ļ�¼
        if (UIManager.Instance.panelDict.ContainsKey(name))
        {
            UIManager.Instance.panelDict.Remove(name);
        }
    }
}
