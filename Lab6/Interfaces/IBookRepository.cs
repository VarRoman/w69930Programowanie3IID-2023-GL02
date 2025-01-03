namespace Lab6.Interfaces
{
    public interface IBookRepository: IBaseRepository<Book, long>
    {
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetBooksByPublishYear(int year);
    }
}