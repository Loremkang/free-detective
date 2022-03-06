// using CsvHelper;
using System;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Globalization;

class Reader {
    
    public void readItem(string fileURL, Item rootItem) {
        ArrayList[] unfinishedInput = new ArrayList[2];
        unfinishedInput[0] = new ArrayList();
        unfinishedInput[1] = new ArrayList();
        using (var reader = new StreamReader(fileURL)) {
            var csvParser = new CsvParser(reader);
            csvParser.init();
            // var row = csvParser.Read(); // Ignore Table Head
            string[] row;
            while (true) {
                row = csvParser.Read();
                if (row == null) break;
                if (row[0].Length == 0) continue;
                if (!rootItem.rawAddItem(row))
                {
                    unfinishedInput[0].Add(row);
                    string ret = "";
                    for (int i = 0; i < row.Length; i ++) {
                        ret += " " + i.ToString() + row[i] + " ";
                    }
                    // Debug.Log(ret + row.Length.ToString());
                }
            }
        }
        Debug.Log(unfinishedInput[0].Count);
        return;
        // for (int i = 0; unfinishedInput[i].Count != 0; i ^= 1) {
        //     unfinishedInput[i ^ 1].Clear();
        //     foreach (string[] row in unfinishedInput[i]) {
        //         if (!rootItem.rawAddItem(row)) {
        //             unfinishedInput[i ^ 1].Add(row);
        //         }
        //     }
        // }
    }

    public void readEvidence(string fileURL, int level) {
        using (var reader = new StreamReader(fileURL)) {
            var csvParser = new CsvParser(reader);
            csvParser.init();
            // var row = csvParser.Read(); // Ignore Table Head
            string[] row;
            while (true) {
                row = csvParser.Read();
                if (row == null) break;
                if (row[0].Length == 0) continue;
                Evidence evidence = new Evidence(row, level);
                Data.globalEvidenceMap[level][evidence.name] = evidence;
            }
        }
    }

    public void readDeduction(string fileURL, int level) {
        using (var reader = new StreamReader(fileURL)) {
            var csvParser = new CsvParser(reader);
            csvParser.init();
            // var row = csvParser.Read(); // Ignore Table Head
            string[] row;
            while (true) {
                row = csvParser.Read();
                if (row == null) break;
                if (row[0].Length == 0) continue;
                Deduction deduction = new Deduction(row, level);
                if (Data.globalDeductionMap[level].ContainsKey(deduction.name)) {
                    Data.globalDeductionMap[level][deduction.name].merge(deduction);
                } else {
                    Data.globalDeductionMap[level][deduction.name] = deduction;
                }
            }
        }
    }
}