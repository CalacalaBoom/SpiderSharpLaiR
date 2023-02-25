namespace lib
{
    public interface IDownload
    {
        bool DownloadFile(object model, int timeout = 2000);
    }
}