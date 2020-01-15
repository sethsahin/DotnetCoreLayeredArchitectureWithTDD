namespace CoreWebApi.Contracts
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string BaseUrl = Root +  "/" + Version;
        
        public static class Category
        {
            public const string GetAllCategories = BaseUrl + "/getCategories";
            public const string GetCategoryById = BaseUrl + "/getCategory/{categoryId}";
        }

        public static class Auth
        {
            public const string Register = BaseUrl + "/auth/register";
            public const string Login = BaseUrl + "/auth/login";
        }

        public static class Post
        {
            public const string CreatePost = BaseUrl + "/post/create";
            public const string GetAllPosts = BaseUrl + "/post/getAll";
            public const string GetPostById = BaseUrl + "/post/{postId}";
            public const string DeletePostById = BaseUrl + "/post/{postId}";
        }

        public static class Product
        {
            public const string CreateProduct = BaseUrl + "/product/create";
            public const string GetAllProducts = BaseUrl + "/product/getAll";
            public const string GetProductById = BaseUrl + "/product/{productId}";
        }
    }
}