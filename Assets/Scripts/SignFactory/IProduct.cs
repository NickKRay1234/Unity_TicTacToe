namespace SignFactory
{
    public interface IProduct
    {
        public string ProductName { get; set; }
        public void Initialize();
    }
}