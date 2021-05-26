// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.iOS.Xcode;

namespace CandyCoded
{

    public static class CustomBuildToolExtensions
    {

        public static string PlistFileName = "Info.plist";

        public static string GetPlistDocumentPath(this BuildReport report)
        {

            return Path.Combine(report.summary.outputPath, PlistFileName);

        }

        public static PlistDocument GetPlistDocument(this BuildReport report)
        {

            if (!report.summary.platform.Equals(BuildTarget.iOS))
            {
                return null;
            }

            var plistPath = report.GetPlistDocumentPath();

            var plist = new PlistDocument();

            plist.ReadFromFile(plistPath);

            return plist;

        }

        public static void SavePlistDocument(this BuildReport report, PlistDocument plistDocument)
        {

            if (!report.summary.platform.Equals(BuildTarget.iOS))
            {
                return;
            }

            var plistPath = report.GetPlistDocumentPath();

            plistDocument.WriteToFile(plistPath);

        }

        public static void PlistSetBoolean(this BuildReport report, string key, bool value)
        {

            if (!report.summary.platform.Equals(BuildTarget.iOS))
            {
                return;
            }

            var plist = report.GetPlistDocument();

            plist.root.SetBoolean(key, value);

            report.SavePlistDocument(plist);

        }

        public static void PlistSetInteger(this BuildReport report, string key, int value)
        {

            if (!report.summary.platform.Equals(BuildTarget.iOS))
            {
                return;
            }

            var plist = report.GetPlistDocument();

            plist.root.SetInteger(key, value);

            report.SavePlistDocument(plist);

        }

        public static void PlistSetString(this BuildReport report, string key, string value)
        {

            if (!report.summary.platform.Equals(BuildTarget.iOS))
            {
                return;
            }

            var plist = report.GetPlistDocument();

            plist.root.SetString(key, value);

            report.SavePlistDocument(plist);

        }

    }

}
#endif
