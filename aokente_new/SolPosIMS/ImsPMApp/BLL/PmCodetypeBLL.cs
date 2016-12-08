using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.PM
{
    public class codetypeBLL
    {
        public static List<pm_codetype> GetObjects()
        {
            pm_codetype o = new pm_codetype();
            List<pm_codetype> objects = ObjectData.GetObjects<pm_codetype>(o);
            return objects;
        }

        public static List<pm_codes> GetObjects(pm_codes o)
        {
            List<pm_codes> objects = ObjectData.GetObjects<pm_codes>(o);
            return objects;
        }

        public static int Updatacode(pm_codes o)
        {
            return ObjectData.UpdateObject(o);
        }

        public static pm_codes GetObject(pm_codes o)
        {
            return ObjectData.GetObject(o) as pm_codes;
        }

        public static int InsertObject(pm_codes o)
        {
            return ObjectData.InsertObject(o);
        }
    }
}
