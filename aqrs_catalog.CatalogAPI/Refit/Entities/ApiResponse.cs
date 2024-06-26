namespace aqrs_catalog.CatalogAPI.Refit.Entities
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
