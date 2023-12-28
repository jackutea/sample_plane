using System.Collections.Generic;

public class LevelRepo {

    Dictionary<int, LevelEntity> all;

    LevelEntity[] tempArray; // 临时

    public LevelRepo() {
        all = new Dictionary<int, LevelEntity>();
        tempArray = new LevelEntity[50];
    }

    public void Add(LevelEntity wave) {
        all.Add(wave.entityID, wave);
    }

    public void Remove(LevelEntity wave) {
        all.Remove(wave.entityID);
    }

    public bool TryGet(int entityID, out LevelEntity wave) {
        return all.TryGetValue(entityID, out wave);
    }

    public int TakeAll(out LevelEntity[] result) {
        if (tempArray.Length < all.Count) {
            tempArray = new LevelEntity[all.Count * 2];
        }
        all.Values.CopyTo(tempArray, 0);
        result = tempArray;
        return all.Count; // 已有数量
    }

}