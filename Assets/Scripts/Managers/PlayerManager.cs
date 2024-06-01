using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ISavesManager
//这里继承的是MonoBehaviour，所以Update一直在刷新
{
    //可以通过PlayerManager.instance来访问这个对象内的成员，想引用player需要用PlayerManager.instance.player.position而不是PlayerManager.instance.position，他妈的别再搞错了！
    //这个类只能有一个对象，不然会出问题
    public static PlayerManager instance {  get; private set; }

    //可以通过PlayerManager.instance.player来从任意地方访问到player，而不需要用GameObject.Find("Player")这种方式
    //若要将这个player绑定到此Manager，需要在Unity内创建一个PlayerManager对象，将Player对象绑定到这个脚本（脚本绑定到Manager对象）的此成员变量上
    public Player player;

    //玩家持有的货币
    public int currency;

    private void Awake()
    {
        //确保只有一个instance在工作，防止出问题
        if (instance != null)
        {
            //删除这个多出来的脚本
            //Destroy(instance);
            //直接删掉这个多余脚本所在的对象
            Destroy(instance.gameObject);
            Debug.Log("Invalid GameObject Containing PlayerManager's Instance DESTROYED");
        }
        else
            instance = this;
    }

    //读取玩家持有的货币数量
    public int GetCurrency() => currency;

    #region ISavesManager
    public void LoadData(GameData _data)
    //加载游戏时候执行的操作
    {
        //读取货币数量
        this.currency = _data.currency;
    }

    public void SaveData(ref GameData _data)
    {
        //存储货币数量
        _data.currency = this.currency;
    }
    #endregion
}