using System.Security.Cryptography;
using System.Text;

namespace Api.Infrastructure;

public class PasswordGenerator
{
    private const int PasswordLength = 14;
    private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
    private const string Digits = "0123456789";
    private const string SpecialCharacters = "!@#$%^&*";

    public static string GeneratePassword()
    {
        var passwordChars = new char[PasswordLength];
        passwordChars[0] = GetRandomCharacter(UpperCaseLetters);
        passwordChars[1] = GetRandomCharacter(LowerCaseLetters);
        passwordChars[2] = GetRandomCharacter(Digits);
        passwordChars[3] = GetRandomCharacter(SpecialCharacters);
        
        string allChars = UpperCaseLetters + LowerCaseLetters + Digits + SpecialCharacters;
        for (int i = 4; i < PasswordLength; i++)
        {
            passwordChars[i] = GetRandomCharacter(allChars);
        }
        
        ShuffleArray(passwordChars);

        return new string(passwordChars);
    }

    private static char GetRandomCharacter(string characters)
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] data = new byte[4];
            rng.GetBytes(data);
            int index = BitConverter.ToUInt16(data, 0) % characters.Length;
            return characters[index];
        }
    }

    private static void ShuffleArray(char[] array)
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            int n = array.Length;
            while (n > 1)
            {
                byte[] box = new byte[4];
                rng.GetBytes(box);
                int k = (BitConverter.ToUInt16(box, 0) % n);
                n--;
                (array[n], array[k]) = (array[k], array[n]);
            }
        }
    }
}