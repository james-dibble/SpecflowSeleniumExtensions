namespace Core.Pages
{
    using System.Collections.Generic;

    public interface IPage
    {
        string Title { get; }

        string BaseUrl { get; }

        void Open();

        void Open(IDictionary<string, string> postArguments);
    }
}