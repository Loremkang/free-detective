using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Evidence {
    public string name;
    public string descriptionInDiscovery;
    public string descriptionInCardDetail;
    // public Item item;
    public int level;
    public Evidence(string[] row, int level_) {
        name = row[0];
        descriptionInCardDetail = row[1];
        level = level_;
        if (!Data.globalItemMap[level].ContainsKey(name)) {
            Debug.Log("Item not found: " + name);
            if (row[1] == null || row[1].Length == 0) {
                if (row[3] == null || row[3].Length == 0) {
                    descriptionInDiscovery = "";
                } else {
                    descriptionInDiscovery = row[3];
                }
            } else {
                descriptionInDiscovery = descriptionInCardDetail;
            }
            Debug.Log(descriptionInDiscovery);
        } else {
            Item item = Data.globalItemMap[level][name];
            descriptionInDiscovery = item.description;
        }
    }
}
