namespace BookshelfAPI.DTO
{
    // Class used to return data and descriptive links in API responses
    public class RestDTO<T>
    {
        // Descriptive links
        public List<LinkDTO> Links { get; set; } = [];
        //Data
        public T Data { get; set; } = default!;
    }
}
