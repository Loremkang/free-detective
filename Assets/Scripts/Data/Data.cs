using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Const {
    public const float longClickTime = 0.3f;
    public const float cameraMoveTime = 0.1f;

    public const int levels = 3;
}

public static class Data {
    public const int levels = 1;
    public static Dictionary<string, Item>[] globalItemMap = new Dictionary<string, Item>[levels];
    public static ArrayList[] hidden = new ArrayList[levels];
    public static ArrayList[] substituted = new ArrayList[levels];
    // public static ArrayList[] obtainedItem = new ArrayList[levels];
    public static HashSet<string>[] obtainedEvidence = new HashSet<string>[levels];
    public static Dictionary<string, Evidence>[] globalEvidenceMap = new Dictionary<string, Evidence>[levels];
    public static HashSet<string>[] obtainedDeduction = new HashSet<string>[levels];
    public static Dictionary<string, Deduction>[] globalDeductionMap = new Dictionary<string, Deduction>[levels];
    // public static Item curPos;
    public static int curLevel;
    public static Boolean gameFinished = false;
    public static DiscoveryController discoveryController;
    public static CameraController cameraController;
    public static UIData uiData;



    public static void Init() {
        for (int i = 0; i < levels; i ++) {
            globalItemMap[i] = new Dictionary<string, Item>();
            globalEvidenceMap[i] = new Dictionary<string, Evidence>();
            globalDeductionMap[i] = new Dictionary<string, Deduction>();
            // hidden[i] = new ArrayList();
            // substituted[i] = new ArrayList();
            // obtainedItem[i] = new ArrayList();
            obtainedEvidence[i] = new HashSet<string>();
            obtainedDeduction[i] = new HashSet<string>();
            string levelName = "EP" + (i + 1).ToString();
            Item EP = new Item(levelName, levelName + "Description", "关卡", null, i);
            Data.globalItemMap[i][levelName] = EP;
            Reader reader = new Reader();
            // reader.readItem("./Assets/Stories/" + levelName + "/" + levelName + ".evidence.csv", EP);
            reader.readItem("./Assets/Stories/evidences/EP" + (i + 1).ToString() + ".evidences.csv", EP);
            reader.readEvidence("./Assets/Stories/cards/EP" + (i + 1).ToString() + ".cards.csv", i);
            reader.readDeduction("./Assets/Stories/deductions/EP" + (i + 1).ToString() + ".deductions.csv", i);
        }
        // for (int i = 0; i < levels; i ++) {
        //     foreach(string key in Data.globalItemMap[i].Keys) {
        //         Data.globalItemMap[i][key].tryHiddingThis();
        //     }
        // }
        // EnterLevel(0);
    }
    // public static void EnterLevel(int level) {
    //     curLevel = level;
    //     Data.curPos = Data.globalItemMap[level]["EP" + (level + 1).ToString()];
    //     Data.obtainedItem[level].Add(Data.curPos);
    // }
}