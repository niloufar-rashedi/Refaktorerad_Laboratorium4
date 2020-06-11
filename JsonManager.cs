﻿using Laboratorium4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorium4
{
    public class JsonManager
    {
        public void Run()
        {
            HelperClass helperC = new HelperClass();
            var path = GetUserHomePath();
            var programPath = Path.Combine(path, "Lab4");
            var jsonPath = Path.Combine(programPath, "Products.json");

            //Copying Josh's initial RunProgram() if-condition
            if (!File.Exists(programPath))
            {
                File.Create(programPath);
            }

            SaveToJson(jsonPath, helperC.products);

            var records = LoadFromJson<Product>(jsonPath);

            foreach (var p in records)
            {
                Console.WriteLine(p.ProductName);
            }

        }
        public string GetUserHomePath()
        {
            return
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
                    Environment.SpecialFolderOption.DoNotVerify);
        }
        //public static void RunProgram()
        //{
        //    if (!File.Exists(HelperClass().Run().programPath))
        //    {
        //        File.Create(programPath);
        //    }
        //}
        public static void ProgramStart()
        {
            if (!Directory.Exists())
            {
                Directory.CreateDirectory(Json.programPath);
            }

            UI.MainMenuInterface();
        }
        public IEnumerable<T> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var records = System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonString);
            return records;
        }

        public void SaveToJson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }

    }
}
