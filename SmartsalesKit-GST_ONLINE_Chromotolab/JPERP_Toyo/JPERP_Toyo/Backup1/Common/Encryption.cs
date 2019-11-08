using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace Account.Common
{
    class Encryption
    {
        #region "Private Fields ..."

        private static string mConstr;
        private static string mConstrBackUP;
        private static string mConstrMaster;

        #endregion

        #region "Public Properties ..."


        public static string Constr
        {
            get
            { return mConstr; }
            set
            { mConstr = value; }
        }
        public static string ConstrBackUP
        {
            get
            { return mConstrBackUP; }
            set
            { mConstrBackUP = value; }
        }

        public static string ConstrMaster
        {
            get
            { return mConstrMaster; }
            set
            { mConstrMaster = value; }
        }


        #endregion

        #region "Public methods ..."

        public void Decrypt()
        {
            string Con = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string test = "";
            int MainLength = Main.Length;
            int SubIndex;
            string ch;
            if (Con.Trim() != "")
            {
                foreach (char c in Con.Trim().ToString())
                {
                    SubIndex = Main.IndexOf(c) - 11 + 2;

                    if (SubIndex < 0)
                    {
                        ch = Main.Substring(SubIndex + MainLength, 1);
                    }
                    else
                    {

                        {
                            ch = Main.Substring(SubIndex, 1);
                        }
                    }
                    test = test + ch;

                }
                Constr = test;
            }
        }
        public void DecryptBackUP()
        {
            string Con = ConfigurationManager.ConnectionStrings["DBConnectionString_Backup"].ConnectionString;
            string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string test = "";
            int MainLength = Main.Length;
            int SubIndex;
            string ch;
            if (Con.Trim() != "")
            {
                foreach (char c in Con.Trim().ToString())
                {
                    SubIndex = Main.IndexOf(c) - 11 + 2;

                    if (SubIndex < 0)
                    {
                        ch = Main.Substring(SubIndex + MainLength, 1);
                    }
                    else
                    {

                        {
                            ch = Main.Substring(SubIndex, 1);
                        }
                    }
                    test = test + ch;

                }
                ConstrBackUP = test;
            }
        }

        public void DecryptMaster()
        {
            string Con = ConfigurationManager.ConnectionStrings["Master_DBConnectionString"].ConnectionString;
            string Main = @"abcdefghijklmnopqrstuvwxyz!@#$%^*()\;-=_ 1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string test = "";
            int MainLength = Main.Length;
            int SubIndex;
            string ch;
            if (Con.Trim() != "")
            {
                foreach (char c in Con.Trim().ToString())
                {
                    SubIndex = Main.IndexOf(c) - 11 + 2;

                    if (SubIndex < 0)
                    {
                        ch = Main.Substring(SubIndex + MainLength, 1);
                    }
                    else
                    {

                        {
                            ch = Main.Substring(SubIndex, 1);
                        }
                    }
                    test = test + ch;

                }
                ConstrMaster = test;
            }
        }
        #endregion
    }
}
