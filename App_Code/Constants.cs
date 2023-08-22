using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Constants
{
    public static string LOGIN_COOKIE = "LoginCookie";
    public static string LOGIN_USER = "LoginUser";

    public static string COMPUTER_COOKIE = "CompCookie";
    public static string COMPUTER_NAME = "Computer";

    public static string CART_COOKIE = "CartCookie";
    public static string CART_ITEMS = "CartItems";

    public enum Computer
    {
        Macbook, Lenovo, Hp, MS
    }

    public enum ComponentType
    {
        Computer, Display,Drive,Ram, Cpu, Os
    }

    public static List<CartItem> CartItems = new List<CartItem>();
    public static List<CartItem> Part4CartItems = new List<CartItem>();


    public static Dictionary<Computer, double> ComputerPrices = new Dictionary<Computer, double>
    {
        {Computer.Macbook, 700},
        {Computer.Lenovo, 550},
        {Computer.Hp, 500},
        {Computer.MS, 500}
    };

    public static Dictionary<Computer, string> ComputerImages = new Dictionary<Computer, string>
    {
        {Computer.Macbook,"../images//part3_4//macbook.png"},
        {Computer.Lenovo,"..//images/part3_4//lenovo.png"},
        {Computer.Hp,"..//images//part3_4//hp.png"},
        {Computer.MS,"..//images//part3_4//microsoft-surface.jpg"}
    };

    public static Dictionary<Computer, string> ComputerDisplayName = new Dictionary<Computer, string>
    {
        {Computer.Macbook,"Macbook Pro"},
        {Computer.Lenovo,"Lenovo"},
        {Computer.Hp,"HP Notebook"},
        {Computer.MS,"Microsoft Surface"}
    };
};