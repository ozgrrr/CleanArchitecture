namespace CleanArchitecture.Application.Common.Dto.Default
{
    public class DefaultResponse<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string ResultText { get; set; }
    }

    public class DefaultResponse
    {
        public bool Success { get; set; }
        public int Result { get; set; }
        public string ResultText { get; set; }
    }
}
