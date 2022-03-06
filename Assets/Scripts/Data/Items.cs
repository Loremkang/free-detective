using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// Copy the indicated entries from an array into a new array.
public class Item {
    public Item (string name_, string des_, string type_, Item father_, int level_) {
        name = name_;
        description = des_;
        type = type_;
        fatherItem = father_;
        level = level_;
        prerequisite = new ArrayList();
        substitution = new ArrayList();
        position = new ArrayList();
        subItems = new Dictionary<string, Item>();
        gameObject = new Dictionary<GameObject, GameObject>();
        sceneObject = new Dictionary<int, GameObject>();
    }
    public int level;
    public string name;
    public string description;
    public string type;
    public ArrayList prerequisite = new ArrayList();
    public ArrayList substitution = new ArrayList();
    public ArrayList position = new ArrayList();
    public Dictionary<string, Item> subItems = new Dictionary<string, Item>();
    public Item fatherItem = null;

    // public GameObject gameObject;
    public Dictionary<GameObject, GameObject> gameObject = new Dictionary<GameObject, GameObject>();
    public Dictionary<int, GameObject> sceneObject = new Dictionary<int, GameObject>(); // active only for scene item

    public bool isChild(Item item) {
        Item curItem = this;
        while (curItem != null) {
            if (curItem == item) {
                return true;
            } else {
                curItem = curItem.fatherItem;
            }
        }
        return false;
    }

    // Copy the indicated entries from an array into a new array.
    public void buildArrayLists(ArrayList arrayList, string[] strList) {
        try {
            for (int i = 0; i < strList.Length; i ++) {
                if (strList[i].Length > 0) {
                    arrayList.Add(strList[i]);
                }
            }
        } catch (Exception e) {
            Debug.Log("ERROR!");
            Debug.Log(arrayList.Count);
            Debug.Log(strList.Length);
            Debug.Log(name);
            Debug.Log(description);
            Debug.Log(type);
            for (int i = 0; i < strList.Length; i ++) {
                Debug.Log(strList[i]);
            }
            Debug.Log(e.ToString());
        }
    }

    public Boolean addItem(string name_, string des_, string type_, string[] prerequisite_, string[] substitution_, string[] position_) {
        // Console.WriteLine(position_.ToString() + position_.Length.ToString() + position_[0]);
        // if (position_.Length > 0 && position_[0].Length != 0) {
        //     if (!subItems.ContainsKey(position_[0])) {
        //         // Console.WriteLine("Warning: Wrong order on item " + name_);
        //         return false;
        //     }
        //     return subItems[position_[0]].addItem(name_, des_, type_, prerequisite_, substitution_, position_.SubArray(1, position_.Length - 1));
        // }
        Item subItem = new Item(name_, des_, type_, this, this.level);
        buildArrayLists(subItem.prerequisite, prerequisite_);
        buildArrayLists(subItem.substitution, substitution_);
        buildArrayLists(subItem.position, position_);
        // subItem.prerequisite = prerequisite_;
        // subItem.substitution = substitution_;
        // subItem.position = position_;
        // subItems[name_] = subItem;
        Data.globalItemMap[this.level][name_] = subItem;
        Console.WriteLine("Load New Item : " + name_);
        return true;
    }
    public Boolean rawAddItem(string[] row) {
        // Console.WriteLine(row.Length);
        return addItem(row[0], row[1], row[2], row.SubArray(3, 5), row.SubArray(8, 5), row.SubArray(13, 5));
    }
    // public void substituteOthers() {
    //     foreach(string str in substitution) {
    //         Item item = Data.globalItemMap[this.level][str];
    //         if (item != null) {
    //             Data.substituted[level].Add(item);
    //             Data.obtainedItem[level].Remove(item);
    //         }
    //     }
    // }
    // public void tryHiddingThis() {
    //     foreach(string str in prerequisite) {
    //         if (str == null || !Data.globalItemMap[this.level].ContainsKey(str)) {
    //             continue;
    //         }
    //         Data.hidden[level].Add(this);
    //     }
    // }
    // public Boolean inferenceThis(ArrayList evidence) {
    //     if (prerequisite.Count == 0 || prerequisite.Count != evidence.Count) {
    //         return false;
    //     }
    //     // Console.ForegroundColor = ConsoleColor.Red;
    //     // foreach (string str in evidence) {
    //     //     Console.Write(str + " ");
    //     // } Console.WriteLine();
    //     // foreach (string str in prerequisite) {
    //     //     Console.Write(str + " ");
    //     // } Console.WriteLine("\n");
    //     // Console.ForegroundColor = ConsoleColor.White;

    //     prerequisite.Sort();
    //     evidence.Sort();
    //     for (int i = 0; i < prerequisite.Count; i ++) {
    //         // Console.WriteLine(evidence[i]);
    //         // Console.WriteLine(prerequisite[i]);
    //         if (!evidence[i].Equals(prerequisite[i])) {
    //             return false;
    //         }
    //     }
    //     return true;
    // }
    // public bool discoverThis() {
    //     bool found = Data.obtainedItem[level].Contains(this);
    //     if (!found) {
    //         Data.obtainedItem[level].Add(this);
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    // public string[] getPosChain() {
    //     List<string> ret = new List<string>();
    //     for (Item itemPointer = this; itemPointer != null; itemPointer = itemPointer.fatherItem) {
    //         ret.Insert(0, itemPointer.name);
    //     }
    //     return ret.ToArray();
    // }
};