namespace Lab6.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person, int>
    {
        List<Book> GetBorrowedBook(int id);
        void BorrowBook(int id, Book book);
    }
}