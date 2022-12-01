using System;

public class Rez
{

    private string GetRandomKey(int k, int len)
    {
        var gamma = string.Empty;
        var rnd = new Random(k);
        for (var i = 0; i < len; i++)
        {
            gamma += ((char)rnd.Next(35, 126)).ToString();
        }

        return gamma;
    }

    private string Cipher(string text, int secretKey)
    {
        var currentKey = GetRandomKey(secretKey, text.Length);
        var res = string.Empty;
        for (var i = 0; i < text.Length; i++)
        {
            res += ((char)(text[i] ^ currentKey[i])).ToString();
        }

        return res;
    }

    public string Encrypt(string plainText, int password)
        => Cipher(plainText, password);

    public string Decrypt(string encryptedText, int password)
        => Cipher(encryptedText, password);
}

class Program
{
    static void Main(string[] args)
    {
        var x = new Rez();
        Console.Write("Введите текст сообщения: ");
        var message = Console.ReadLine();
        Console.Write("Введите пароль: ");
        var pass = Convert.ToInt32(Console.ReadLine());
        var encryptedMessageByPass = x.Encrypt(message, pass);
        Console.WriteLine("Зашифрованное сообщение {0}", encryptedMessageByPass);
        Console.WriteLine("Расшифрованное сообщение {0}", x.Decrypt(encryptedMessageByPass, pass));
        Console.ReadLine();
    }
}