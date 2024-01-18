using UnityEngine;
using System.Collections.Generic;

// PackageLocalData �����ڹ����ر������ݵı���ͼ���
public class PackageLocalData
{
    private static PackageLocalData _instance;

    // ��ȡ PackageLocalData �ĵ���ʵ��
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

    // �����е���Ʒ�б�
    public List<PackageLocalItem> items;

    // ���������ݱ��浽 PlayerPrefs
    public void SavePackage()
    {
        // �� PackageLocalData ����ת��Ϊ JSON �ַ���
        string inventoryJson = JsonUtility.ToJson(this);

        // ���� JSON �ַ����� PlayerPrefs
        PlayerPrefs.SetString("PackageLocalData", inventoryJson);
        PlayerPrefs.Save();
    }

    // �� PlayerPrefs ���ر�������
    public List<PackageLocalItem> LoadPackage()
    {
        // ����Ѿ����ع����ݣ�ֱ�ӷ��ػ���� items �б�
        if (items != null)
        {
            return items;
        }

        // ��� PlayerPrefs �д��ڱ������ݣ����� JSON �ַ�����������Ʒ�б�
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
            // ��� PlayerPrefs �в����ڱ������ݣ�����һ���µĿ��б�����
            items = new List<PackageLocalItem>();
            return items;
        }
    }
}

// PackageLocalItem ���ʾ�����еĵ�����Ʒ�����ݽṹ
[System.Serializable]
public class PackageLocalItem
{
    // ��Ʒ��Ψһ��ʶ��
    public string uid;
    // ��Ʒ��ID
    public int id;
    // ��Ʒ������
    public int num;
    // ��Ʒ�ĵȼ�
    public int level;
    // ��Ʒ�Ƿ�Ϊ����Ʒ
    public bool isNew;
    // ��д ToString ���������������Ʒ��Ϣ���ַ�����ʾ
    public override string ToString()
    {
        return string.Format("[id]:{0} [num]:{1}", uid, num);
    }
}
