namespace MotorRegister.Infrastrucutre.Database;

public class GuidParser
{
    public static Guid ConvertIntToGuid(int id)
    {
        byte[] guidBytes = new byte[16];

        byte[] intBytes = BitConverter.GetBytes(id);
        Array.Copy(intBytes, 0, guidBytes, 0, intBytes.Length);
        
        byte[] fixedBytes = new byte[12] { 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xF0, 0x12 };
        Array.Copy(fixedBytes, 0, guidBytes, intBytes.Length, fixedBytes.Length);

        return new Guid(guidBytes);
    }

    public static int ConvertGuidToInt(Guid guid)
    {
        byte[] guidBytes = guid.ToByteArray();

        return BitConverter.ToInt32(guidBytes, 0);
    }
    
    public static Guid ConvertLongToGuid(long id)
    {
        byte[] guidBytes = new byte[16];

        byte[] longBytes = BitConverter.GetBytes(id);
        Array.Copy(longBytes, 0, guidBytes, 0, longBytes.Length);

        byte[] fixedBytes = new byte[8] { 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x9A };
        Array.Copy(fixedBytes, 0, guidBytes, longBytes.Length, fixedBytes.Length);

        return new Guid(guidBytes);
    }

    public static long ConvertGuidToLong(Guid guid)
    {
        byte[] guidBytes = guid.ToByteArray();

        return BitConverter.ToInt64(guidBytes, 0);
    }
}