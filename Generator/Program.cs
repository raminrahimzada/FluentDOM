﻿namespace Generator
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dir = @"C:\PROJECTS\FluentDOM\SampleProject\AutoGenerated\";
            CodeGenerator.Generate_ExampleSource(dir+ "ExampleSource.cs");
        }
    }
}