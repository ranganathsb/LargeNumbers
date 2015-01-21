namespace LargeNumbers
{
    public interface INumberConverter
    {
        string Convert(int number);
        bool CanConvert(int digit);
    }
}