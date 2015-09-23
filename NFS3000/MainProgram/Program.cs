﻿using System;
using Services.Services.Objects.Singletons;
namespace MainGameLauncher
{
    public class MainProgram
    {
        public static UI UISingleton;
        static void Main(string[] args)
        {
            UISingleton..Draw();
            Console.ReadKey();
        }
    }
}