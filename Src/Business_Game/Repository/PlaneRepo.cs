using System;
using System.Collections.Generic;
using Raylib_cs;

public class PlaneRepo {

    Dictionary<int, PlaneEntity> all;

    PlaneEntity[] tempArray; // 临时

    public PlaneRepo() {
        all = new Dictionary<int, PlaneEntity>();
        tempArray = new PlaneEntity[1000]; // 空
    }

    public void Add(PlaneEntity plane) {
        all.Add(plane.entityID, plane);
    }

    public bool TryGet(int entityID, out PlaneEntity plane) {
        return all.TryGetValue(entityID, out plane);
    }

    public void Remove(PlaneEntity plane) {
        all.Remove(plane.entityID);
    }

    // 基于Dictionary的缺陷
    public int TakeAll(out PlaneEntity[] result) {
        if (tempArray.Length < all.Count) {
            tempArray = new PlaneEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        result = tempArray;
        return all.Count; // 已有数量
    }

}