using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;
using System;
using System.Diagnostics;
using System.Drawing;

namespace PasswordGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Generate(PasswordGen password)
        {

            password.Size = password.Size != null ? password.Size < 7 ? 7 : password.Size : 7;
            int Size = password.Size.Value;

            Random random = new Random();
            PasswordGen Pass = new PasswordGen();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789!@#$%&*()Ç[](){}-+/,.~^º£¢Ç|\\";

            string passwordInCaps = new string(Enumerable.Repeat(chars, Size).Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();

            var scrambleCaps = passwordInCaps.Select(x => random.Next() % 2 == 0 ? (char.IsUpper(x) ? x.ToString().ToLower().First() : x.ToString().ToUpper().First()) : x);
            var resultScrambleCaps = new string(scrambleCaps.ToArray());

            Pass.Password = !string.IsNullOrEmpty(resultScrambleCaps) ? resultScrambleCaps.ToString() : "";
            Pass.Size = Size;

            return View("Index", Pass);
        }
    }
}