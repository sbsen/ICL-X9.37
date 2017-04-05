//INSTANT C# NOTE: Formerly VB.NET project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace MTS.ICLViewer
{
    public class x9Rec
    {
        private string _recType;
        private string _recData;
        private string _recImage;

        public x9Rec()
        {

        }

        public x9Rec(string recType, string recData, string recImage)
        {
            _recType = recType;
            _recData = recData;
            _recImage = recImage;
        }
        public string recType
        {
            get
            {
                return _recType;
            }
            set
            {
                _recType = value;
            }
        }

        public string recData
        {
            get
            {
                return _recData;
            }
            set
            {
                _recData = value;
            }
        }

        public string recImage
        {
            get
            {
                return _recImage;
            }
            set
            {
                _recImage = value;
            }
        }

    }

    public class x9Recs : System.Collections.CollectionBase
    {
        public int Add(x9Rec newX9Rec)
        {
            return List.Add(newX9Rec);
        }

        public void Remove(int index = -1)
        {
            if (index == -1)
            {
                index = List.Count - 1;
            }
            if (index >= 0 && index < List.Count)
            {
                List.RemoveAt(index);
            }
        }
        public x9Rec this[int index]
        {
            get
            {
                return (x9Rec)(List[index]);
            }
        }
    }

} //end of root namespace