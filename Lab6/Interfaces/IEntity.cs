namespace Lab6.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}