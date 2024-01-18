using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PackageTable ����һ�� ScriptableObject�����ڴ洢��Ϸ�еİ�����Ϣ
[CreateAssetMenu(menuName = "My/PackageTable", fileName = "PackageTable")]
public class PackageTable : ScriptableObject
{
    // DataList ���ڴ洢 PackageTableItem ������б�
    public List<PackageTableItem> DataList = new List<PackageTableItem>();
}

// PackageTableItem ���� PackageTable �д洢��ÿ������������ݽṹ
[System.Serializable]
public class PackageTableItem
{
    // ��Ʒ��Ψһ��ʶ��
    public int id;
    // ��Ʒ������
    public int type;
    // ��Ʒ�ĵȼ�
    public int level;
    // ��Ʒ���Ǽ�
    public int star;
    // ��Ʒ������
    public string name;
    // ��Ʒ������
    public string description;
    // ��Ʒ���ܵ�����
    public string skillDescription;
    // ��Ʒ��ͼƬ·��
    public string imagePath;
}
