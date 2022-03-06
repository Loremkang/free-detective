using System;
using UnityEngine;
using System.IO;

// init before read
// init will read (and ignore) the first line to get format

class CsvParser {
    public CsvParser(StreamReader reader_) {
        reader = reader_;
    }
    public void init() {
        string str = reader.ReadLine();
        columnCount = str.Split(',').Length;
    }
    public bool readChar(out char ch) {
        int tmp = reader.Read();
        if (tmp < 0) {
            ch = ' ';
            return false;
        } else {
            ch = Convert.ToChar(tmp);
            // Debug.Log(ch);
            return true;
        }
    }
    public string[] Read() {
        int fillingPosition = 0;
        string[] ret = new string[columnCount];
        bool inQuotation = false;
        char ch;
        if (!readChar(out ch)) {
            return null;
        }
        string tmp = "";
        while (true) {
            if (ch == '\n') {
                if (!inQuotation) {
                    ret[fillingPosition ++] = tmp;
                    return ret;
                } else {
                    tmp = tmp + ch;
                }
                // ch = Convert.ToChar(reader.Read());
                if (!readChar(out ch)) { ch = '\n'; }
            } else if (ch == ',') {
                if (!inQuotation) {
                    ret[fillingPosition ++] = tmp;
                    tmp = "";
                } else {
                    tmp = tmp + ch;
                }
                // ch = Convert.ToChar(reader.Read());
                if (!readChar(out ch)) { ch = '\n'; }
            } else if (ch == '"') {
                // ch = Convert.ToChar(reader.Read());
                if (!readChar(out ch)) { ch = '\n'; }
                if (!inQuotation) {
                    inQuotation = true;
                } else {
                    if (ch == '"') {
                        tmp = tmp + ch;
                        // ch = Convert.ToChar(reader.Read());
                        if (!readChar(out ch)) { ch = '\n'; }
                    } else {
                        inQuotation = false;
                    }
                }
            } else {
                tmp = tmp + ch;
                // ch = Convert.ToChar(reader.Read());
                if (!readChar(out ch)) { ch = '\n'; }
            }
        }
        return ret;
    }
    private StreamReader reader;
    public int columnCount;
}