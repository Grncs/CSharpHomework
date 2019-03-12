/* 外观设计模式 */
using System;
using System.Text;
using System.IO;
public class Reader
{
    public string Read()
    {
        string s = ""; 
        Console.Write("请输入一段字符\n");
        try
        {
            s = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
        return s;
    }
}

public class Encrypter
{
    public string Encrypt(string s)
    {
        string news = "";
        char[] vs = s.ToCharArray();
        foreach(char c in vs)
        {
            news += (c % 9).ToString();
        }
        return news;
    }
}

public class Writer
{
    public void Write(string s)
    {
        Console.Write("加密结果为" + s + "\n");

    }
}

public class EncryptFacade
{
    private Reader s1 = new Reader();
    private Encrypter s2 = new Encrypter();
    private Writer s3 = new Writer();
    public void Work()
    {
        string text;
        text = s1.Read();
        text = s2.Encrypt(text);
        s3.Write(text);
    }
    public static void Main()
    {
        EncryptFacade EF = new EncryptFacade();
        EF.Work();
        return;
    }

}


