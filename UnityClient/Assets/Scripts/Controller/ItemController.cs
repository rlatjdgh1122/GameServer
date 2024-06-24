using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemController : CreatureController
{
    protected override void Init()
    {
    State = CreatureState.Moving;
    base.Init();
    }

    protected override void UpdateAnimation()
    {
        // 추후 기능 추가
    }
    

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveItem(other.gameObject);

        }//end if
    }
    protected void ActiveItem(GameObject player)
    {
        MyPlayerController mc = player.GetComponent<MyPlayerController>();
        mc.IsMove = false;

        // 추후 기능 추가
        C_ItemGet c_ItemGet = new C_ItemGet() //서버한테
        {
            Iteminfo = new ItemInfo()
        };

        c_ItemGet.Iteminfo.ItemId = Id;
        c_ItemGet.Iteminfo.Name = "Coin";
        c_ItemGet.Iteminfo.PosInfo = PosInfo;
        c_ItemGet.PlayerObjectId = mc.Id;

        Managers.Network.Send(c_ItemGet);
        Debug.Log($"Creature {mc.Id} Item Get");

    }

}



