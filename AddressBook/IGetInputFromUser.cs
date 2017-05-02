namespace AddressBook
{
    public interface IGetInputFromUser
    {
        int GetNumber();

        string GetNonEmptyString();

        void WaitForEnterkey();
    }
}