using System;
using System.IO;

namespace AutomationTest.Framework
{
    public static class Settings
    {
        public const string Url = "http://automationpractice.com/index.php";
        public const string Email = "set@selenium.test";
        public const string Password = "shmal";
        private static readonly string UserRoot = Environment.GetEnvironmentVariable("USERPROFILE");
        public static readonly string DownloadFolder = Path.Combine(UserRoot, "Downloads");
    }
}