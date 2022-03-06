using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deduction
{
    public string name;
    public string description;
    public int level;
    public ArrayList requirements = new ArrayList();

    public Deduction(string[] row, int level_) {
        name = row[0];
        description = row[1];
        requirements.Add(row.SubArray(3, 5));
        level = level_;
    }

    public void merge(Deduction deduction) {
        foreach (string[] requirementList in deduction.requirements) {
            requirements.Add(requirementList);
        }
    }

    public bool CheckDeduction(string[] info) {
        HashSet<string> gotInfo = new HashSet<string>(info);
        foreach (string[] requirementList in requirements) {
            bool succeed = true;
            foreach (string requirement in requirementList) {
                if (requirement == null || requirement.Length == 0) {
                    continue;
                }
                if (!gotInfo.Contains(requirement)) {
                    if (name == "推论2") {
                        Debug.Log(requirement + "***");
                    }
                    succeed = false;
                    break;
                }
            }
            if (succeed) {
                return true;
            }
        }
        return false;
    }

    public string tostr() {
        string ret = "";
        ret += name + "  ";
        foreach (string[] strs in requirements) {
            foreach (string str in strs) {
                ret += str + " ";
            }
            ret += "  ";
        }
        return ret;
    }
}
