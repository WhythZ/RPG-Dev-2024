using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ʹ�ø���ɼ�
[System.Serializable]
public class InventoryStoragedItem
//�˴�����̳У����Է��֣�����������ͺ�Stat�����Ľṹ�����ƣ����Ǻ�����νbaseValue��modifiers����
//������������������Ʒ���ڵ�һ�����ӣ���ItemData�������һ����Ʒ�����ͣ�ItemObject���Ǵ�����Ʒ����Ϸ�ڵ���ʾ����ײ��صĲ���
{
    //��ʾ�����Ʒ�����Ӵ�����Ʒ��ʲô
    public ItemData itemData;
    //��ʾ�˴����ӵ���Ʒ�ѵ�����
    public int stackSize;

    public InventoryStoragedItem(ItemData _newItemData)
    //���캯������һ��ItemData��Ϊ������ӵ���Ʒ����
    {
        itemData = _newItemData;
    }

    //������������stackSize��ֵ����Stat�е�modifiers�����Ƶ��÷�
    public void AddStackSizeBy(int _num) => stackSize += _num;
    public void DecreaseStackSizeBy(int _num) => stackSize -= _num;
}