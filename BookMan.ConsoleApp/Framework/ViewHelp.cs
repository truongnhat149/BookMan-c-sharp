﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class ViewHelp
    {
        /// <summary>
        /// xuất thông tin ra console với màu sắc (WriteLine có màu)
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
                Console.ResetColor();
        }

        /// <summary>
        /// xuất thông tin ra console với màu sắc (Write có màu)
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
                Console.ResetColor();
        }

        /// <summary>
        /// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// rồi chuyển sang kiểu bool
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} [y/n]: ", labelColor);
            ConsoleKeyInfo key = Console.ReadKey(); //đọc 1 ký tự vào biến key
            bool @char = key.KeyChar == 'y' || key.KeyChar == 'Y' ?
                true : false; //chuyển sang kiểu bool dùng biểu thức điều kiện
            return @char; // lưu ý cách viết tên biến @char
        }

        public static bool InputBool(string label, bool oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}", labelColor);
            // sử dụng phương thức mở rộng ToString
            WriteLine(oldValue.ToString("y/n"), ConsoleColor.Yellow);
            Write("New value >>" , ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)) return oldValue;
            return str.ToBool(); // sử dụng phương thức mở rộng ToBool
        }

        /// <summary>
        /// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// rồi chuyển sang số nguyên
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static int InputInt(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            while (true)
            {
                var str = InputString(label, labelColor, valueColor);
                var result = int.TryParse(str, out int i);
                if (result == true)
                {
                    return i;
                }
            }
        }

        public static int InputInt(string label, int oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor);
            WriteLine($"{oldValue} ", ConsoleColor.Yellow);
            Write("New Value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)) return oldValue;
            if (str.ToInt(out int i)) return i;
            return oldValue;
        }

        /// <summary>
        /// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static string InputString(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor, false);
            Console.ForegroundColor = valueColor;
            string value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }

        public static string InputString(string label, string oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White) 
        {
            Write($"{label}", labelColor);
            WriteLine(oldValue, ConsoleColor.Yellow);
            Write("New Value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            return string.IsNullOrEmpty(newValue.Trim()) ? oldValue : newValue;
        } 
    }
}
